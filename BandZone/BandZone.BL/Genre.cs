using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandZone.PL;

namespace BandZone.BL
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreType { get; set; }


        public Genre(int genreId, string genreType)
        {
            this.GenreId = genreId;
            this.GenreType = genreType;
        }

        public bool Insert()
        {
            try
            {
                using (BandZoneEntities bze = new BandZoneEntities())
                {
                    tblGenre genre = new tblGenre();
                    genre.GenreId = bze.tblGenre.Any() ? bze.tblGenre.Max(p => p.GenreId) + 1 : 1;
                    genre.GenreType = this.GenreType;
                    this.GenreId = genre.GenreId;

                    bze.tblGenre.Add(genre);
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
                    if (GenreId >= 0)
                    {
                        tblGenre genre = bze.tblGenre.Where(g => g.GenreId == GenreId).FirstOrDefault();
                        if (genre != null)
                        {
                            genre.GenreType = this.GenreType;

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
                    if (GenreId >= 0)
                    {
                        tblGenre genre = bze.tblGenre.Where(g => g.GenreId == GenreId).FirstOrDefault();
                        if (genre != null)
                        {
                            this.GenreId = genre.GenreId;
                            this.GenreType = genre.GenreType;
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
                    if (GenreId >= 0)
                    {
                        tblGenre genre = bze.tblGenre.Where(p => p.GenreId == GenreId).FirstOrDefault();
                        if (genre != null)
                        {
                            bze.tblGenre.Remove(genre);

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

    public class GenreList : List<Genre>
    {
        public void Sort()
        {
            List<Genre> genre = this.OrderBy(p => p.GenreType).ToList();
            this.Clear();
            this.AddRange(genre);
        }

        public void Load()
        {
            try
            {
                BandZoneEntities bze = new BandZoneEntities();

                foreach (tblGenre genre in bze.tblGenre)
                {
                    // Make a Genre object 
                    Genre g = new Genre(genre.GenreId, genre.GenreType);
                    Add(g);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Load(int musicId)
        {
            BandZoneEntities bze = new BandZoneEntities();

            var genres = from mg in bze.tblMusicGenre
                         join g in bze.tblGenre on mg.GenreId equals g.GenreId
                         where mg.MusicianId == musicId
                         select new
                         {
                             g.GenreId,
                             g.GenreType
                         };
            foreach (var genre in genres)
            {
                Genre g = new Genre(genre.GenreId, genre.GenreType);
                Add(g);
            }
        }
    }
}

