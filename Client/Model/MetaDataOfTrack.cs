using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class MetaDataOfTrack
    {
        public string Name { get; set; }
        public string Albom { get; set; }
        public string Artist { get; set; }
        public string Ganre { get; set; }
        public TimeSpan Duration { get; set; }

        public override string ToString()
        {
            return Name + " " + Albom + " " + Artist + " " + Ganre + " " + Duration.ToString();
        }
    }
}
