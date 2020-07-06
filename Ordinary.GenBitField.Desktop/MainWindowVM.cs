/*
    Copyright (c) 2020 Erxl
    Ordinary.GenBitField is licensed under Mulan PSL v2.
    You can use this software according to the terms and conditions of the Mulan PSL v2.
    You may obtain a copy of Mulan PSL v2 at:
             http://license.coscl.org.cn/MulanPSL2
    THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
    See the Mulan PSL v2 for more details.
*/

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Input;
using Ordinary.Code.CSharp;
using System.Text.Json;

namespace Ordinary.GenBitField.Desktop
{
    public class MainWindowVM : ObservableObject
    {
        public MainWindowVM()
        {
            var args = Environment.GetCommandLineArgs();

            if (args.Length == 2)
            {
                var arg = args[1];
                FileDirectory = arg;
                Model = JsonSerializer.Deserialize<Model>(File.ReadAllText(arg));
            }
            if (Model == null)
            {
                Model = new Model();
            }
            structInfoVMsMapping = new ObservableMappingCollectionMapping<BitFieldStructInfo, BitsFieldStructInfoVM>(
                structInfoVMs, Model.StructInfos, a => new BitsFieldStructInfoVM(this, a));
            StructInfoVMs = new ReadOnlyObservableCollection<BitsFieldStructInfoVM>(structInfoVMs);
            NewStructCommand = new DelegateCommand(NewStruct);
            SaveCommand = new DelegateCommand(Save);
            SaveAsCommand = new DelegateCommand(SaveAs);
            OpenCommand = new DelegateCommand(Open);
        }

        public string FileDirectory { get => file; set => OnPropertyChange(ref file, value); }
        public Model Model { get; private set; }

        private ObservableMappingCollectionMapping<BitFieldStructInfo, BitsFieldStructInfoVM> structInfoVMsMapping;
        private ObservableCollection<BitsFieldStructInfoVM> structInfoVMs = new ObservableCollection<BitsFieldStructInfoVM>();
        private string file;

        public ReadOnlyObservableCollection<BitsFieldStructInfoVM> StructInfoVMs { get; }

        public void NewStruct()
        {
            Model.NewStruct().Name = "MyStruct";
        }

        public ICommand NewStructCommand { get; }

        public void RemoveStruct(BitsFieldStructInfoVM bitsFieldStructInfoVm)
        {
            Model.RemoveStruct(bitsFieldStructInfoVm.StructInfo);
        }

        public ICommand SaveCommand { get; }

        public void Save()
        {
            if (string.IsNullOrEmpty(FileDirectory))
            {
                var dialog = new SaveFileDialog();
                dialog.DefaultExt = "json";
                if (dialog.ShowDialog().GetValueOrDefault())
                {
                    FileDirectory = dialog.FileName;
                }
            }
            if (!string.IsNullOrEmpty(FileDirectory))
                File.WriteAllText(FileDirectory, JsonSerializer.Serialize(Model));
        }

        public void SaveAs()
        {
            var dialog = new SaveFileDialog();
            dialog.DefaultExt = "json";
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                FileDirectory = dialog.FileName;
            }

            if (!string.IsNullOrEmpty(FileDirectory))
                File.WriteAllText(FileDirectory, JsonSerializer.Serialize(Model));
        }

        public ICommand SaveAsCommand { get; }

        public void Open()
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() ?? false)
            {
                FileDirectory = dialog.FileName;
                Model = JsonSerializer.Deserialize<Model>(File.ReadAllText(FileDirectory));
            }
        }

        public ICommand OpenCommand { get; }
    }
}