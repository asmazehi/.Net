﻿using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
////////atelier1

//Plane plane1 = new Plane();
//plane1.Capacity = 100;
//plane1.ManufactureDate = new DateTime(2024, 05, 23);
//plane1.PlaneType = PlaneType.Airbus;
//plane1.PlaneId = 1;
//Console.WriteLine(plane1.ToString());
//Plane plane2 = new Plane(PlaneType.Airbus, 200, DateTime.Now);
//Console.WriteLine(plane2.ToString());

//Plane plane3 = new Plane { 
//    ManufactureDate = DateTime.Now,
//    Capacity= 300,
//    PlaneId = 3,
//    PlaneType = PlaneType.Boeing,
//};
//Console.WriteLine(plane3.ToString());
//Plane plane4 = new Plane { };
//Console.WriteLine(plane4.ToString());
//Passenger passenger = new Passenger {FirstName="Asma" , LastName="Zehi" , EmailAddress="asma.zehi@esprit.tn"};
//Console.WriteLine(passenger.ToString());
//Console.WriteLine(passenger.CheckProfile("Asma", "Zehi"));
//Console.WriteLine(passenger.CheckProfile("Asma", "Zehi", "asma.zehi@esprit.tn"));
//Staff staff1 = new Staff {FirstName = "StaffFirstName", LastName = "StaffLastName" };
//Traveller traveller1 = new Traveller { Nationality = "Tunisian", FirstName = "TravellerFirstName" };
//passenger.PassengerType();
//staff1.PassengerType();
//traveller1.PassengerType();

////////atelier2


//question5
Console.WriteLine("-----------------------question 5-----------------------");
FlightMethods flightMethods = new FlightMethods
{
    Flights = TestData.listFlights
};

foreach (var item in flightMethods.GetFlightDates("Paris"))
{
    Console.WriteLine(item);
}
//question8
Console.WriteLine("-----------------------question 8-----------------------");
flightMethods.GetFlights("Destination","Paris");
//question 10
Console.WriteLine("-----------------------question 10-----------------------");
flightMethods.ShowFlightDetails(TestData.Airbusplane);
//question 11
Console.WriteLine("-----------------------question 11-----------------------");
Console.WriteLine(flightMethods.ProgrammedFlightNumber(new DateTime(2022, 02, 01, 21, 10, 10)));
//question 12
Console.WriteLine("-----------------------question 12-----------------------");
Console.WriteLine(flightMethods.DurationAverage("Paris"));
//question 13
Console.WriteLine("-----------------------question 13-----------------------");
foreach (var item in flightMethods.OrderedDurationFlights ())
{
    Console.WriteLine(item);
}
Console.WriteLine("-----------------------question 14-----------------------");
//foreach (var item in flightMethods.SeniorTravellers(TestData.flight1))
//{
//    Console.WriteLine(item);
//}
Console.WriteLine("-----------------------question 15-----------------------");
flightMethods.DestinationGroupedFlights();

Console.WriteLine("-----------------------question 16/17-----------------------");
flightMethods.FlightDetailsDel(TestData.Airbusplane);
Console.WriteLine("-----------------------question 16/17 avec delegate-----------------------");
flightMethods.FlightDetailsDel(TestData.Airbusplane);


Console.WriteLine("-----------------------tester la methode d extension-----------------------");
Passenger passenger = new Passenger { FullName = new FullName { FirstName = "Asma", LastName = "Zehi" }, EmailAddress = "asma.zehi@esprit.tn" };
Console.WriteLine("avant extension");
passenger.UpperFullName();
Console.WriteLine("apres extension");
Console.WriteLine(passenger.ToString());

Console.WriteLine("-----------------------test atelier 3-----------------------");
AMContext context = new AMContext();
context.Flights.Add(TestData.flight3);
context.SaveChanges();
foreach (var item in context.Flights)
{
    Console.WriteLine(item);
}
Console.WriteLine(context.Flights.First().MyPlane.Capacity);