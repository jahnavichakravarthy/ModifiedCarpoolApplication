using System;
using System.Collections.Generic;
using System.Text;
using CarpoolApplication;
using CarpoolApplication.Models;
using CarpoolApplication.helper;
namespace CarpoolApplication.Services
{
    public class RideServices
    {
      
        enum Status
        {
            Pending, ACCEPTED, REJECTED
        }

        public Ride Create(string userId, Information information, Ride ride)
        {
            
            information.Rides.Add(ride);
            return ride;
        }
        public void Approve(string id, string userId, string rideId, Information information)
        {
            HelperMethods helperMethods = new HelperMethods();
            Ride ride = information.Rides.Find(SelectedRide => SelectedRide.RideID == rideId);
            Booking booking = ride.Bookings.Find(SelectedRide => SelectedRide.BookingId == id);
           int option = helperMethods.Option();
            switch (option)
            {
                case 1:booking.Approval = Convert.ToString(Status.ACCEPTED);
                    break;
                case 2:
                    booking.Approval = Convert.ToString(Status.REJECTED);
                    break;
                default:
                    booking.Approval = Convert.ToString(Status.Pending);
                    break;
            }
          
            
      

        }

        public List<Booking> ViewBookingRequest(Ride ride)
        {
            if (ride.Bookings.Count != 0)
            {
                return ride.Bookings;
            }

            else
            {
                return null;
            }

        }
        
        public string GenerateRideId(string name)
        {
            int count = 0;
            foreach (char c in name)
            {
                count++;
            }
            if (count < 3)
            {
                for (int i = (3 - count); i > 0; i--)
                {
                    name = name + "0";
                }
            }
            name = name.Substring(0, 3);
            DateTime Date = DateTime.Now;
            string Minute = (Date.Minute / 10).ToString() + (Date.Minute % 10).ToString();
            string id = name + Minute;
            return id;
        }
       
    }
}
