/*
    Copyright (c) 2020 Erxl
    Ordinary.GenBitField is licensed under Mulan PSL v2.
    You can use this software according to the terms and conditions of the Mulan PSL v2.
    You may obtain a copy of Mulan PSL v2 at:
             http://license.coscl.org.cn/MulanPSL2
    THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
    See the Mulan PSL v2 for more details.
*/

using Newtonsoft.Json.Linq;
using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Ordinary.GenBitField
{
    /// <summary>
    /// 一个结构体的信息
    /// </summary>
    public class StructInfo : ObservableObject
    {
        private string name;

        /// <summary>
        /// 结构体的名字
        /// </summary>
        public string Name { get => name; set => OnPropertyChange(ref name, value); }

        /// <summary>
        /// 表示结构体所包含的字段
        /// </summary>
        public ReadOnlyObservableCollection<FieldInfo> FieldInfos { get; }

        public StructInfo()
        {
            FieldInfos = new ReadOnlyObservableCollection<FieldInfo>(fieldInfos);
        }

        private ObservableCollection<FieldInfo> fieldInfos = new ObservableCollection<FieldInfo>();
        private int size;
        private int bits;

        public FieldInfo NewField()
        {
            var a = new FieldInfo(this);
            fieldInfos.Add(a);
            return a;
        }

        public void RemoveField(FieldInfo fieldInfo)
        {
            fieldInfos.Remove(fieldInfo);
        }

        /// <summary>
        /// 此结构所占字节数
        /// </summary>
        public int Size { get => size; private set => OnPropertyChange(ref size, value); }

        /// <summary>
        /// 此结构实际使用比特数
        /// </summary>
        public int Bits {
            get => bits; private set {
                if (OnPropertyChange(ref bits, value))
                {
                    Size = (value >> 3) + ((value % 8) == 0 ? 0 : 1);
                }
            }
        }

        internal void UpdateBits()
        {
            Bits = fieldInfos.Sum(a => a.Bits);
        }

        public void LoadJson(JObject j)
        {
            Name = j[nameof(Name)].ToString();
            var a = (j[nameof(FieldInfos)] as JArray);
            foreach (var item in a)
            {
                NewField().LoadJson(item as JObject);
            }
        }

        public JObject GetJson()
        {
            var j = new JObject();
            j.Add(nameof(Name), new JValue(Name));
            var array = new JArray();
            j.Add(nameof(FieldInfos), array);
            foreach (var item in FieldInfos)
            {
                array.Add(item.GetJson());
            }
            return j;
        }

        //private enum BufferType
        //{
        //    Int8,
        //    Int16,
        //    Int16,
        //}

        /// <summary>
        /// 获取结构成员的代码
        /// </summary>
        /// <returns>代码文本</returns>
        public StringBuilder GetStructMembersCode()
        {
            var sb = new StringBuilder();

            var l = FieldInfos.Count;

            //生成数据缓冲区字段
            sb.Append($"private byte ");
            for (int i = 0; i < Size; i++)
            {
                sb.Append($"byte{i}");
                if (i == Size - 1)
                {
                    sb.Append(';');
                }
                else
                {
                    sb.Append(',');
                }
            }

            //生成每个字段属性
            var beginBits = 0;
            var endBits = 0;
            for (var i = 0; i < l; i++)
            {
                //初始化各种信息
                var item = FieldInfos[i];
                endBits += item.Bits;
                var beginByte = beginBits >> 3;
                var endByte = (endBits >> 3) + ((endBits % 8) == 0 ? 0 : 1);
                var size = endByte - beginByte;
                var offsetInBeginByte = beginBits % 8;
                var offsetInEndByte = endBits % 8;

                var intbufs = (size >> 2) + ((size % 4) == 0 ? 0 : 1);
                //创建属性
                sb.Append($"public {item.TypeName} {item.Name}");

                //Get方法
                sb.Append("{get{");

                //生成源缓冲区和结果缓冲区
                if (intbufs == 1)
                {
                    sb.Append("uint buf1;");
                    sb.Append("uint buf2;");
                    sb.Append("uint* bufsrc=&buf1;");
                    sb.Append("uint* bufdst=&buf2;");
                }
                else if (intbufs == 2)
                {
                    sb.Append("ulong buf1;");
                    sb.Append("ulong buf2;");
                    sb.Append("uint* bufsrc=(uint*)&buf1;");
                    sb.Append("uint* bufdst=(uint*)&buf2;");
                }
                else if (intbufs <= 4)
                {
                    sb.Append("uint128 buf1;");
                    sb.Append("uint128 buf2;");
                    sb.Append("uint* bufsrc=(uint*)&buf1;");
                    sb.Append("uint* bufdst=(uint*)&buf2;");
                }
                else
                {
                    sb.Append($"var bufsrc=stackalloc uint[{intbufs}];");
                    sb.Append($"var bufdst=stackalloc uint[{intbufs}];");//
                }

                for (int j = 0; j < size; j++)
                {
                    if (j == size - 1 && offsetInEndByte != 0)//判断是否在末尾，且有偏移（需要使用蒙版）
                    {
                        sb.Append($"*((byte*)bufsrc+{j})=(byte)(byte{beginByte + j}&{(byte)(byte.MaxValue >> (8 - offsetInEndByte))});");//复制数据到源缓冲区,并在末尾使用蒙版
                    }
                    else
                    {
                        sb.Append($"*((byte*)bufsrc+{j})=byte{beginByte + j};");//复制数据到源缓冲区
                    }
                }
                if (offsetInBeginByte != 0) ;
                //右移到目的缓冲区
                if (intbufs <= 4)
                {
                    sb.Append($"buf2=buf1>>{offsetInBeginByte};");
                }
                else
                {
                    sb.Append($"M.ShiftRightShort(bufsrc, {intbufs}, bufdst,{offsetInBeginByte});");
                }
                sb.Append($"return *({item.TypeName}*)bufdst;");//返回

                //Set方法
                var t = SelectIntTypeFromSize(size);
                sb.Append("}set{");

                //生成源缓冲区和结果缓冲区
                if (intbufs == 1)
                {
                    sb.Append("uint buf1;");
                    sb.Append("uint buf2;");
                    sb.Append("uint* bufsrc=&buf1;");
                    sb.Append("uint* bufdst=&buf2;");
                }
                else if (intbufs == 2)
                {
                    sb.Append("ulong buf1;");
                    sb.Append("ulong buf2;");
                    sb.Append("uint* bufsrc=(uint*)&buf1;");
                    sb.Append("uint* bufdst=(uint*)&buf2;");
                }
                else if (intbufs <= 4)
                {
                    sb.Append("uint128 buf1;");
                    sb.Append("uint128 buf2;");
                    sb.Append("uint* bufsrc=(uint*)&buf1;");
                    sb.Append("uint* bufdst=(uint*)&buf2;");
                }
                else
                {
                    sb.Append($"var bufsrc=stackalloc uint[{intbufs}];");
                    sb.Append($"var bufdst=stackalloc uint[{intbufs}];");//
                }

                sb.Append($"*({item.TypeName}*)bufsrc=value;");//装入源缓冲区
                if (offsetInBeginByte != 0)
                {
                    //左移到目的缓冲区
                    if (intbufs <= 4)
                    {
                        sb.Append($"buf2=buf1<<{offsetInBeginByte};");
                    }
                    else
                    {
                        sb.Append($"M.ShiftLeftShort(bufsrc, {intbufs}, bufdst,{offsetInBeginByte});");
                    }
                    sb.Append($"*(byte*)bufdst|=(byte)(byte{beginByte}&{(byte)(byte.MaxValue >> (8 - offsetInBeginByte))});");//为起点字节填充缺少信息
                }
                if (offsetInEndByte != 0)
                {
                    sb.Append($"*((byte*)bufdst+{size - 1})|=(byte)(byte{endByte}&{(byte)(byte.MaxValue << offsetInEndByte)});");//为终点字节填充缺少信息
                }

                //拷贝缓冲区到数据
                for (int j = 0; j < size; j++)
                {
                    sb.Append($"byte{j}=((byte*)bufdst)[{j}];");
                }

                //结束本属性
                sb.Append("}}");
                beginBits = endBits;
            }
            return sb;
        }

        private static Type SelectIntTypeFromSize(int size)
        {
            if (size == 1)
            {
                return typeof(byte);
            }
            else if (size == 2)
            {
                return typeof(ushort);
            }
            else if (size <= 4)
            {
                return typeof(uint);
            }
            else if (size <= 8)
            {
                return typeof(ulong);
            }
            else if (size <= 16)
            {
                return typeof(uint128);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private static ulong GetBitMask(int bits)
        {
            var a = ulong.MaxValue;
            return a >> 64 - bits;
        }
    }
}