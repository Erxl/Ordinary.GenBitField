/*
    Copyright (c) 2020 Erxl
    Ordinary.GenBitField is licensed under Mulan PSL v2.
    You can use this software according to the terms and conditions of the Mulan PSL v2.
    You may obtain a copy of Mulan PSL v2 at:
             http://license.coscl.org.cn/MulanPSL2
    THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
    See the Mulan PSL v2 for more details.
*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ordinary;
using System;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var a = new MyStruct();
            a.我 = 6;
            a.是 = 10000;
            a.快 = 100;
            a.乐 = 1000000;
            a.小 = 9007199254740991ul;
            a.细 = 3;
            a.胞 = 100000;

            Assert.AreEqual(a.我, 6);
            Assert.AreEqual(a.是, 10000);
            Assert.AreEqual(a.快, 100);
            Assert.AreEqual(a.乐, 1000000);
            Assert.AreEqual(a.小, 9007199254740991ul);
            Assert.AreEqual(a.细, 3);
            Assert.AreEqual(a.胞, 100000);
        }
    }

    internal unsafe struct MyStruct
    {
        private byte byte0, byte1, byte2, byte3, byte4, byte5, byte6, byte7, byte8, byte9, byte10, byte11, byte12, byte13, byte14; public int 我 { get { Byte buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte0; return (int)(7 & (ulong)(buffer >> 0)); } set { uint128 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = (byte)(byte0 << 8); *(Byte*)(bufferPtr + 1) = (Byte)value; *(UInt16*)bufferPtr >>= 8; byte0 = bufferPtr[0]; } }
        public int 是 { get { UInt32 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte0; bufferPtr[1] = byte1; bufferPtr[2] = byte2; return (int)(32767 & (ulong)(buffer >> 3)); } set { uint128 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = (byte)(byte0 << 5); *(UInt32*)(bufferPtr + 1) = (UInt32)value; *(UInt32*)bufferPtr >>= 5; byte0 = bufferPtr[0]; byte1 = bufferPtr[1]; byte2 = bufferPtr[2]; } }
        public int 快 { get { UInt16 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte2; bufferPtr[1] = byte3; return (int)(255 & (ulong)(buffer >> 2)); } set { uint128 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = (byte)(byte2 << 6); *(UInt16*)(bufferPtr + 1) = (UInt16)value; *(UInt32*)bufferPtr >>= 6; byte2 = bufferPtr[0]; byte3 = bufferPtr[1]; } }
        public int 乐 { get { UInt32 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte3; bufferPtr[1] = byte4; bufferPtr[2] = byte5; return (int)(4194303 & (ulong)(buffer >> 2)); } set { uint128 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = (byte)(byte3 << 6); *(UInt32*)(bufferPtr + 1) = (UInt32)value; *(UInt32*)bufferPtr >>= 6; byte3 = bufferPtr[0]; byte4 = bufferPtr[1]; byte5 = bufferPtr[2]; } }
        public ulong 小 { get { UInt64 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte6; bufferPtr[1] = byte7; bufferPtr[2] = byte8; bufferPtr[3] = byte9; bufferPtr[4] = byte10; bufferPtr[5] = byte11; bufferPtr[6] = byte12; return (ulong)(9007199254740991 & (ulong)(buffer >> 0)); } set { uint128 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = (byte)(byte6 << 8); *(UInt64*)(bufferPtr + 1) = (UInt64)value; *(UInt64*)bufferPtr >>= 8; byte6 = bufferPtr[0]; byte7 = bufferPtr[1]; byte8 = bufferPtr[2]; byte9 = bufferPtr[3]; byte10 = bufferPtr[4]; byte11 = bufferPtr[5]; byte12 = bufferPtr[6]; } }
        public int 细 { get { Byte buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte12; return (int)(3 & (ulong)(buffer >> 5)); } set { uint128 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = (byte)(byte12 << 3); *(Byte*)(bufferPtr + 1) = (Byte)value; *(UInt16*)bufferPtr >>= 3; byte12 = bufferPtr[0]; } }
        public int 胞 { get { UInt32 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = byte12; bufferPtr[1] = byte13; bufferPtr[2] = byte14; return (int)(131071 & (ulong)(buffer >> 7)); } set { uint128 buffer; var bufferPtr = (byte*)&buffer; bufferPtr[0] = (byte)(byte12 << 1); *(UInt32*)(bufferPtr + 1) = (UInt32)value; *(UInt32*)bufferPtr >>= 1; byte12 = bufferPtr[0]; byte13 = bufferPtr[1]; byte14 = bufferPtr[2]; } }
    }
}