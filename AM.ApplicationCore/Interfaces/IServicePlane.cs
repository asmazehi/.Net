using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane : IService<Plane>
    {
        IList<Traveller> GetPassengers(Plane plane);
        public IList<Flight> getNFlightsOrderedByDate(int n);
        public void deleteOldFlight(Flight flight);
    }
}
