using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandZone.BL
{
    public class Musician
    {
        public Guid MusicianId { get; set; }
        public string BandMusicianName { get; set; }
        public Guid SongId { get; set; }
        public string Phone { get; set; }
        public string ContactEmail { get; set; }
        public string Website { get; set; }
        public string ProfileImage { get; set; }


    }
}
