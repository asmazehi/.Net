using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight> { }; //liste initialisee a 0

        //question16:
        public Action<Domain.Plane> FlightDetailsDel; //pointe vers une méthode qui prend un objet Plane en paramètre et ne retourne rien
        public Func<string, float> DurationAverageDel; //pointe vers une méthode qui prend une chaine de caractère en paramètre et qui retourne un réel

        //question 17
        public FlightMethods()
        {
            //question 17
            //FlightDetailsDel = ShowFlightDetails;
            //DurationAverageDel = DurationAverage;

            //question18:expression lambda mshit hzit nafs code taa ShowFlightDetails
            FlightDetailsDel=p => 
            {
                var query = from flight in Flights
                            where flight.MyPlane == p
                            select flight;
                foreach (var item in query)
                {
                    Console.WriteLine(item.FlightDate + item.Destination);
                }
            };
            //expression lambda mshit hzit nafs code taa DurationAverage
            DurationAverageDel = d =>
            {
                var query = from flight in Flights
                            where flight.Destination == d
                            select flight.EstimatedDuration;
                return query.Average();
            };
            //l fark bin l appel direct taa lfouk w heda howa anou hedi tekhdem b methode anonyme w mataayetch l fonction makhdouma deja
        }
        
        public IList<DateTime> GetFlightDates(string destination)
        {
            IList<DateTime> dates = new List<DateTime> { };
            //for(int i = 0; i < Flights.Count; i++) {
            //    if (Flights[i].Destination.Equals(destination))
            //    {
            //        dates.Add(Flights[i].FlightDate);
            //    }
            //}
            //foreach (var flight in Flights)
            //{
            //    if (flight.Destination.Equals(destination))
            //    {
            //        dates.Add(flight.FlightDate);
            //    }
            //}
            //return dates;


            //question 9: requete LINQ
            //var query = from flight in Flights
            //            where flight.Destination == destination
            //            select flight.FlightDate;
            //return query.ToList();

            //question 19:lambda
            var lambdaquery = Flights
                .Where(f => f.Destination == destination)
                .Select(f => f.FlightDate );
                return lambdaquery.ToList();
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (var flight in Flights)
                    {
                        if (flight.Destination.Equals(filterValue))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "FlightDate":
                    foreach (var flight in Flights)
                    {
                        if (flight.FlightDate.Equals(DateTime.Parse(filterValue)))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "EstimatedDuration":
                    foreach (var flight in Flights)
                    {
                        if (flight.EstimatedDuration== float.Parse(filterValue))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "Departure":
                    foreach (var flight in Flights)
                    {
                        if (flight.Departure.Equals(filterValue))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "EffectiveArrival":
                    foreach (var flight in Flights)
                    {
                        if (flight.EffectiveArrival == DateTime.Parse(filterValue))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
            }
        }

        public void ShowFlightDetails(Plane plane)
        {
            //var query = from flight in Flights
            //            where flight.MyPlane == plane
            //            select flight;
            //foreach (var item in query)
            //{
            //    Console.WriteLine(item.FlightDate + item.Destination);
            //}

            //question 19
            var lambdaquery =Flights

                .Where(f => f.MyPlane == plane)
                .Select(f => f); //optional
            foreach (var item in lambdaquery)
            { 
                Console.WriteLine(item.FlightDate+item.Destination);
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            ////methode 1
            //var query = from flight in Flights
            //            where DateTime.Compare(flight.FlightDate, startDate) > 0 && (flight.FlightDate-startDate).TotalDays > 7
            //            select flight;
            //return query.Count();

            //methode 2
            //var query = from flight in Flights
            //            where flight.FlightDate > startDate && flight.FlightDate < startDate.AddDays(7)
            //            select flight;
            //return query.Count();

            //question 19 
            var lambdaquery = Flights
                .Where(f => f.FlightDate >= startDate && f.FlightDate > startDate.AddDays(7));
            return lambdaquery.Count();

        }

        public float DurationAverage(string destination)
        {
            //var query = from flight in Flights
            //            where flight.Destination == destination
            //            select flight.EstimatedDuration;
            //return query.Average();

            //question 19
            var lambdaquery = Flights
                .Where(f => f.Destination == destination)
                .Select(f => f.EstimatedDuration);
            return lambdaquery.Average();
        }

        public IList<Flight> OrderedDurationFlights()
        {
            //var query = from flight in Flights
            //            orderby flight.EstimatedDuration descending
            //            select flight;
            //return query.ToList();

            //question 19
            var lambdaquery = Flights.OrderByDescending(f => f.EstimatedDuration);
            return lambdaquery.ToList();
        }

        //public IList<Traveller> SeniorTravellers(Flight flight)
        //{
        //    //var query = from passenger in flight.ListPassengers.OfType<Traveller>()
        //    //            orderby passenger.BirthDate ascending
        //    //            select passenger;
        //    //return query.Take(3).ToList();

        //    //question 19
        //    var lambdaquery = flight.ListPassengers.OfType<Traveller>()
        //        .OrderBy(p => p.BirthDate);
        //    return lambdaquery.Take(3).ToList();
        //}

        public void DestinationGroupedFlights()
        {
            //var query = from Flight in Flights
            //            group Flight by Flight.Destination;
            //foreach (var g in query)
            //{
            //    Console.WriteLine("Destination:" + g.Key);
            //    foreach (var item in g)
            //    {
            //        Console.WriteLine("Decollage :" + item.FlightDate);
            //    }
            //}

            //question 19
            var lambdaquery = Flights.GroupBy(f => f.Destination);
            foreach (var g in lambdaquery)
            {
                Console.WriteLine("Destination:" + g.Key);
                foreach (var item in g)
                {
                    Console.WriteLine("Decollage :" + item.FlightDate);
                }
            }
        }
    }
}
