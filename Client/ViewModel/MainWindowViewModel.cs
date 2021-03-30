using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using MusicPlayer.BLL.Interfaces;
using MusicPlayer.BLL.Services;
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
      //  private IService userService = new UserService();
        private Command select_dir_for_scan;
        private Command wayToPictureCommand;
        private Command wayToMusicCommand;
        private Command addUserCommand;
        public ICommand Select_dir_for_scan => select_dir_for_scan;
        public ICommand WayToMusicCommand => wayToMusicCommand;
        public ICommand WayToPictureCommand => wayToPictureCommand;
        public ICommand AddUserCommand => addUserCommand;

        private string music;
        private string picture = $"Assets\\NoPhoto.png";
        
        public MainWindowViewModel()
        {
            select_dir_for_scan = new DelegateCommand(Select_directory_for_scan_music);
            wayToMusicCommand = new DelegateCommand(SelectDirectoryForWayToMusic);
            wayToPictureCommand = new DelegateCommand(SelectDirectoryForwayToPicture);
            addUserCommand = new DelegateCommand(AddNewUserFromDatebase);

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

        public string Picture
        {
            get => picture;
            set
            {
                picture = value;
                OnPropertyChanged();

            }
        }

        public string Music
        {
            get => music;
            set
            {
                music = value;
                OnPropertyChanged();

            }
        }

        void Select_directory_for_scan_music()
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

        void SelectDirectoryForWayToMusic()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = @"C:\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Music = dialog.FileName;
            }
        }

        void SelectDirectoryForwayToPicture()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.InitialDirectory = @"C:";
            dialog.Title = "Please select an image file to encrypt.";

            if (dialog.ShowDialog() == true)
            {
                Picture = dialog.FileName;
            }
        }

        void AddNewUserFromDatebase()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
