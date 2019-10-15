using BandZone.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandZone.BL
{
    public class MusicianGenre
    {
        public int Id { get; set; }
        public int MusicianId { get; set; }
        public int GenreId { get; set; }

        public bool Insert()
        {
            try
            {
                using(BandZoneEntities bze = new BandZoneEntities())
                {
                    tblMusicGenre musicGenre = new tblMusicGenre();
                    musicGenre.Id = bze.tblMusicGenre.Any() ? bze.tblMusicGenre.Max(mg => mg.Id) + 1 : 1;
                    musicGenre.MusicianId = this.MusicianId;
                    musicGenre.GenreId = this.GenreId;

                    bze.tblMusicGenre.Add(musicGenre);
                    bze.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Update()
        {
            try
            {
                using (BandZoneEntities bze = new BandZoneEntities())
                {
                    if (Id >= 0)
                    {
                        tblMusicGenre musicGenre = bze.tblMusicGenre.Where(mg => mg.Id == Id).FirstOrDefault();
                        if (musicGenre != null)
                        {
                            musicGenre.MusicianId = this.MusicianId;
                            musicGenre.GenreId = this.GenreId;

                            return bze.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Row was not found.");
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
                using (BandZoneEntities bze = new BandZoneEntities())
                {
                    if (Id >= 0)
                    {
                        tblMusicGenre musicGenre = bze.tblMusicGenre.Where(mg => mg.Id == Id).FirstOrDefault();
                        if (musicGenre != null)
                        {
                            this.Id = musicGenre.Id;
                            this.MusicianId = musicGenre.MusicianId;
                            this.GenreId = musicGenre.GenreId;
                        }
                        else
                        {
                            throw new Exception("Row was not found.");
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
                using (BandZoneEntities bze = new BandZoneEntities())
                {
                    if (Id >= 0)
                    {
                        tblMusicGenre musicGenre = bze.tblMusicGenre.Where(mg => mg.Id == Id).FirstOrDefault();
                        if (musicGenre != null)
                        {
                            bze.tblMusicGenre.Remove(musicGenre);

                            return bze.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Row was not found.");
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
}

