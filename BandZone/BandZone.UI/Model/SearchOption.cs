using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BandZone.BL;

namespace BandZone.UI.Model
{
    public class SearchDropDown
    {
        public SearchType Type { get; set; }
    }

    public enum SearchType
    {
        Musician,
        Venue
    }
}