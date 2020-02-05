using System;
using System.Collections.Generic;
using System.Text;
using CarpoolApplication;
using CarpoolApplication.Services;
using CarpoolApplication.helper;

namespace CarpoolApplication.Models
{
    public class Destination : Address 
    {
        public int DistancefromStartPoint { get; set; }
              
    }
}
