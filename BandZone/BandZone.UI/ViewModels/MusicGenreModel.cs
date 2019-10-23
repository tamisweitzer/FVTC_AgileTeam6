using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BandZone.BL;

namespace BandZone.UI.ViewModels
{
    public class MusicGenreModel
    {
        public Musician Musician { get; set; }
        //List of all genres
        public GenreList Genres { get; set; }

        //List of the all pre-existing genres (Ids)
        public IEnumerable<int> GenreIds { get; set; }

    }
}