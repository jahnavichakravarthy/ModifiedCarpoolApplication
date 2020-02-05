using System;
using System.Collections.Generic;
using System.Text;
using CarpoolApplication;
using CarpoolApplication.Models;
using CarpoolApplication.helper;

namespace CarpoolApplication.Services
{
    public class VehicleServices
    { 
        HelperMethods helperMethods = new HelperMethods();
        public void Create(List<Vehicle> vehicles)
        {
            Vehicle vehicle = new Vehicle();
            helperMethods.VehicleDetails(vehicle);
           vehicles.Add(vehicle);
        }
        public void Delete(string Cartype, List<Vehicle> vehicles)
        {
            Vehicle vehicle =vehicles.Find(SelectedVehicle => SelectedVehicle.Type == Cartype);
            vehicles.Remove(vehicle);
        }
        public List<Vehicle> View(List<Vehicle> vehicles,string userId)
        {
           
            if (vehicles.Count != 0)
            {
                return vehicles;
            }
            else
            {
                Console.WriteLine("Please add a car");

                Create(vehicles);
                
                return vehicles;
            }
        }
    }
}
