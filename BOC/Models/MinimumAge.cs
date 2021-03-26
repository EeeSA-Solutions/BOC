using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOC.Models
{
    public class MinimumAge : ValidationAttribute
    {
        private int Limit;
        public MinimumAge(int Limit)
        {
            this.Limit = Limit;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime bday = DateTime.Parse(value.ToString());
            DateTime today = DateTime.Today;
            int age = today.Year - bday.Year;
            if (bday > today.AddYears(-age))
            {
                age--;
            }
            if (age < Limit)
            {
                var result = new ValidationResult("16 års gräns tyvärr");
                return result;
            }


            return null;

        }
    }
}