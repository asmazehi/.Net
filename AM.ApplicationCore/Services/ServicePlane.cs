using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        IUnitOfWork unitOfWork;
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IList<Traveller> GetPassengers(Plane plane)
        {
            //IList<Traveller> passengers = new List<Traveller>();
            //foreach (var flight in plane.ListFlights)
            //{
            //    foreach (var passenger in flight.ListPassengers)
            //    {
            //        if (passenger is Traveller traveller && !passengers.Contains(traveller))
            //        {
            //            passengers.Add(traveller);
            //        }
            //    }
            //}
            //return passengers;

            return GetById(plane.PlaneId)
                .ListFlights
                .SelectMany(f => f.ListTickets)
                .Select(t => t.MyPassenger)
                .OfType<Traveller>()
                .Distinct()
                .ToList();
        }
    }
}
