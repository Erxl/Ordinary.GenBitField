using System.Windows.Input;

namespace Ordinary.GenBitField.Desktop
{
    public class FieldInfoVM
    {
        public FieldInfo FieldInfo { get; }
        public StructInfoVM StructInfoVM { get; }

        public FieldInfoVM(StructInfoVM structInfovm, FieldInfo fieldInfo)
        {
            StructInfoVM = structInfovm;
            FieldInfo = fieldInfo;
            RemoveThisCommand = new DelegateCommand(RemoveThis);
        }

        public void RemoveThis()
        {
            StructInfoVM.StructInfo.RemoveField(FieldInfo);
        }

        public ICommand RemoveThisCommand { get; }
    }
}