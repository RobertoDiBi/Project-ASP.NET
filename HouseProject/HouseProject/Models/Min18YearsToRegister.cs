using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseProject.Models
{
    public class Min18YearsToRegister : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (RegisterViewModel)validationContext.ObjectInstance;
            var birthdate = user.Birthdate;
            DateTime now = DateTime.Today;
            int age = now.Year - birthdate.Year;
            if (birthdate > now.AddYears(-age)) age--;

            return (age >= 18) ? 
                ValidationResult.Success : 
                new ValidationResult("You must be at least 18 years old to register.");
        }
    }
}