using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.Model
{
    public class TrackViewMode : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
        public string Duration { get; set; }
        public int NumberOfAuditions { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
