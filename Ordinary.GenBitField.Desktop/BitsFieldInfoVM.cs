/*
    Copyright (c) 2020 Erxl
    Ordinary.GenBitField is licensed under Mulan PSL v2.
    You can use this software according to the terms and conditions of the Mulan PSL v2.
    You may obtain a copy of Mulan PSL v2 at:
             http://license.coscl.org.cn/MulanPSL2
    THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
    See the Mulan PSL v2 for more details.
*/

using System.Windows.Input;
using Ordinary.Code.CSharp;

namespace Ordinary.GenBitField.Desktop
{
    public class BitsFieldInfoVM
    {
        public BitFieldInfo FieldInfo { get; }
        public BitsFieldStructInfoVM BitsFieldStructInfoVm { get; }

        public BitsFieldInfoVM(BitsFieldStructInfoVM bitsFieldStructInfovm, BitFieldInfo fieldInfo)
        {
            BitsFieldStructInfoVm = bitsFieldStructInfovm;
            FieldInfo = fieldInfo;
            RemoveThisCommand = new DelegateCommand(RemoveThis);
        }

        public void RemoveThis()
        {
            BitsFieldStructInfoVm.StructInfo.RemoveField(FieldInfo);
        }

        public ICommand RemoveThisCommand { get; }
    }
}