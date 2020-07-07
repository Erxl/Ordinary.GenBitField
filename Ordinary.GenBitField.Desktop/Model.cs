﻿/*
    Copyright (c) 2020 Erxl
    Ordinary.GenBitField is licensed under Mulan PSL v2.
    You can use this software according to the terms and conditions of the Mulan PSL v2.
    You may obtain a copy of Mulan PSL v2 at:
             http://license.coscl.org.cn/MulanPSL2
    THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
    See the Mulan PSL v2 for more details.
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using Ordinary.Code.CSharp;
using System.Text.Json;

using System.Linq;

using Newtonsoft.Json.Linq;

namespace Ordinary.GenBitField.Desktop
{
    public class Model : ObservableObject
    {
        public Model()
        {
            structInfos = new ObservableCollection<BitFieldStructInfo>();
            StructInfos = new ReadOnlyObservableCollection<BitFieldStructInfo>(structInfos);
        }

        public Model(JObject jsonData)
        {
            var array = jsonData[nameof(StructInfos)];
            structInfos = new ObservableCollection<BitFieldStructInfo>(array.Select(a => new BitFieldStructInfo(a as JObject)));
            StructInfos = new ReadOnlyObservableCollection<BitFieldStructInfo>(structInfos);
        }

        public JArray GetJson()
        {
            var a = new JArray();
            foreach (var item in StructInfos)
            {
                a.Add(item.GetJson());
            }
            return a;
        }

        private ObservableCollection<BitFieldStructInfo> structInfos;
        public ReadOnlyObservableCollection<BitFieldStructInfo> StructInfos { get; }

        public BitFieldStructInfo NewStruct()
        {
            var a = new BitFieldStructInfo();
            structInfos.Add(a);
            return a;
        }

        public void RemoveStruct(BitFieldStructInfo structInfo)
        {
            structInfos.Remove(structInfo);
        }
    }
}