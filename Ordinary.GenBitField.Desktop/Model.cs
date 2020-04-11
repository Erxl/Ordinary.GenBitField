using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace Ordinary.GenBitField.Desktop
{
    public class Model : ObservableObject
    {
        public Model()
        {
            StructInfos = new ReadOnlyObservableCollection<StructInfo>(structInfos);
        }

        private ObservableCollection<StructInfo> structInfos = new ObservableCollection<StructInfo>();
        public ReadOnlyObservableCollection<StructInfo> StructInfos { get; }

        public StructInfo NewStruct()
        {
            var a = new StructInfo();
            structInfos.Add(a);
            return a;
        }

        public void RemoveStruct(StructInfo structInfo)
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