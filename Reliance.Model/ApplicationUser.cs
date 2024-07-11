using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Reliance.Model
{
   public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get { return string.Concat(FirstName, " ", LastName); } }

        public string? ImagePath { get; set; }

        public string? Gender { get; set; }

        public string? Nationality { get; set; }

        public string? ResidentialAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
  
    }
}
