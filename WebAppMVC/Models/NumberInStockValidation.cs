using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebAppMVC.Models
{
    public class NumberInStockValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //create an object of the context data and cast it to the type
            var movie = (Movie)validationContext.ObjectInstance;

            //arbitrary value to test custom validation
            if (!(movie.noInStock >= Movie.MinimumAmount && movie.noInStock <= Movie.MaximumAmount))
            {
                string msg = string.Format("Amount must be between {0} and {1}", Movie.MinimumAmount, Movie.MaximumAmount);
                return new ValidationResult(msg);
            }
            else
                return ValidationResult.Success;
        }
    }
}