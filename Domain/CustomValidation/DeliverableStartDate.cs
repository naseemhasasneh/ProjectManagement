using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.CustomValidation
{
    public class DeliverableStartDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var deliverable= (CreateDeliverableDto)validationContext.ObjectInstance;
            if (deliverable.StartDate < deliverable.PPStartDate)
            {
                return new ValidationResult(" Deliverable start Date should be greater than Project phase start Date");
            }
            return ValidationResult.Success;
        }
    }
}
