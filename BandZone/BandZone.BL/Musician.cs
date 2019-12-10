using BandZone.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandZone.BL
{
    public class Musician
    {
        public int MusicianId { get; set; }
        [DisplayName("List of Bands and Musicians")]
        public string BandMusicianName { get; set; }
        public int SongId { get; set; }
        public string Phone { get; set; }
        [DisplayName("Contact Email")]
        public string ContactEmail { get; set; }
        public string Website { get; set; }
        [DisplayName("Profile Image")]
        public string ProfileImage { get; set; }
        [DisplayName("Login Email")]
        public string LoginEmail { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }

        public string Genre { get; set; }
        public GenreList Genres { get; set; }

        public Musician()
        {
            Genres = new GenreList();
        }

        public void LoadGenres()
        {
            try
            {
                Genres = new GenreList();
                Genres.LoadByMusicianId(this.MusicianId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Musician(string loginemail, string password)
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
            musician.SongId = this.SongId;
            musician.Phone = this.Phone;
            musician.ContactEmail = this.ContactEmail;
            musician.Website = this.Website;
            musician.ProfileImage = this.ProfileImage;
            musician.LoginEmail = this.LoginEmail;
            musician.Password = this.Password;
            musician.Description = this.Description;
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
                            //BandMusicianName = musician.BandMusicianName;
                            //Description = musician.Description;
                            //Phone = musician.Phone;
                            //Website = musician.Website;
                            //ContactEmail = musician.ContactEmail;
                            //LoginEmail = musician.LoginEmail;
                            //Password = musician.Password;

                            musician.BandMusicianName = this.BandMusicianName;
                            musician.SongId = this.SongId;
                            musician.Phone = this.Phone;
                            musician.ContactEmail = this.ContactEmail;
                            musician.Website = this.Website;
                            musician.ProfileImage = this.ProfileImage;
                            musician.LoginEmail = this.LoginEmail;
                            //musician.Password = this.Password;
                            musician.Description = this.Description;

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

                            this.MusicianId = musician.MusicianId;
                            this.BandMusicianName = musician.BandMusicianName;
                            this.SongId = Convert.ToInt32(musician.SongId);
                            this.Phone = musician.Phone;
                            this.ContactEmail = musician.ContactEmail;
                            this.Website = musician.Website;
                            this.ProfileImage = musician.ProfileImage;
                            this.LoginEmail = musician.LoginEmail;
                            this.Description = musician.Description;

                            LoadGenres();

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

        public bool Login()
        {
            try
            {
                if (!string.IsNullOrEmpty(LoginEmail))
                {
                    if (!string.IsNullOrEmpty(Password))
                    {
                        BandZoneEntities dc = new BandZoneEntities();
                        tblMusician musician = dc.tblMusician.FirstOrDefault(u => u.LoginEmail == LoginEmail);
                        if (musician != null)
                        {
                            if (musician.Password == GetHash())
                            {
                                // Successful login
                                this.MusicianId = musician.MusicianId;
                                this.BandMusicianName = musician.BandMusicianName;
                                this.SongId = Convert.ToInt32(musician.SongId);
                                this.Phone = musician.Phone;
                                this.ContactEmail = musician.ContactEmail;
                                this.Website = musician.Website;
                                this.ProfileImage = musician.ProfileImage;
                                this.Description = musician.Description;
                                return true;
                            }
                            else
                            {
                                throw new Exception("Email or password incorrect");
                            }
                        }
                        else
                        {
                            throw new Exception("User Id could not be found");
                        }
                    }
                    else
                    {
                        throw new Exception("Password needs to be set");
                    }
                }
                else
                {
                    throw new Exception("User Id needs to be set");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // comment for commit
    }



    public class MusicianList : List<Musician>
    {
        public void Load()
        {
            Load(null);
        }

        public void LoadMusician()
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

        public void Load(int? genreId)
        {
            try
            {
                using (BandZoneEntities dc = new BandZoneEntities())
                {
                    var results = (from m in dc.tblMusician
                                   join mg in dc.tblMusicGenre on m.MusicianId equals mg.MusicianId
                                   join g in dc.tblGenre on mg.GenreId equals g.GenreId
                                   where (mg.GenreId == genreId || genreId == null)
                                   orderby m.BandMusicianName
                                   select new
                                   {
                                       m.MusicianId,
                                       m.BandMusicianName,
                                       m.SongId,
                                       m.Phone,
                                       m.ContactEmail,
                                       m.Website,
                                       m.LoginEmail,
                                       m.Password,
                                       Genre = g.GenreType,
                                       GenreId = g.GenreId
                                   }).ToList();

                    foreach (var m in results)
                    {
                        Musician musician = new Musician();

                        musician.MusicianId = m.MusicianId;
                        musician.BandMusicianName = m.BandMusicianName;
                        musician.SongId = Convert.ToInt32(m.SongId);
                        musician.Phone = m.Phone;
                        musician.ContactEmail = m.ContactEmail;
                        musician.Website = m.Website;
                        musician.LoginEmail = m.LoginEmail;
                        musician.Password = m.Password;
                        musician.Genre = m.Genre;

                        if (this.Where(music => music.MusicianId == musician.MusicianId).Count() == 0)
                        {
                            Add(musician);
                        }
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

