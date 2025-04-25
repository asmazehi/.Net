using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        public IUnitOfWork unitOfWork;
        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public bool IsAvailable(Flight flight, int n)
        {

            int capacity = flight.MyPlane.Capacity;
            int tickets = flight.ListTickets.Count;

            return n >= capacity - tickets;
        }

        public IList<Staff> GetStaff(int id)
        {
            Flight flight = GetById(id);
            return flight.ListTickets
                .Select(t => t.MyPassenger)
                .OfType<Staff>()
                .Distinct()
                .ToList();
        }
    }
}
