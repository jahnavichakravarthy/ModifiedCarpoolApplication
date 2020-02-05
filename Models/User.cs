using System;
using System.Collections.Generic;
using System.Text;
using CarpoolApplication;
using CarpoolApplication.Services;
using CarpoolApplication.helper;

namespace CarpoolApplication.Models
{
    public class User
    {
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Occupation { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string UserID { get; set; }
        public int Ratings { get; set; }
        public List<Booking> Bookings = new List<Booking>();
       // public List<Ride> Rides = new List<Ride>();
        public List<Vehicle> Vehicles = new List<Vehicle>();
        public User() { }
        public User(string userID, string password, string name, string phoneNumber, string occupation, string mail)
        {
            Name = name;
            PhoneNo = phoneNumber;
            Occupation = occupation;
            Mail = mail;
            UserID = userID;
            Password = password;

        }
      
    }
}
