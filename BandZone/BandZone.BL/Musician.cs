using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandZone.PL;

namespace BandZone.BL
{
    public class Musician
    {
        public Guid MusicianId { get; set; }
        [DisplayName("List of Bands and Musicians")]
        public string BandMusicianName { get; set; }
        public Guid SongId { get; set; }
        public string Phone { get; set; }
        public string ContactEmail { get; set; }
        public string Website { get; set; }
        public string ProfileImage { get; set; }
        public string LoginEmail { get; set; }
        public string Password { get; set; }  


    }

    //Branch Test
    // Tami doing a branch test - 
    // t his should be from Tami-test-branch
    // testing 
    // another test yay
    // testing remove of .vs
    // another test push 
    public class MusicianList : List<Musician>
    {
        public void Load()
        {
            try
            {
                using (BandZoneEntities dc = new BandZoneEntities())
                {
                    var results = dc.tblMusician;
                    foreach (tblMusician c in results)
                    {
                        Musician musician = new Musician
                        {
                            MusicianId = c.MusicianId,
                            BandMusicianName = c.BandMusicianName,
                            SongId = c.SongId != null ? (Guid)c.SongId : Guid.Empty,
                            Phone = c.Phone,
                            ContactEmail = c.ContactEmail,
                            Website = c.Website,
                            LoginEmail = c.LoginEmail,
                            Password = c.Password
                        };

                        this.Add(musician);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
