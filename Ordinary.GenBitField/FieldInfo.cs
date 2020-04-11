using Newtonsoft.Json.Linq;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Ordinary.GenBitField
{
    /// <summary>
    /// 一个字段的信息
    /// </summary>
    public class FieldInfo : ObservableObject
    {
        /// <summary>
        /// 包含此字段的结构
        /// </summary>
        public StructInfo Struct { get; }

        public FieldInfo(StructInfo @struct)
        {
            Struct = @struct;
        }

        private string typeName;
        private string name;

        /// <summary>
        /// 表示此字段的类型名
        /// </summary>
        public string TypeName { get => typeName; set => OnPropertyChange(ref typeName, value); }

        public string Name { get => name; set => OnPropertyChange(ref name, value); }

        private int bits;
        private ulong number;

        /// <summary>
        /// 表示此字段的宽度
        /// </summary>
        public int Bits {
            get => bits;
            set {
                //if (useNumber) throw new InvalidOperationException($"启用{nameof(UseNumber)}时，不可以更改{nameof(Bits)}。");
                if (!useNumber)
                    Number = ulong.MaxValue >> (64 - value);
                if (OnPropertyChange(ref bits, value))
                {
                    Struct.UpdateBits();
                }
            }
        }

        /// <summary>
        /// 表示此字段所能表示的最大的值
        /// </summary>
        public ulong Number {
            get => number; set {
                //if (!UseNumber)
                //{
                //    throw new InvalidOperationException($"禁用{nameof(UseNumber)}时，不可以更改{nameof(Number)}。");
                //}

                if (OnPropertyChange(ref number, value))
                {
                    if (useNumber)
                        for (int i = 0; i < 64; i++)
                        {
                            if (value >> i == 0)
                            {
                                Bits = i;
                                break;
                            }
                        }
                }
            }
        }

        private bool useNumber;

        /// <summary>
        /// <para>启用此属性，则根据<see cref="UseNumber"/>大小确定<see cref="Bits"/>的值</para>
        /// <para>禁用此属性，则根据<see cref="Bits"/>大小确定<see cref="UseNumber"/>的值</para>
        /// </summary>
        public bool UseNumber { get => useNumber; set => OnPropertyChange(ref useNumber, value); }

        public void LoadJson(JObject j)
        {
            var a = j as IEnumerable<KeyValuePair<string, JToken?>>;
            TypeName = j[nameof(TypeName)].ToString();
            Name = j[nameof(Name)].ToString();
            UseNumber = j[nameof(UseNumber)].ToObject<bool>();

            if (j.TryGetValue(nameof(Bits), out var v))
            {
                Bits = v.ToObject<int>();
            }
            if (j.TryGetValue(nameof(Number), out var v2))
            {
                Number = v2.ToObject<ulong>();
            }
        }

        public JObject GetJson()
        {
            var j = new JObject();
            j.Add(nameof(TypeName), new JValue(TypeName));
            j.Add(nameof(Name), new JValue(Name));
            j.Add(nameof(UseNumber), new JValue(UseNumber));
            if (UseNumber)
            {
                j.Add(nameof(Number), new JValue(Number));
            }
            else
            {
                j.Add(nameof(Bits), new JValue(Bits));
            }
            return j;
        }
    }
}