using BandZone.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandZone.BL
{
    public class SongGenre
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public int GenreId { get; set; }



        public bool Insert()
        {
            try
            {
                using (BandZoneEntities bze = new BandZoneEntities())
                {
                    tblSongGenre songGenre = new tblSongGenre();
                    songGenre.Id = bze.tblSongGenre.Any() ? bze.tblSongGenre.Max(sg => sg.Id) + 1 : 1;
                    songGenre.SongId = this.SongId;
                    songGenre.GenreId = this.GenreId;

                    bze.tblSongGenre.Add(songGenre);
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
                        tblSongGenre songGenre = bze.tblSongGenre.Where(sg => sg.Id == Id).FirstOrDefault();
                        if (songGenre != null)
                        {
                            songGenre.SongId = this.SongId;
                            songGenre.GenreId = this.GenreId;

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
                        tblSongGenre songGenre = bze.tblSongGenre.Where(sg => sg.Id == Id).FirstOrDefault();
                        if (songGenre != null)
                        {
                            this.Id = songGenre.Id;
                            this.SongId = songGenre.SongId;
                            this.GenreId = songGenre.GenreId;
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
                        tblSongGenre songGenre = bze.tblSongGenre.Where(sg => sg.Id == Id).FirstOrDefault();
                        if (songGenre != null)
                        {
                            bze.tblSongGenre.Remove(songGenre);

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
