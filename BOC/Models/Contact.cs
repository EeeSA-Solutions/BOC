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
        public Guid ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phonenumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
    }
}