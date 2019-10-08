using BandZone.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandZone.BL
{
    public class Venue
    {
        public int VenueId { get; set; }
        public string VenueName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public string ContactEmail { get; set; }
        public string Phone { get; set; }
        public string ProfileImage { get; set; }
        public string LoginEmail { get; set; }
        public string Password { get; set; }

        private string GetHash()
        {
            using (var hash = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(Password);
                return Convert.ToBase64String(hash.ComputeHash(hashbytes));
            }
        }

        private void Map(tblVenue venue)
        {
            // Move the class data to the datarow object
            venue.VenueId = this.VenueId;
            venue.VenueName = this.VenueName;
            venue.LoginEmail = this.LoginEmail;
            venue.Password = this.Password;
        }

        public void Insert()
        {
            try
            {
                BandZoneEntities dc = new BandZoneEntities();
                tblVenue newVenue = new tblVenue();

                VenueId = 1;
                Password = GetHash();
                if (dc.tblMusician.Any())
                {
                    VenueId = dc.tblVenue.Max(v => v.VenueId) + 1;
                }

                Map(newVenue);

                dc.tblVenue.Add(newVenue);
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
                    if (VenueId >= 0)
                    {
                        tblVenue venue = dc.tblVenue.Where(v => v.VenueId == VenueId).FirstOrDefault();

                        if (venue != null)
                        {
                            Phone = venue.Phone;
                            ContactEmail = venue.ContactEmail;
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
                    if (VenueId >= 0)
                    {
                        tblVenue venue = dc.tblVenue.Where(v => v.VenueId == VenueId).FirstOrDefault();

                        if (venue != null)
                        {
                            VenueId = venue.VenueId;
                            Phone = venue.Phone;
                            ContactEmail = venue.ContactEmail;
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
                    if (VenueId >= 0)
                    {
                        tblVenue venue = dc.tblVenue.Where(v => v.VenueId == VenueId).FirstOrDefault();

                        if (venue != null)
                        {
                            dc.tblVenue.Remove(venue);
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
}
