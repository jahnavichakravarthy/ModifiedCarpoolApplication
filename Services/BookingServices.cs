using System;
using System.Collections.Generic;
using System.Text;
using CarpoolApplication;
using CarpoolApplication.Models;
using CarpoolApplication.helper;

namespace CarpoolApplication.Services
{
    public class BookingServices
    {
        public string GenerateBooking(string name)
        {
            if (name.Length< 3)
            {
                for (int i = (3 - name.Length) ; i > 0; i--)
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
