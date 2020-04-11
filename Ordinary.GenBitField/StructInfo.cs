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

        /// <summary>
        /// 获取结构成员的代码
        /// </summary>
        /// <returns>代码文本</returns>
        public StringBuilder GetStructMembersCode()
        {
            var sb = new StringBuilder();

            //生成数据缓冲区字段
            sb.Append("private byte ");
            for (int i = 0; i < Size; i++)
            {
                sb.Append("byte" + i);
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
            var l = FieldInfos.Count;
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
                var offsetInByte = beginBits % 8;

                //创建属性
                sb.Append($"public {item.TypeName} {item.Name}");

                //Get方法
                sb.Append("{get{");
                sb.Append($"{SelectIntTypeFromSize(size).Name} buffer;");//声明buffer
                sb.Append("var bufferPtr=(byte*)&buffer;");//声明buffer指针
                for (int j = 0; j < size; j++)//为buffer赋值
                {
                    sb.Append($"bufferPtr[{j}]=byte{beginByte + j};");
                }
                sb.Append($"return ({item.TypeName})({GetBitMask(item.Bits)}&(ulong)(buffer>>{offsetInByte}));");//将右移后的buffer返回

                //Set方法
                var t = SelectIntTypeFromSize(size);
                sb.Append("}set{");
                sb.Append($"{typeof(uint128).Name} buffer;");//声明buffer
                sb.Append("var bufferPtr=(byte*)&buffer;");//声明buffer指针
                sb.Append($"bufferPtr[0]=(byte)(byte{beginByte}<<{8 - offsetInByte});");
                sb.Append($"*({t.Name}*)(bufferPtr+1)=({t.Name})value;");
                sb.Append($"*({SelectIntTypeFromSize(size + 1).Name}*)bufferPtr>>={8 - offsetInByte};");
                for (int j = 0; j < size; j++)//为字段赋值
                {
                    sb.Append($"byte{beginByte + j}=bufferPtr[{j}];");
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