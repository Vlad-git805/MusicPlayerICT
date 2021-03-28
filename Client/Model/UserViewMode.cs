using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.Model
{
    public class UserViewMode : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte Picture { get; set; }
        public string WayToSongs { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
