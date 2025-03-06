using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class FullName
    {
        [MaxLength(25, ErrorMessage = "longueur maximale est 25")]
        [MinLength(3, ErrorMessage = "longueur minimale est 3")]
        public string? FirstName { get; set; }
        [MaxLength(25, ErrorMessage = "longueur maximale est 25")]
        [MinLength(3, ErrorMessage = "longueur minimale est 3")]
        public string? LastName { get; set; }
    }
}
