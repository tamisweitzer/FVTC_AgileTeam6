using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BandZone.BL;

namespace BandZone.UI.ViewModels
{
    public class SearchResult
    {
        public SearchType Type { get; set; }
        public MusicianList musicians { get; set; }
        public VenueList venues { get; set; }
        public SearchType SearchMode { get; set; }

        public SearchResult()
        {
            musicians = new MusicianList();
            venues = new VenueList();
        }
    }

    public enum SearchType
    {
        Musician,
        Venue
    }
}