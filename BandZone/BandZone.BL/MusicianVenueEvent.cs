using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandZone.BL
{
    public class MusicianVenueEvent
    {
        public int Id { get; set; }
        [DisplayName("Musician ID")]
        public int MusicianId { get; set; }
        [DisplayName("Venue ID")]
        public int VenueId { get; set; }
        [DisplayName("Time / Date of Event")]
        public DateTime EventDateTime { get; set; }

        // TODO
        // Insert()
        // LoadById()
        // Update()
        // Delete
    }


    // TODO  ?
    // public class MusicianVenueEventList : List<MusicianVenueEvent> {}


}
