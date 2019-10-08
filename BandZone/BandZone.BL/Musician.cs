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
        public int MusicianId { get; set; }
        [DisplayName("List of Bands and Musicians")]
        public string BandMusicianName { get; set; }
        public int SongId { get; set; }
        public string Phone { get; set; }
        public string ContactEmail { get; set; }
        public string Website { get; set; }
        public string ProfileImage { get; set; }
        public string LoginEmail { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }

        public Musician()
        {

        }

        public Musician (string loginemail, string password)
        {
            LoginEmail = loginemail;
            Password = password;
        }

        public Musician(int musicianid,
                        string loginemail,
                        string password,
                        string bandmusicianname,
                        int songid,
                        string phone,
                        string contactemail,
                        string website,
                        string profileimage,
                        string description)
        {
            MusicianId = musicianid;
            LoginEmail = loginemail;
            Password = password;
            BandMusicianName = bandmusicianname;
            SongId = songid;
            Phone = phone;
            ContactEmail = contactemail;
            Website = website;
            ProfileImage = profileimage;
            Description = description;
        }

        public Musician(string loginemail,
                        string password,
                        string bandmusicianname,
                        int songid,
                        string phone,
                        string contactemail,
                        string website,
                        string profileimage,
                        string description)
        {
            LoginEmail = loginemail;
            Password = password;
            BandMusicianName = bandmusicianname;
            SongId = songid;
            Phone = phone;
            ContactEmail = contactemail;
            Website = website;
            ProfileImage = profileimage;
            Description = description;
        }

        private string GetHash()
        {
            using (var hash = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(Password);
                return Convert.ToBase64String(hash.ComputeHash(hashbytes));
            }
        }

        private void Map(tblMusician musician)
        {
            // Move the class data to the datarow object
            musician.MusicianId = this.MusicianId;
            musician.BandMusicianName = this.BandMusicianName;
            musician.LoginEmail = this.LoginEmail;
            musician.Password = this.Password;
        }

        public void Insert()
        {
            try
            {
                BandZoneEntities dc = new BandZoneEntities();
                tblMusician newmusician = new tblMusician();

                MusicianId = 1;
                Password = GetHash();
                if (dc.tblMusician.Any())
                {
                    MusicianId = dc.tblMusician.Max(u => u.MusicianId) + 1;
                }

                Map(newmusician);

                dc.tblMusician.Add(newmusician);
                dc.SaveChanges();
                dc = null;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Update()
        {
            try
            {
                using (BandZoneEntities dc = new BandZoneEntities())
                {
                    if (MusicianId >= 0)
                    {
                        tblMusician musician = dc.tblMusician.Where(d => d.MusicianId == MusicianId).FirstOrDefault();

                        if (musician != null)
                        {
                            BandMusicianName = musician.BandMusicianName;
                            Description = musician.Description;
                            Phone = musician.Phone;
                            Website = musician.Website;
                            ContactEmail = musician.ContactEmail;
                            LoginEmail = musician.LoginEmail;
                            Password = musician.Password;
                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Row was not found");
                        }
                    }
                    else
                    {
                        throw new Exception("Id is not set.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadById()
        {
            try
            {
                using (BandZoneEntities dc = new BandZoneEntities())
                {
                    if (MusicianId >= 0)
                    {
                        tblMusician musician = dc.tblMusician.Where(d => d.MusicianId == MusicianId).FirstOrDefault();

                        if (musician != null)
                        {
                            MusicianId = musician.MusicianId;
                            Description = musician.Description;
                            Phone = musician.Phone;
                            Website = musician.Website;
                            ContactEmail = musician.ContactEmail;
                        }
                        else
                        {
                            throw new Exception("Row was not found");
                        }
                    }
                    else
                    {
                        throw new Exception("Id is not set.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete()
        {
            try
            {
                using (BandZoneEntities dc = new BandZoneEntities())
                {
                    if (MusicianId >= 0)
                    {
                        tblMusician musician = dc.tblMusician.Where(d => d.MusicianId == MusicianId).FirstOrDefault();

                        if (musician != null)
                        {
                            dc.tblMusician.Remove(musician);
                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Row was not found");
                        }
                    }
                    else
                    {
                        throw new Exception("Id is not set.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

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
                            SongId = Convert.ToInt32(c.SongId),
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
