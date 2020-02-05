using System;
using System.Collections.Generic;
using System.Text;
using CarpoolApplication;
using CarpoolApplication.Models;
using CarpoolApplication.helper;

namespace CarpoolApplication.Services
{
    public class UserServices
    {
        public List<User> ListofUsers = new List<User>();
        public User Login(string loginId, string password)
        {
            return ListofUsers.Find(user => (user.UserID == loginId) && (user.Password == password));

        }

        public void Create(string userID, string password, string name, string phoneNumber, string occupation, string mail)
        {
            User user = new User(userID, password, name, phoneNumber, occupation, mail);
            ListofUsers.Add(user);
        }
       
        public List<Vehicle> ViewVehicles(string userId)
        {
            User user = ListofUsers.Find(thisUser => thisUser.UserID == userId);
            if (user.Vehicles.Count > 0)
            {
                return user.Vehicles;
            }
            else
            {
                return null;
            }
        }
        public List<Ride> ViewRides(Information information,string userId)
        {
            User user =ListofUsers.Find(thisUser => thisUser.UserID == userId);
            List<Ride> Rides = new List<Ride>();
            foreach (Ride ride in information.Rides)
            {
                if (user.UserID == ride.UserID)
                {
                    Rides.Add(ride);
                }
            }
            if (Rides.Count > 0)
            {
                return Rides;
            }
            else
            {
                return null;
            }
            
        }
        public List<Booking> ViewBookings(string userId)
        {
            User user = ListofUsers.Find(thisUser => thisUser.UserID == userId);
            if (user.Bookings.Count > 0)
            {
                return user.Bookings;
            }
            else
            {
                return null;
            }
           
           
        }
       
      
    }
}
