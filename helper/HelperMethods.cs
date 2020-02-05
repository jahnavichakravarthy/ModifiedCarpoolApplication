using System;
using System.Collections.Generic;
using System.Text;
using CarpoolApplication;
using CarpoolApplication.Models;
using CarpoolApplication.Services;
using CarpoolApplication.helper;

namespace CarpoolApplication.helper
{
    public class HelperMethods
    {
        Dsiplayervices display = new Dsiplayervices();
        public void ScanAddress(Address address)
        {
            display.Print("please enter the Location:");
            address.Location = display.Scan();
            display.Print("Building:");
            address.Building = display.Scan();
            display.Print("Landamark:");
            address.LandMark = display.Scan();
            display.Print("Additional instruction:");
            address.AditionalInstruction = display.Scan();
            //return address;
        }
         public void ScanAddress(Destination destination)
        {
            display.Print("please enter the Location:");
            destination.Location = display.Scan();
            display.Print("Building:");
            destination.Building = display.Scan();
            display.Print("Landamark:");
            destination.LandMark = display.Scan();
            display.Print("Additional instruction:");
            destination.AditionalInstruction = display.Scan();
            //return destination;
        } public void VehicleDetails(Vehicle vehicle)
        {
            display.Print("Please enter car type:  ");
           vehicle.Type = display.Scan();
            display.Print("Please enter no of seats:  ");
            vehicle.NoOfSeats = int.Parse(display.Scan());
            //return destination;
        }
        

        public int PriceEstimattion(Ride ride)
        {
            while (true)
            {
                display.Print("Distance from starting point :");
                try
                {
                    ride.Destination.DistancefromStartPoint = int.Parse(display.Scan());
                    break;
                }
                catch (FormatException)
                {
                    display.Print("Check format of distance");
                }
            }
            return ((ride.Priceperkm * ride.Destination.DistancefromStartPoint));
            
        }
        public int Option()
        {
            int option;
            while (true)
            {
                try
                {
                    option = int.Parse(display.Scan());
                    display.Print("............................");
                    break;
                }
                catch (FormatException)
                {
                    display.Print("inavlid option\n..........................");
                    display.Print(".............................");
                   
                }

            }
            return option;
        }
    }
}
