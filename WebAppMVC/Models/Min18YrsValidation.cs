using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMVC.Models
{
    public class Min18YrsValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //initialize validation context
            var customer = (Customer)validationContext.ObjectInstance;

            //using our static fields, check if membership id is PayAsYouGo
            if (customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if(customer.BirthDate == null)
            {
                return new ValidationResult("Birthdate is Required");
            }
            var age = DateTime.Today.Year - customer.BirthDate.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer must be at least 18 years of age to go on a membership.");
        }
    }
}