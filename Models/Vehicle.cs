using System;
using System.Collections.Generic;
using System.Text;
using CarpoolApplication;
using CarpoolApplication.Services;
using CarpoolApplication.helper;

namespace CarpoolApplication.Models
{
    public class Vehicle
    {
        public string Type { get; set; }
        public int NoOfSeats { get; set; }
        public Vehicle() { }
        //public Vehicle(string type, int seats)
        //{
        //    Type = type;
        //    NoOfSeats = seats;
        //}
    }
}
