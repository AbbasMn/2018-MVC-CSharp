using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Minimum18YearsIfAMemeberValidation: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // return base.IsValid(value, validationContext);

            var cust = (Customer)validationContext.ObjectInstance;

            // if (cust.MembershipTypeId == 0 || cust.MembershipTypeId == 1)  
            // MVC: for Free MembershipType (in database Id=1), doesnt check age

            if (cust.MembershipTypeId == MembershipType.UnKnown || cust.MembershipTypeId == MembershipType.FreeAsYouGo)  // MVC: Refactoring Magic Numbers solution
                return ValidationResult.Success;

            if (cust.Birthdate == null)
                return new ValidationResult("Birthdate is Requierd");

            var age = DateTime.Today.Year - cust.Birthdate.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old to have Gold, Boronz or Silver");
        }
    }
}