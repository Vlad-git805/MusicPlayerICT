using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DAL.Entities
{
    class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Suname { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
