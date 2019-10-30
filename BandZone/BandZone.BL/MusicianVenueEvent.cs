using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BandZone.PL;

namespace BandZone.BL
{
    public class MusicianVenueEvent
    {
        public int Id { get; set; }
        [DisplayName("Musician ID")]
        public int MusicianId { get; set; }
        public string BandMusicianName { get; set; }
        [DisplayName("Venue ID")]
        public int VenueId { get; set; }
        public string VenueName { get; set; }
        [DisplayName("Time / Date of Event")]
        [DataType(DataType.Date)]
        //public DateTime? EventDateTime { get; set; }
        //public DateTime EventDateTime { get; set; }
        public string EventTime { get; set; }
        public string EventHour { get; set; }

        public bool Insert()
        {
            try
            {
                using (BandZoneEntities bze = new BandZoneEntities())
                {
                    tblMusicianVenueEvent musicianVenueEvent = new tblMusicianVenueEvent();
                    musicianVenueEvent.Id = bze.tblMusicianVenueEvent.Any() ? bze.tblMusicianVenueEvent.Max(mve => mve.Id) + 1 : 1;
                    musicianVenueEvent.MusicianId = this.MusicianId;
                    musicianVenueEvent.VenueId = this.VenueId;
                    musicianVenueEvent.EventTime = this.EventTime;
                    musicianVenueEvent.EventHour = this.EventHour;
                    bze.tblMusicianVenueEvent.Add(musicianVenueEvent);
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
                        tblMusicianVenueEvent musicianVenueEvent = bze.tblMusicianVenueEvent.Where(mve => mve.Id == Id).FirstOrDefault();
                        if (musicianVenueEvent != null)
                        {
                            musicianVenueEvent.MusicianId = this.MusicianId;
                            musicianVenueEvent.VenueId = this.VenueId;
                            musicianVenueEvent.EventTime = this.EventTime;
                            musicianVenueEvent.EventHour = this.EventHour;
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
                        var muVE = (from mve in bze.tblMusicianVenueEvent
                                       join m in bze.tblMusician on mve.MusicianId equals m.MusicianId
                                       join v in bze.tblVenue on mve.VenueId equals v.VenueId
                                       where mve.Id == this.Id
                                       select new
                                       {
                                           mve.Id,
                                           mve.MusicianId,
                                           mve.VenueId,
                                           mve.EventTime,
                                           mve.EventHour,
                                           m.BandMusicianName,
                                           v.VenueName
                                       }).FirstOrDefault();

                        if (muVE != null)
                        {
                            this.Id = muVE.Id;
                            this.MusicianId = muVE.MusicianId;
                            this.VenueId = muVE.VenueId;
                            this.EventTime = muVE.EventTime;
                            this.EventHour = muVE.EventHour;
                            this.BandMusicianName = muVE.BandMusicianName;
                            this.VenueName = muVE.VenueName;

                        }



                        tblMusicianVenueEvent musicianVenueEvent = bze.tblMusicianVenueEvent.Where(mve => mve.Id == Id).FirstOrDefault();
                        if (musicianVenueEvent != null)
                        {
                            this.Id = musicianVenueEvent.Id;
                            this.MusicianId = musicianVenueEvent.MusicianId;
                            this.VenueId = musicianVenueEvent.VenueId;
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
                        tblMusicianVenueEvent musicianVenueEvent = bze.tblMusicianVenueEvent.Where(mve => mve.Id == Id).FirstOrDefault();
                        if (musicianVenueEvent != null)
                        {
                            bze.tblMusicianVenueEvent.Remove(musicianVenueEvent);

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


    public class MusicianVenueEventList : List<MusicianVenueEvent>
    {
        public void Load()
        {
            try
            {
                BandZoneEntities dc = new BandZoneEntities();
                
                    var results = (from mve in dc.tblMusicianVenueEvent
                                   join m in dc.tblMusician on mve.MusicianId equals m.MusicianId
                                   join v in dc.tblVenue on mve.VenueId equals v.VenueId
                                   
                                   select new
                                   {
                                       mve.Id,
                                       mve.MusicianId,
                                       mve.VenueId,
                                       mve.EventTime,
                                       mve.EventHour,
                                       m.BandMusicianName,
                                       v.VenueName
                                   }).ToList();

                    foreach (var p in results)
                    {
                        // Make a ProgDec object 
                        MusicianVenueEvent musicianVenueEvent = new MusicianVenueEvent();

                        // Fill the progDec object properties
                        // from values in the table
                        musicianVenueEvent.Id = p.Id;
                        musicianVenueEvent.MusicianId = p.MusicianId;
                        musicianVenueEvent.VenueId = p.VenueId;
                        musicianVenueEvent.EventTime = p.EventTime;
                        musicianVenueEvent.EventHour = p.EventHour;
                        musicianVenueEvent.BandMusicianName = p.BandMusicianName;
                        musicianVenueEvent.VenueName = p.VenueName;

                        // Add it to the ProgDecList (myself)
                        Add(musicianVenueEvent);

                    }
                }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}






