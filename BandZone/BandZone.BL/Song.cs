using BandZone.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandZone.BL
{
    public class Song
    { 
        public int SongId { get; set; }
        public string SongName { get; set; }

        public Song()
        {

        }

        public Song(int songId, string songName)
        {
            SongId = songId;
            SongName = songName;
        }



        public bool Insert()
        {
            try
            {
                using (BandZoneEntities bze = new BandZoneEntities())
                {
                    tblSong song = new tblSong();
                    song.SongId = bze.tblSong.Any() ? bze.tblSong.Max(s => s.SongId) + 1 : 1;
                    song.SongName = this.SongName;
                    this.SongId = song.SongId;

                    bze.tblSong.Add(song);
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
                    if (SongId >= 0)
                    {
                        tblSong song = bze.tblSong.Where(s => s.SongId == SongId).FirstOrDefault();
                        if (song != null)
                        {
                            song.SongName= this.SongName;

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
                    if (SongId >= 0)
                    {
                        tblSong song = bze.tblSong.Where(s => s.SongId == SongId).FirstOrDefault();
                        if (song != null)
                        {
                            this.SongId = song.SongId;
                            this.SongName = song.SongName;
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
                    if (SongId >= 0)
                    {
                        tblSong song = bze.tblSong.Where(s => s.SongId == SongId).FirstOrDefault();
                        if (song != null)
                        {
                            bze.tblSong.Remove(song);

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

    public class SongList : List<Song>
    {
        public void Load()
        {
            try
            {
                using(BandZoneEntities bze = new BandZoneEntities())
                {
                    foreach (tblSong song in bze.tblSong)
                    {
                        // create a song object
                        Song s = new Song(song.SongId, song.SongName);
                        Add(s);
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
