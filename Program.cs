using System;
using CarpoolApplication.Models;
using CarpoolApplication.Services;
using CarpoolApplication.helper;
using System.Text;
using System.Collections.Generic;


namespace CarpoolApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            User user = new User();
            Information information = new Information();
            InformationServices informationServies = new InformationServices();
            RideServices rideServices = new RideServices();
            UserServices userServices = new UserServices();
            VehicleServices vehicleServices = new VehicleServices();
            BookingServices bookingServices = new BookingServices();
            ValidationServices validationServices = new ValidationServices();
            Dsiplayervices display = new Dsiplayervices();
            HelperMethods helperMethods = new HelperMethods();
            List<Ride> rides = new List<Ride>();
            List<Vehicle> vehicles = new List<Vehicle>();
            int option;
            display.Print("Welcome to Carpool Application");
            while (true)
            {

                display.Print("Choose an Option:\n\t1.Login\n\t2.Signup\n................................\nselect an option:  ");
                option = helperMethods.Option();

                switch (option)
                {
                    case 1:
                        while (true)
                        {
                            while (true)
                            {
                                string id;
                                display.Print("Please enter login id:  ");
                                string loginId = display.Scan();
                                display.Print("Please enter the password:  ");
                                string password = display.Scan();

                                try
                                {
                                    user = userServices.Login(loginId, password);
                                    id = user.UserID;
                                }
                                catch (NullReferenceException)
                                {
                                    id = null;
                                }
                                if (string.IsNullOrEmpty(id) == false)

                                {
                                    bool isLoggedOut = false;
                                    while (true)
                                    {
                                        display.Print("Choose an option\n\t1.Riding Services\n\t2.Booking Services\n\t3.View Profile\n\t4.Logout\n................................................\nSelect an option:  ");
                                        option = helperMethods.Option();

                                        switch (option)
                                        {
                                            case 1:
                                                display.Print("Choose an option\n\t1.Create a Ride(please add a car in view profile before ctreating)\n\t2.Approve requests\n\t3.Add Viapoints\n\t4.go back\n................................................\nSelect an option:  ");
                                                option = helperMethods.Option();
                                                switch (option)
                                                {
                                                    case 1:
                                                        {
                                                            bool state;
                                                            Ride ride = new Ride();
                                                            display.Print("please enter the details Ride creation:");
                                                            display.Print(".................................................");
                                                            display.Print("Your Vehicles");
                                                            vehicles = vehicleServices.View(user.Vehicles, id);
                                                            while (true)
                                                            {
                                                                display.Print("Your Vehicles");
                                                                foreach (Vehicle vehicle in vehicles)
                                                                {
                                                                    Console.WriteLine($"{vehicle.Type}");
                                                                }

                                                                display.Print("please enter the vehicle choosed");
                                                                string vehicleName = display.Scan();
                                                                ride.Vehicle = user.Vehicles.Find(a => a.Type == vehicleName);
                                                                try { state = string.IsNullOrEmpty(ride.Vehicle.Type); }
                                                                catch (NullReferenceException) { state = true; }
                                                                if (state == false)
                                                                {
                                                                    break;
                                                                }
                                                                else
                                                                {
                                                                    display.Print("the vehicle is not present in your List");
                                                                    continue;
                                                                }
                                                            }


                                                            ride.UserID = user.UserID;
                                                            while (true)
                                                            {
                                                                display.Print("Please enter price for km:");
                                                                try
                                                                {
                                                                    ride.Priceperkm = int.Parse(display.Scan());
                                                                    break;
                                                                }
                                                                catch (FormatException)
                                                                {
                                                                    display.Print("Check format of price");
                                                                }
                                                            }
                                                            display.Print("..........................");
                                                            display.Print("please enter the details for starting Address:");
                                                            helperMethods.ScanAddress(ride.StartAddress);
                                                            display.Print("..........................");
                                                            display.Print("please enter the details for Destination Address:");
                                                            helperMethods.ScanAddress(ride.Destination);
                                                            display.Print("..........................");
                                                            ride.Price = Convert.ToString(helperMethods.PriceEstimattion(ride));
                                                            Console.WriteLine("end to end price of ride is: {0}", ride.Price);
                                                            display.Print("..........................");
                                                            ride.RideID = rideServices.GenerateRideId(user.Name);
                                                            Console.WriteLine("the generated  ride Id is {0}", ride.RideID);

                                                            while (true)
                                                            {
                                                                display.Print("enter the date and time of departure in the form of dd/mm/yyyy HH:MM:");
                                                                while (true)
                                                                {try
                                                                    {
                                                                        ride.DepartureTime = DateTime.Parse(display.Scan());
                                                                        break;
                                                                    }
                                                                    catch (System.FormatException)
                                                                    {
                                                                        display.Print("Please check format");
                                                                        continue;
                                                                    }
                                                                    
                                                                }
                                                                if (validationServices.Time(Convert.ToString(ride.DepartureTime)) == true)
                                                                {
                                                                    break;
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("please enter the date format as HH:MM");
                                                                    continue;
                                                                }
                                                            }

                                                            while (true)
                                                            {
                                                                display.Print("Do you want to add via points\n1.Yes\n2.No");
                                                                option = helperMethods.Option();
                                                                switch (option)
                                                                {
                                                                    case 1:
                                                                        display.Print("..........................");
                                                                        display.Print("enter details for via point creation");
                                                                        helperMethods.ScanAddress(ride.Destination);
                                                                        display.Print("...................................");
                                                                        ride.Price = Convert.ToString(helperMethods.PriceEstimattion(ride));
                                                                        Console.WriteLine("end to end price of ride is{0}", ride.Price);
                                                                        ride.ListofViaPoints.Add(ride.ViaPoint);
                                                                        display.Print("a via point is created");
                                                                        continue;
                                                                    case 2: break;
                                                                    default:
                                                                        display.Print("invalid opton");
                                                                        continue;
                                                                }
                                                                break;
                                                            }
                                                            rideServices.Create(id, information, ride);
                                                            display.Print("a Ride is created\n.....................");
                                                        }
                                                        break;
                                                    case 2:

                                                        {
                                                            string rideId;
                                                            rides = userServices.ViewRides(information, id);
                                                            if (rides != null)
                                                            {
                                                                foreach (Ride ThisRide in rides)
                                                                {
                                                                    if (ThisRide.DepartureTime > DateTime.Now)
                                                                    {
                                                                        Console.WriteLine($"{ThisRide.RideID} {ThisRide.StartAddress.Location} {ThisRide.Destination.Location} {ThisRide.DepartureTime}");
                                                                    }
                                                                }
                                                                display.Print("..............................");
                                                                display.Print("please enter a valid ride id");
                                                                rideId = display.Scan();
                                                                Ride ride = rides.Find(SelectedRide => SelectedRide.RideID == rideId);
                                                                List<Booking> bookings = rideServices.ViewBookingRequest(ride);
                                                                if (bookings != null)
                                                                {
                                                                    foreach (Booking booking in bookings)
                                                                    {
                                                                        Console.WriteLine($"{booking.BookingId} {booking.FromAddress.Location} {booking.ToAddress.Location} {booking.SeatsRequired}");
                                                                    }
                                                                    display.Print("please enter a valid booking id");
                                                                    string bookingId = display.Scan();
                                                                    try { Booking booking = user.Bookings.Find(SelectedBooking => SelectedBooking.BookingId == bookingId); }
                                                                    catch (NullReferenceException) { display.Print("booking request is invalid \n......................."); }
                                                                    display.Print("do you want to approve request?\n\t1.Yes\n\t2.No\n\t3.May be Later");
                                                                    rideServices.Approve(bookingId, id, rideId, information);
                                                                    Console.WriteLine("the Changes are done to the Request!!!!!!!!");
                                                                    display.Print("................................");
                                                                    break;
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("NO BOOKINGS YET!!!!");
                                                                    Console.WriteLine("...........................");
                                                                    break;
                                                                }

                                                            }
                                                            else
                                                            {
                                                                display.Print("The Ride list is empty");
                                                                break;
                                                            }
                                                        }

                                                    default:
                                                        continue;
                                                }

                                                break;
                                            case 2:
                                                {
                                                    while (true)
                                                    {
                                                        display.Print("Choose an option\n\t1.find a Ride\n\t2.Booking status\n\t3.go back\n................................................\nSelect an option:  ");
                                                        try { option = int.Parse(display.Scan()); break; }
                                                        catch (FormatException) { display.Print("Check format of option"); }
                                                    }

                                                    switch (option)
                                                    {
                                                        case 1:

                                                            Booking booking = new Booking();
                                                            booking.UserID = user.UserID;
                                                            booking.BookingId = bookingServices.GenerateBooking(user.Name);
                                                            display.Print("..........................");
                                                            display.Print("please enter the details for satrting Address:");
                                                            helperMethods.ScanAddress(booking.FromAddress);
                                                            display.Print("..........................");
                                                            display.Print("please enter the details for Destination Address:");
                                                            helperMethods.ScanAddress(booking.ToAddress);
                                                            while (true)
                                                            {
                                                                display.Print("Please enter number of seats required");
                                                                try
                                                                {
                                                                    booking.SeatsRequired = int.Parse(display.Scan());
                                                                    break;
                                                                }
                                                                catch (FormatException)
                                                                {
                                                                    display.Print("Check format of distance");
                                                                }
                                                            }

                                                            display.Print("..........................");
                                                            display.Print("The Rides available are:");
                                                            bool isValid = false;

                                                            rides = informationServies.ViewAvailableRides(information, booking, isValid);
                                                            foreach (Ride ride in rides)
                                                            {
                                                                Console.WriteLine($"{ride.RideID} {ride.DepartureTime}{ride.StartAddress.Location}{ride.Destination.Location}");
                                                            }

                                                            display.Print("please selecte a ride by rideId :");
                                                            string rideId = display.Scan();
                                                            Ride SelectedRide = information.Rides.Find(ride => ride.RideID == rideId);
                                                            if (SelectedRide != null)
                                                            {
                                                                SelectedRide.Bookings.Add(booking);
                                                                user.Bookings.Add(booking);
                                                                display.Print("a booking Request is sent");
                                                            }

                                                            break;
                                                        case 2:
                                                            List<Booking> bookings = userServices.ViewBookings(id);
                                                            if (bookings != null)
                                                            {
                                                                foreach (Booking Thisbooking in bookings)
                                                                {
                                                                    Console.WriteLine($"{Thisbooking.BookingId} {Thisbooking.FromAddress.Location} {Thisbooking.ToAddress.Location} {Thisbooking.Approval}");
                                                                }
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("NO BOOKINGS YET!!!!");
                                                                Console.WriteLine("...........................");
                                                                break;
                                                            }

                                                        default:
                                                            break;
                                                    }
                                                }
                                                break;


                                            case 3:
                                                display.Print("Choose an option\n\t1.Update vehicle list\n\t2.view my vehicle list\n\t3.Display my offers\n\t4.Display my bookingsgs \nPlease select a option ");

                                                option = helperMethods.Option();
                                                switch (option)
                                                {
                                                    case 1:

                                                        display.Print("please select a option:\n1.Add a vehicle.\n2.Remove a vehicle");
                                                        option = helperMethods.Option();

                                                        switch (option)
                                                        {
                                                            case 1:
                                                                display.Print("Please enter car type:  ");
                                                                string carType = display.Scan();
                                                                display.Print("Please enter no of seats:  ");
                                                                int seatsnumber = int.Parse(display.Scan());
                                                                vehicleServices.Create(user.Vehicles);
                                                                display.Print("the car is added to the list  ");
                                                                display.Print("............................");
                                                                break;
                                                            case 2:
                                                                display.Print("Please enter car type:  ");
                                                                string vehicleType = display.Scan();
                                                                vehicleServices.Delete(vehicleType, user.Vehicles);
                                                                display.Print("the car is reemoved from the list  ");
                                                                display.Print("............................");
                                                                break;
                                                            default:
                                                                display.Print("inavlid option\n..........................");
                                                                continue;
                                                        }
                                                        break;
                                                    case 2:
                                                        vehicles = userServices.ViewVehicles(id);
                                                        if (vehicles != null)
                                                        {
                                                            foreach (Vehicle vehicle in vehicles)
                                                            {
                                                                Console.WriteLine($"{vehicle.Type}");
                                                            }
                                                            display.Print("............................");
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            display.Print("the vehicle list is empty!!!!");
                                                            break;
                                                        }
                                                    case 3:
                                                       rides= userServices.ViewRides(information, id);
                                                        if (rides != null)
                                                        {
                                                            foreach (Ride ThisRide in rides)
                                                            {
                                                                if (ThisRide.DepartureTime > DateTime.Now)
                                                                {
                                                                    Console.WriteLine($"{ThisRide.RideID} {ThisRide.StartAddress.Location} {ThisRide.Destination.Location} {ThisRide.DepartureTime}");
                                                                }
                                                            }
                                                            display.Print("..............................");
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            display.Print("The Ride list is empty");
                                                            break;
                                                        }


                                                    case 4:
                                                        List<Booking> bookings = userServices.ViewBookings(id);
                                                        if (bookings != null)
                                                        {
                                                            foreach (Booking booking in user.Bookings)
                                                            {
                                                                Console.WriteLine($"{booking.BookingId} {booking.UserID} {booking.FromAddress} {booking.ToAddress} {booking.SeatsRequired} ");

                                                            }

                                                            display.Print("............................");
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            display.Print("The Booking List is empty");
                                                            break;
                                                        }
                                                    default:
                                                        display.Print("inavlid option\n..........................");
                                                        continue;
                                                }
                                                break;

                                            case 4:
                                                {
                                                    while (true)
                                                    {

                                                        display.Print("Do you want to log out?\n1.yes\n2.No\n");
                                                        option = helperMethods.Option();

                                                        switch (option)
                                                        {
                                                            case 1:
                                                                isLoggedOut = informationServies.LogOut();
                                                                user = null;
                                                                display.Print("Logged out\n..................................................");
                                                                break;
                                                            case 2: break;
                                                            default:
                                                                display.Print("enter a valid option");
                                                                continue;
                                                        }
                                                        break;
                                                    }
                                                }
                                                break;
                                            default: break;
                                        }
                                        if (isLoggedOut == true)
                                            break;
                                        else
                                        {
                                            continue;
                                        }
                                    }

                                    break;
                                   
                                }
                                else
                                {
                                    display.Print("Please enter valid details\n....................................\n"); break;
                                }

                            }
                            break;
                        }
                        break;
                    case 2:
                        User CreatedUser = new User();
                        display.Print("Please enter login id:  ");
                        CreatedUser.UserID = display.Scan();
                        display.Print("Please enter the password:  ");
                        CreatedUser.Password = display.Scan();
                        display.Print("....................................................");
                        display.Print("Please enter name:  ");
                        CreatedUser.Name = display.Scan();
                        while (true)
                        {
                            display.Print("Please enter phoone:  ");
                            CreatedUser.PhoneNo = display.Scan();
                            if (validationServices.Phone(CreatedUser.PhoneNo) == true)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("please enter the correct format");
                                continue;
                            }
                        }

                        display.Print("Please enter occupation:  ");
                        CreatedUser.Occupation = display.Scan();
                        display.Print("Please enter mail:  ");
                        CreatedUser.Mail = display.Scan();
                        userServices.Create(CreatedUser.UserID, CreatedUser.Password, CreatedUser.Name, CreatedUser.PhoneNo, CreatedUser.Occupation, CreatedUser.Mail);
                        display.Print("User has been successfully created\n......................................");
                        break;
                    default:
                        display.Print("Unavailable option\n.............................................");
                        break;
                }

            }
        }
    }
}

