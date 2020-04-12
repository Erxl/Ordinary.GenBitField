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
using BitFields;

namespace ConsoleApp1
{
    internal struct Rgb555
    {
        private enum BitFields
        {
            B = 5,
            G = 5,
            R = 5,
        }
    }

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
            private byte byte0, byte1, byte2, byte3, byte4, byte5, byte6, byte7, byte8, byte9, byte10, byte11, byte12, byte13, byte14; public int 我 { get { uint buf1; uint buf2; uint* bufsrc = &buf1; uint* bufdst = &buf2; *((byte*)bufsrc + 0) = (byte)(byte0 & 7); buf2 = buf1 >> 0; return *(int*)bufdst; } set { uint buf1; uint buf2; uint* bufsrc = &buf1; uint* bufdst = &buf2; *(int*)bufsrc = value; *((byte*)bufdst + 0) |= (byte)(byte1 & 248); byte0 = ((byte*)bufdst)[0]; } }
            public int 是 { get { uint buf1; uint buf2; uint* bufsrc = &buf1; uint* bufdst = &buf2; *((byte*)bufsrc + 0) = byte0; *((byte*)bufsrc + 1) = byte1; *((byte*)bufsrc + 2) = (byte)(byte2 & 3); buf2 = buf1 >> 3; return *(int*)bufdst; } set { uint buf1; uint buf2; uint* bufsrc = &buf1; uint* bufdst = &buf2; *(int*)bufsrc = value; buf2 = buf1 << 3; *(byte*)bufdst |= (byte)(byte0 & 7); *((byte*)bufdst + 2) |= (byte)(byte3 & 252); byte0 = ((byte*)bufdst)[0]; byte1 = ((byte*)bufdst)[1]; byte2 = ((byte*)bufdst)[2]; } }
            public int 快 { get { uint buf1; uint buf2; uint* bufsrc = &buf1; uint* bufdst = &buf2; *((byte*)bufsrc + 0) = byte2; *((byte*)bufsrc + 1) = (byte)(byte3 & 3); buf2 = buf1 >> 2; return *(int*)bufdst; } set { uint buf1; uint buf2; uint* bufsrc = &buf1; uint* bufdst = &buf2; *(int*)bufsrc = value; buf2 = buf1 << 2; *(byte*)bufdst |= (byte)(byte2 & 3); *((byte*)bufdst + 1) |= (byte)(byte4 & 252); byte0 = ((byte*)bufdst)[0]; byte1 = ((byte*)bufdst)[1]; } }
            public int 乐 { get { uint buf1; uint buf2; uint* bufsrc = &buf1; uint* bufdst = &buf2; *((byte*)bufsrc + 0) = byte3; *((byte*)bufsrc + 1) = byte4; *((byte*)bufsrc + 2) = byte5; buf2 = buf1 >> 2; return *(int*)bufdst; } set { uint buf1; uint buf2; uint* bufsrc = &buf1; uint* bufdst = &buf2; *(int*)bufsrc = value; buf2 = buf1 << 2; *(byte*)bufdst |= (byte)(byte3 & 3); byte0 = ((byte*)bufdst)[0]; byte1 = ((byte*)bufdst)[1]; byte2 = ((byte*)bufdst)[2]; } }
            public ulong 小 { get { ulong buf1; ulong buf2; uint* bufsrc = (uint*)&buf1; uint* bufdst = (uint*)&buf2; *((byte*)bufsrc + 0) = byte6; *((byte*)bufsrc + 1) = byte7; *((byte*)bufsrc + 2) = byte8; *((byte*)bufsrc + 3) = byte9; *((byte*)bufsrc + 4) = byte10; *((byte*)bufsrc + 5) = byte11; *((byte*)bufsrc + 6) = (byte)(byte12 & 31); buf2 = buf1 >> 0; return *(ulong*)bufdst; } set { ulong buf1; ulong buf2; uint* bufsrc = (uint*)&buf1; uint* bufdst = (uint*)&buf2; *(ulong*)bufsrc = value; *((byte*)bufdst + 6) |= (byte)(byte13 & 224); byte0 = ((byte*)bufdst)[0]; byte1 = ((byte*)bufdst)[1]; byte2 = ((byte*)bufdst)[2]; byte3 = ((byte*)bufdst)[3]; byte4 = ((byte*)bufdst)[4]; byte5 = ((byte*)bufdst)[5]; byte6 = ((byte*)bufdst)[6]; } }
            public int 细 { get { uint buf1; uint buf2; uint* bufsrc = &buf1; uint* bufdst = &buf2; *((byte*)bufsrc + 0) = (byte)(byte12 & 127); buf2 = buf1 >> 5; return *(int*)bufdst; } set { uint buf1; uint buf2; uint* bufsrc = &buf1; uint* bufdst = &buf2; *(int*)bufsrc = value; buf2 = buf1 << 5; *(byte*)bufdst |= (byte)(byte12 & 31); *((byte*)bufdst + 0) |= (byte)(byte13 & 128); byte0 = ((byte*)bufdst)[0]; } }
            public int 胞 { get { uint buf1; uint buf2; uint* bufsrc = &buf1; uint* bufdst = &buf2; *((byte*)bufsrc + 0) = byte12; *((byte*)bufsrc + 1) = byte13; *((byte*)bufsrc + 2) = byte14; buf2 = buf1 >> 7; return *(int*)bufdst; } set { uint buf1; uint buf2; uint* bufsrc = &buf1; uint* bufdst = &buf2; *(int*)bufsrc = value; buf2 = buf1 << 7; *(byte*)bufdst |= (byte)(byte12 & 127); byte0 = ((byte*)bufdst)[0]; byte1 = ((byte*)bufdst)[1]; byte2 = ((byte*)bufdst)[2]; } }
        }

        private unsafe static void Main(string[] args)
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
            Console.WriteLine(sizeof(MyStruct1));

            //var b = new MyStruct1();
            //b.ad = 4;
            //b.ad4 = 600000000;// 此处溢出
            //b.ad4 = 6000000;// 此处溢出
            //b.ad4 = 600000;// 此处溢出
            //b.ad4 = 600400;// 此处溢出
            //b.ad4 = 25;// 此处溢出
            //b.ad4 = 2;
            //b.f = 24;
            //b.sf = 1000;
            //b.sf5 = 244;
            //b.sf6 = 30000;
            //b.啊 = 99999999;

            //Console.WriteLine(b.ad);
            //Console.WriteLine(b.ad4);
            //Console.WriteLine(b.f);
            //Console.WriteLine(b.sf);
            //Console.WriteLine(b.sf5);
            //Console.WriteLine(b.sf6);
            //Console.WriteLine(b.啊);
            //Console.WriteLine();

            //var aaa = 0ul;
            //*(uint24*)&aaa = uint24.MaxValue;
            //aaa <<= 1;
            //*(uint24*)&aaa = uint24.MinValue;
            //Console.WriteLine(aaa);
            //Console.WriteLine(aaa >> 24);

            //Console.WriteLine(sizeof(uint24));

            //var buf = stackalloc uint[3];
            //buf[0] = 2291107983;
            //buf[1] = 2291107983;
            //buf[2] = 2291107983;
            //var buf2 = stackalloc uint[3];
            //for (int i = 0; i < 40; i++)
            //{
            //    Console.WriteLine(Convert.ToString(buf[0], 2));
            //    Console.WriteLine(Convert.ToString(buf[1], 2));
            //    Console.WriteLine(Convert.ToString(buf[2], 2));
            //    M.ShiftRightShort(buf, 3, buf2, 1);
            //    Console.WriteLine(Convert.ToString(buf2[0], 2));
            //    Console.WriteLine(Convert.ToString(buf2[1], 2));
            //    Console.WriteLine(Convert.ToString(buf2[2], 2));
            //    M.ShiftRightShort(buf2, 3, buf, 1);
            //}
        }
    }
}