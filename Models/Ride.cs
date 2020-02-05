using System;
using System.Collections.Generic;
using System.Text;
using CarpoolApplication;
using CarpoolApplication.Services;
using CarpoolApplication.helper;

namespace CarpoolApplication.Models
{
    public class Ride
    {
        public string UserID { get; set; }
        public Address StartAddress { get; set; }
        public int Priceperkm { get; set; }

        public Destination Destination { get; set; }
        public Destination ViaPoint { get; set; }
        public string RideID { get; set; }
        public DateTime DepartureTime { get; set; }
        public Vehicle Vehicle { get; set; }
        public List<Booking> Bookings = new List<Booking>();//must be private
        //public List<Booking> ApprovedBookings = new List<Booking>();
        public List<Address> ListofViaPoints = new List<Address>();
        // public Ride() { }
        public Ride(Ride ride)
        {

            UserID = ride.UserID;
            StartAddress = ride.StartAddress;
            Destination = ride.Destination;
            RideID = ride.RideID;
            DepartureTime = ride.DepartureTime;
            Vehicle = ride.Vehicle;
        }
        public Ride()
        {
            StartAddress = new Address();
            Destination = new Destination();

            ViaPoint = new Destination();


        }

        public string Price { get; set; }

    }
}
