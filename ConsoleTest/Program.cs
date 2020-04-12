/*
    Copyright (c) 2020 Erxl
    Ordinary.GenBitField is licensed under Mulan PSL v2.
    You can use this software according to the terms and conditions of the Mulan PSL v2.
    You may obtain a copy of Mulan PSL v2 at:
             http://license.coscl.org.cn/MulanPSL2
    THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
    See the Mulan PSL v2 for more details.
*/

using Ordinary;
using System;

namespace ConsoleApp1
{
    internal class Program
    {
        internal unsafe struct MyStruct

        {
            private byte byte0, byte1, byte2, byte3, byte4, byte5, byte6, byte7, byte8, byte9, byte10, byte11, byte12, byte13, byte14; public int 我 {
                get {
                    Byte buffer;
                    var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte0;
                    return (int)(7 & (ulong)(buffer >> 0));
                }
                set {
                    uint128 buffer; var bufferPtr = (byte*)&buffer;
                    bufferPtr[0] = (byte)(byte0 << 8);
                    *(Byte*)(bufferPtr + 1) = (Byte)value;
                    *(UInt16*)bufferPtr >>= 8; byte0 = bufferPtr[0];
                }
            }

            public int 是 {
                get {
                    UInt32 buffer;
                    var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte0;
                    bufferPtr[1] = byte1;
                    bufferPtr[2] = byte2;
                    return (int)(32767 & (ulong)(buffer >> 3));
                }
                set {
                    uint128 buffer; var bufferPtr = (byte*)&buffer;
                    bufferPtr[0] = (byte)(byte0 << 5);
                    *(UInt32*)(bufferPtr + 1) = (UInt32)value;
                    *(UInt32*)bufferPtr >>= 5; byte0 = bufferPtr[0];
                    byte1 = bufferPtr[1];
                    byte2 = bufferPtr[2];
                }
            }

            public int 快 {
                get {
                    UInt16 buffer;
                    var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte2;
                    bufferPtr[1] = byte3;
                    return (int)(255 & (ulong)(buffer >> 2));
                }
                set {
                    uint128 buffer; var bufferPtr = (byte*)&buffer;
                    bufferPtr[0] = (byte)(byte2 << 6);
                    *(UInt16*)(bufferPtr + 1) = (UInt16)value;
                    *(UInt32*)bufferPtr >>= 6; byte2 = bufferPtr[0];
                    byte3 = bufferPtr[1];
                }
            }

            public int 乐 {
                get {
                    UInt32 buffer;
                    var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte3;
                    bufferPtr[1] = byte4;
                    bufferPtr[2] = byte5;
                    return (int)(4194303 & (ulong)(buffer >> 2));
                }
                set {
                    uint128 buffer; var bufferPtr = (byte*)&buffer;
                    bufferPtr[0] = (byte)(byte3 << 6);
                    *(UInt32*)(bufferPtr + 1) = (UInt32)value;
                    *(UInt32*)bufferPtr >>= 6; byte3 = bufferPtr[0];
                    byte4 = bufferPtr[1];
                    byte5 = bufferPtr[2];
                }
            }

            public ulong 小 {
                get {
                    UInt64 buffer;
                    var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte6;
                    bufferPtr[1] = byte7;
                    bufferPtr[2] = byte8;
                    bufferPtr[3] = byte9;
                    bufferPtr[4] = byte10;
                    bufferPtr[5] = byte11;
                    bufferPtr[6] = byte12;
                    return (ulong)(9007199254740991 & (ulong)(buffer >> 0));
                }
                set {
                    uint128 buffer; var bufferPtr = (byte*)&buffer;
                    bufferPtr[0] = (byte)(byte6 << 8);
                    *(UInt64*)(bufferPtr + 1) = (UInt64)value;
                    *(UInt64*)bufferPtr >>= 8; byte6 = bufferPtr[0];
                    byte7 = bufferPtr[1];
                    byte8 = bufferPtr[2];
                    byte9 = bufferPtr[3];
                    byte10 = bufferPtr[4];
                    byte11 = bufferPtr[5];
                    byte12 = bufferPtr[6];
                }
            }

            public int 细 {
                get {
                    Byte buffer;
                    var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte12;
                    return (int)(3 & (ulong)(buffer >> 5));
                }
                set {
                    uint128 buffer; var bufferPtr = (byte*)&buffer;
                    bufferPtr[0] = (byte)(byte12 << 3);
                    *(Byte*)(bufferPtr + 1) = (Byte)value;
                    *(UInt16*)bufferPtr >>= 3; byte12 = bufferPtr[0];
                }
            }

            public int 胞 {
                get {
                    UInt32 buffer;
                    var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte12;
                    bufferPtr[1] = byte13;
                    bufferPtr[2] = byte14;
                    return (int)(131071 & (ulong)(buffer >> 7));
                }
                set {
                    uint128 buffer; var bufferPtr = (byte*)&buffer;
                    bufferPtr[0] = (byte)(byte12 << 1);
                    *(UInt32*)(bufferPtr + 1) = (UInt32)value;
                    *(UInt32*)bufferPtr >>= 1; byte12 = bufferPtr[0];
                    byte13 = bufferPtr[1];
                    byte14 = bufferPtr[2];
                }
            }
        }

        private unsafe struct MyStruct1
        {
            private byte byte0, byte1, byte2, byte3, byte4, byte5, byte6, byte7, byte8, byte9, byte10, byte11; public uint 啊 { get { UInt32 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte0; bufferPtr[1] = byte1; bufferPtr[2] = byte2; bufferPtr[3] = byte3; return (uint)(4294967295 & (ulong)(buffer >> 0)); } set { uint128 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = (byte)(byte0 << 8); *(UInt32*)(bufferPtr + 1) = (UInt32)value; *(UInt64*)bufferPtr >>= 8; byte0 = bufferPtr[0]; byte1 = bufferPtr[1]; byte2 = bufferPtr[2]; byte3 = bufferPtr[3]; } }
            public uint ad { get { Byte buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte4; return (uint)(7 & (ulong)(buffer >> 0)); } set { uint128 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = (byte)(byte4 << 8); *(Byte*)(bufferPtr + 1) = (Byte)value; *(UInt16*)bufferPtr >>= 8; byte4 = bufferPtr[0]; } }
            public uint ad4 { get { Byte buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte4; return (uint)(7 & (ulong)(buffer >> 3)); } set { uint128 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = (byte)(byte4 << 5); *(Byte*)(bufferPtr + 1) = (Byte)value; *(UInt16*)bufferPtr >>= 5; byte4 = bufferPtr[0]; } }
            public uint f { get { UInt16 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte4; bufferPtr[1] = byte5; return (uint)(127 & (ulong)(buffer >> 6)); } set { uint128 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = (byte)(byte4 << 2); *(UInt16*)(bufferPtr + 1) = (UInt16)value; *(UInt32*)bufferPtr >>= 2; byte4 = bufferPtr[0]; byte5 = bufferPtr[1]; } }
            public uint sf { get { UInt32 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte5; bufferPtr[1] = byte6; bufferPtr[2] = byte7; return (uint)(4095 & (ulong)(buffer >> 5)); } set { uint128 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = (byte)(byte5 << 3); *(UInt32*)(bufferPtr + 1) = (UInt32)value; *(UInt32*)bufferPtr >>= 3; byte5 = bufferPtr[0]; byte6 = bufferPtr[1]; byte7 = bufferPtr[2]; } }
            public uint sf5 { get { UInt16 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte7; bufferPtr[1] = byte8; return (uint)(255 & (ulong)(buffer >> 1)); } set { uint128 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = (byte)(byte7 << 7); *(UInt16*)(bufferPtr + 1) = (UInt16)value; *(UInt32*)bufferPtr >>= 7; byte7 = bufferPtr[0]; byte8 = bufferPtr[1]; } }
            public uint sf6 { get { UInt32 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte8; bufferPtr[1] = byte9; bufferPtr[2] = byte10; return (uint)(131071 & (ulong)(buffer >> 1)); } set { uint128 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = (byte)(byte8 << 7); *(UInt32*)(bufferPtr + 1) = (UInt32)value; *(UInt32*)bufferPtr >>= 7; byte8 = bufferPtr[0]; byte9 = bufferPtr[1]; byte10 = bufferPtr[2]; } }
            public uint sf3 { get { UInt16 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte10; bufferPtr[1] = byte11; return (uint)(2047 & (ulong)(buffer >> 2)); } set { uint128 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = (byte)(byte10 << 6); *(UInt16*)(bufferPtr + 1) = (UInt16)value; *(UInt32*)bufferPtr >>= 6; byte10 = bufferPtr[0]; byte11 = bufferPtr[1]; } }
        }

        private static void Main(string[] args)
        {
            var a = new MyStruct();
            a.我 = 6;
            a.是 = 10000;
            a.快 = 100;
            a.乐 = 1000000;
            a.小 = 9007199254740991ul;
            a.细 = 3;
            a.胞 = 100000;
            Console.WriteLine(a.我);
            Console.WriteLine(a.是);
            Console.WriteLine(a.快);
            Console.WriteLine(a.乐);
            Console.WriteLine(a.小);
            Console.WriteLine(a.细);
            Console.WriteLine(a.胞);
            Console.WriteLine();

            var b = new MyStruct1();
            b.ad = 4;
            b.ad4 = 600000000;// 此处溢出
            b.ad4 = 6000000;// 此处溢出
            b.ad4 = 600000;// 此处溢出
            b.ad4 = 600400;// 此处溢出
            b.ad4 = 25;// 此处溢出
            b.ad4 = 2;
            b.f = 24;
            b.sf = 1000;
            b.sf5 = 244;
            b.sf6 = 30000;
            b.啊 = 99999999;

            Console.WriteLine(b.ad);
            Console.WriteLine(b.ad4);
            Console.WriteLine(b.f);
            Console.WriteLine(b.sf);
            Console.WriteLine(b.sf5);
            Console.WriteLine(b.sf6);
            Console.WriteLine(b.啊);
            Console.WriteLine();
        }
    }
}