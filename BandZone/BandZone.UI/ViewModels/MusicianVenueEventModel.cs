using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BandZone.BL;

namespace BandZone.UI.ViewModels
{
    public class MusicianVenueEventModel
    {
        public BL.MusicianVenueEvent MusicianVenueEvent { get; set; }
        public MusicianList Musician { get; set; }
        public VenueList Venue { get; set; }
             
    }
}