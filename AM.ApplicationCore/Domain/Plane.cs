using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType { Boeing, Airbus }
    public class Plane
    {
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }
        public ICollection<Flight> ListFlights { get; set; }
        public override string ToString()
        {
            return $"PlaneId: {PlaneId}, PlaneType: {PlaneType}, Capacity: {Capacity}, ManufactureDate: {ManufactureDate}";
        }
        public Plane(PlaneType pt, int capacity, DateTime date)
        {   
            this.PlaneType = pt ;
            this.Capacity = capacity;
            this.ManufactureDate = date;
        }

        public Plane()
        {
        }
    }
}
