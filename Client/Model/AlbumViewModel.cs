using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.Model
{
    public class AlbumDTO : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Picture { get; set; }
        public int ArtistId { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
