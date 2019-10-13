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
        [DisplayName("Venue Name")]
        public string VenueName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [DisplayName("Business Opens")]
        public string OpenTime { get; set; }
        [DisplayName("Business Closes")]
        public string CloseTime { get; set; }
        [DisplayName("Contact Email")]
        public string ContactEmail { get; set; }
        public string Phone { get; set; }
        [DisplayName("Profile Image")]
        public string ProfileImage { get; set; }
        [DisplayName("Login Email")]
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
            venue.Address = this.Address;
            venue.City = this.City;
            venue.OpenTime = this.OpenTime;
            venue.CloseTime = this.CloseTime;
            venue.ContactEmail = this.ContactEmail;
            venue.Phone = this.Phone;
            venue.ProfileImage = this.ProfileImage;
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
                            venue.VenueName = this.VenueName;
                            venue.Address = this.Address;
                            venue.City = this.City;
                            venue.OpenTime = this.OpenTime;
                            venue.CloseTime = this.CloseTime;
                            venue.ContactEmail = this.ContactEmail;
                            venue.Phone = this.Phone;
                            venue.ProfileImage = this.ProfileImage;
                            venue.LoginEmail = this.LoginEmail;
                            //venue.Password = this.Password;
                            
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
                            this.VenueId = venue.VenueId;
                            this.VenueName = venue.VenueName;
                            this.Address = venue.Address;
                            this.City = venue.City;
                            this.OpenTime = venue.OpenTime;
                            this.CloseTime = venue.CloseTime;
                            this.ContactEmail = venue.ContactEmail;
                            this.Phone = venue.Phone;
                            this.ProfileImage = venue.ProfileImage;
                            this.LoginEmail = venue.LoginEmail;
                            
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


    public class VenueList : List<Venue>
    {
        public void Load()
        {
            try
            {
                using (BandZoneEntities dc = new BandZoneEntities())
                {
                    var results = dc.tblVenue;
                    foreach (tblVenue c in results)
                    {
                        Venue venue = new Venue
                        {
                            VenueId = c.VenueId,
                            VenueName = c.VenueName,
                            Address = c.Address,
                            City = c.City,
                            OpenTime = c.OpenTime,
                            CloseTime = c.CloseTime,
                            ContactEmail = c.ContactEmail,
                            Phone = c.Phone,
                            ProfileImage = c.ProfileImage,
                            LoginEmail = c.LoginEmail,
                            Password = c.Password
                        };

                        this.Add(venue);
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
