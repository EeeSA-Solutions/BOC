using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOC.Models
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Måste va mindre än 20 tecken")]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Måste va mindre än 20 tecken")]
        public string Lastname { get; set; }

        
        [Required]
        [DataType(DataType.Date)]
        [MinimumAge(16)]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Måste vara nummer")]
        public string Phonenumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Compare("Email", ErrorMessage = "Matchar inte mailen")]
        public string ValidateEmail { get; set; }

        [Required]
        public string Address { get; set; }
    }
}