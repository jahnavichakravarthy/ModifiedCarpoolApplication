using System;
using System.Collections.Generic;
using System.Text;
using CarpoolApplication;
using CarpoolApplication.Services;
using CarpoolApplication.helper;

namespace CarpoolApplication.Models
{
    public class Booking
    {
        public string UserID { get; set; }
        public Address ToAddress { get; set; }
        public Address FromAddress { get; set; }
        public string PaymentMethod { get; set; }
        public string BookingId { get; set; }
        public string Approval { get; set; }
        public enum Status
        {
            Pending, ACCEPTED, REJECTED
        }
        public int SeatsRequired { get; set; }
        public string RideId { get; set; }
        public Booking()
        {
            ToAddress = new Address();
            FromAddress = new Address();
            Approval = "Pending";
           
        }

}
}
