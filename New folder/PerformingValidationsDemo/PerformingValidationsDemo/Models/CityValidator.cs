using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PerformingValidationsDemo.Models
{
    public class CityValidator
    {
        public static ValidationResult IsCityValid(string City, ValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(City))
                return new ValidationResult("City cannot be Null or whiteSpace");
            if (City.ToLower().Equals("hyderabad") || City.ToLower().Equals("delhi"))
                return ValidationResult.Success;
            return new ValidationResult("City can only be Hyderabad or Delhi");
        }
    }
}