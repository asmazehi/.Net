using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //public int Id { get; set; }
        [Display(Name ="Date of birth")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }
        [MaxLength (25,ErrorMessage ="longueur maximale est 25") ]
        [MinLength(3, ErrorMessage = "longueur minimale est 3")]
        public string? FirstName { get; set; }
        [MaxLength(25, ErrorMessage = "longueur maximale est 25")]
        [MinLength(3, ErrorMessage = "longueur minimale est 3")]
        public string? LastName { get; set; }
        [Key]
        [StringLength (7)]
        public string? PassportNumber { get; set; }
        [RegularExpression(@"^[0-9]{8}$")]
        public string? TelNumber { get; set; }
        public ICollection<Flight> MyFlightss { get; set; }
        public override string ToString()
        {
            return $"FirstName: {FirstName}, LastName: {LastName}, PassportNumber: {PassportNumber}, BirthDate: {BirthDate}, Email: {EmailAddress}, Tel: {TelNumber}";
        }
        //public bool CheckProfile(String FirstName, String Lastname)
        //{
        //    return this.FirstName == FirstName && this.LastName == LastName;
        //}
        //public bool CheckProfile(String FirstName, String Lastname, String Email)
        //{
        //    return this.FirstName == FirstName && this.LastName==LastName && this.EmailAddress==Email ;
        //}
        public bool CheckProfile(String FirstName, String Lastname, String Email = null)
        {
            if (Email == null)
            {
                return this.FirstName == FirstName && this.LastName == LastName;
            }
            else 
            {
                return this.FirstName == FirstName && this.LastName == LastName && this.EmailAddress == Email;
            }
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }
    }
}
