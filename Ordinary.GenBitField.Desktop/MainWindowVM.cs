using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Input;

namespace Ordinary.GenBitField.Desktop
{
    public class MainWindowVM : ObservableObject
    {
        public MainWindowVM()
        {
            Model = new Model();
            var args = Environment.GetCommandLineArgs();

            if (args.Length == 2)
            {
                var arg = args[1];
                FileDirectory = arg;
                Model.LoadJson(JArray.Parse(File.ReadAllText(arg)));
            }
            structInfoVMsMapping = new ObservableMappingCollectionMapping<StructInfo, StructInfoVM>(
                structInfoVMs, Model.StructInfos, a => new StructInfoVM(this, a));
            StructInfoVMs = new ReadOnlyObservableCollection<StructInfoVM>(structInfoVMs);
            NewStructCommand = new DelegateCommand(NewStruct);
            SaveCommand = new DelegateCommand(Save);
            SaveAsCommand = new DelegateCommand(SaveAs);
            OpenCommand = new DelegateCommand(Open);
        }

        public string FileDirectory { get => file; set => OnPropertyChange(ref file, value); }
        public Model Model { get; }

        private ObservableMappingCollectionMapping<StructInfo, StructInfoVM> structInfoVMsMapping;
        private ObservableCollection<StructInfoVM> structInfoVMs = new ObservableCollection<StructInfoVM>();
        private string file;

        public ReadOnlyObservableCollection<StructInfoVM> StructInfoVMs { get; }

        public void NewStruct()
        {
            Model.NewStruct().Name = "MyStruct";
        }

        public ICommand NewStructCommand { get; }

        public void RemoveStruct(StructInfoVM structInfoVM)
        {
            Model.RemoveStruct(structInfoVM.StructInfo);
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
                File.WriteAllText(FileDirectory, Model.GetJson().ToString());
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
                File.WriteAllText(FileDirectory, Model.GetJson().ToString());
        }

        public ICommand SaveAsCommand { get; }

        public void Open()
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() ?? false)
            {
                FileDirectory = dialog.FileName;
                Model.LoadJson(JArray.Parse(File.ReadAllText(FileDirectory)));
            }
        }

        public ICommand OpenCommand { get; }
    }
}