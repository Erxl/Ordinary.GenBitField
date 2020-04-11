using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Ordinary.GenBitField.Desktop
{
    public class StructInfoVM : ObservableObject
    {
        public MainWindowVM MainWindowVM { get; }
        public StructInfo StructInfo { get; }

        public StructInfoVM(MainWindowVM mainWindowVM, StructInfo structInfo)
        {
            MainWindowVM = mainWindowVM;
            StructInfo = structInfo;
            fieldInfoVMsMapping = new ObservableMappingCollectionMapping<FieldInfo, FieldInfoVM>(
                fieldInfoVMs, StructInfo.FieldInfos, a => new FieldInfoVM(this, a));
            FieldInfoVMs = new ReadOnlyObservableCollection<FieldInfoVM>(fieldInfoVMs);
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
            a.TypeName = "int";
            a.Bits = 32;
        }

        public ICommand NewFieldCommand { get; }
        public ICommand RemoveThisCommand { get; }
        private ObservableMappingCollectionMapping<FieldInfo, FieldInfoVM> fieldInfoVMsMapping;
        private ObservableCollection<FieldInfoVM> fieldInfoVMs = new ObservableCollection<FieldInfoVM>();
        public ReadOnlyObservableCollection<FieldInfoVM> FieldInfoVMs { get; }

        public void CopyStructMembersCode()
        {
            Clipboard.SetText(StructInfo.GetStructMembersCode().ToString());
        }

        public ICommand CopyStructMembersCodeCommand { get; }
    }
}