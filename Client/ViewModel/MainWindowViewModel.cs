using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Client.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ICommand asd { get; private set; }

        public MainWindowViewModel()
        {
            asd = new DelegateComand(fleks);
        }

        private void Skan(string sourceDir)
        {
            Task.Run(() =>
            {
                string[] picList = Directory.GetFiles(sourceDir, "*.mp3");
                foreach (string f in picList)
                {
                    string fName = f.Substring(sourceDir.Length + 1);
                    File.Copy(Path.Combine(sourceDir, fName), Path.Combine("D:\\Music_for_project", fName), true);
                }
            });
        }

        void fleks(object obj)
        {
            string sourceDir = null;
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = @"C:\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                sourceDir = dialog.FileName;
            }
            if(sourceDir != null)
                Skan(sourceDir);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
