using System;
using System.Collections.Generic;
using System.Text;
using CarpoolApplication;
using CarpoolApplication.Models;

namespace CarpoolApplication.Services
{
    public class InformationServices

    {
        public bool LogOut()
        {
            return true;
        }
        public List<Ride> ViewAvailableRides(Information information, Booking booking,bool isValid)
        {
            List<Ride> rides = new List<Ride>();
           
            foreach (Ride ride in information.Rides)
            {
                if ((booking.FromAddress.Location == ride.StartAddress.Location && booking.ToAddress.Location == ride.Destination.Location))
                {
                    rides.Add(ride);
                }
                foreach (Address address in ride.ListofViaPoints)
                {
                    if (booking.FromAddress.Location == ride.StartAddress.Location && booking.ToAddress.Location == address.Location)
                    {
                        rides.Add(ride);
                    }
                    else if ((booking.FromAddress.Location == address.Location) && (booking.ToAddress.Location == ride.Destination.Location))
                    {
                        rides.Add(ride);
                    }
                    else if ((booking.FromAddress.Location == address.Location))
                    {
                        foreach (Address add in ride.ListofViaPoints)
                        {
                            rides.Add(ride);
                        }
                    }
                    else
                    {
                        isValid =false;
                    }
                }
            }
            return rides;
        }


    }
}

