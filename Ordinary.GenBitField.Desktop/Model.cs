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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using Ordinary.CSharpCode;

namespace Ordinary.GenBitField.Desktop
{
    public class Model : ObservableObject
    {
        public Model()
        {
            StructInfos = new ReadOnlyObservableCollection<BitFieldStructInfo>(structInfos);
        }

        private ObservableCollection<BitFieldStructInfo> structInfos = new ObservableCollection<BitFieldStructInfo>();
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

        public void LoadJson(JArray array)
        {
            foreach (var item in array)
            {
                NewStruct().LoadJson(item as JObject);
            }
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
    }
}