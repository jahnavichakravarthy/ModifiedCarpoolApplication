using System;
using System.Collections.Generic;
using System.Text;
using CarpoolApplication;
using CarpoolApplication.Services;
using CarpoolApplication.helper;


namespace CarpoolApplication.Models
{
    public class Address
    {
        public string Location { get; set; }
        public string Building { get; set; }
        public string LandMark { get; set; }
        public string AditionalInstruction { get; set; }
       

        //public Address() { }
        //public Address(Address address)
        //{
        //    Location = address.Location;
        //    Building = address.Building;
        //    LandMark = address.LandMark;
        //    AditionalInstruction = address.AditionalInstruction;
        //}
    }
}
