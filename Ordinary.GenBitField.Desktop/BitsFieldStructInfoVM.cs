/*
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
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Ordinary.CSharpCode;

namespace Ordinary.GenBitField.Desktop
{
    public class BitsFieldStructInfoVM : ObservableObject
    {
        public MainWindowVM MainWindowVM { get; }
        public BitFieldStructInfo StructInfo { get; }

        public BitsFieldStructInfoVM(MainWindowVM mainWindowVM, BitFieldStructInfo structInfo)
        {
            MainWindowVM = mainWindowVM;
            StructInfo = structInfo;
            fieldInfoVMsMapping = new ObservableMappingCollectionMapping<BitFieldInfo, BitsFieldInfoVM>(
                fieldInfoVMs, StructInfo.FieldInfos, a => new BitsFieldInfoVM(this, a));
            FieldInfoVMs = new ReadOnlyObservableCollection<BitsFieldInfoVM>(fieldInfoVMs);
            NewFieldCommand = new DelegateCommand(NewField);
            RemoveThisCommand = new DelegateCommand(RemoveThis);
            CopyStructMembersCodeCommand = new DelegateCommand(CopyStructMembersCode);
        }

        public void RemoveThis()
        {
            MainWindowVM.Model.RemoveStruct(StructInfo);
        }

        public void NewField()
        {
            var a = StructInfo.NewField();
            a.TypeName = "uint";
            a.Bits = 32;
        }

        public ICommand NewFieldCommand { get; }
        public ICommand RemoveThisCommand { get; }
        private ObservableMappingCollectionMapping<BitFieldInfo, BitsFieldInfoVM> fieldInfoVMsMapping;
        private ObservableCollection<BitsFieldInfoVM> fieldInfoVMs = new ObservableCollection<BitsFieldInfoVM>();
        public ReadOnlyObservableCollection<BitsFieldInfoVM> FieldInfoVMs { get; }

        public void CopyStructMembersCode()
        {
            Clipboard.SetText(StructInfo.GetStructMembersCode().ToString());
        }

        public ICommand CopyStructMembersCodeCommand { get; }
    }
}