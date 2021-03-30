using Client.Model;
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
        private Command select_dir_for_scan;
        public ICommand Select_dir_for_scan => select_dir_for_scan;

        public List<MetaDataOfTrack> metaDataOfTracks = new List<MetaDataOfTrack>();

        public MainWindowViewModel()
        {
            select_dir_for_scan = new DelegateCommand(Select_directory_for_scan_music);
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
                    Meda_data_analys("D:\\Music_for_project\\" + fName);
                }
            });
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

        public void Meda_data_analys(string path)
        {
            MetaDataOfTrack track = new MetaDataOfTrack();
            TagLib.File tagFile = TagLib.File.Create(path);
            string album = tagFile.Tag.Album;
            string title = tagFile.Tag.Title;
            string[] qwe = tagFile.Tag.Artists;
            string artist = null;
            foreach (var item in qwe)
            {
                artist += item + " ";
            }
            string[] qwe2 = tagFile.Tag.Genres;
            string genres = null;
            foreach (var item in qwe2)
            {
                genres += item + " ";
            }
            TagLib.File f = TagLib.File.Create(path, TagLib.ReadStyle.Average);
            var duration = (int)f.Properties.Duration.TotalSeconds;
            var ts = TimeSpan.FromSeconds(duration);
            track.Albom = album;
            track.Artist = artist;
            track.Duration = new TimeSpan(ts.Hours, ts.Minutes, ts.Seconds);
            track.Ganre = genres;
            track.Name = title;
            metaDataOfTracks.Add(track);

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
