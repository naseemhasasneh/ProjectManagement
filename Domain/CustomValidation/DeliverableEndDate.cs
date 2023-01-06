using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.CustomValidation
{
    public class DeliverableEndDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var deliverable = (CreateDeliverableDto)validationContext.ObjectInstance;
            if (deliverable.EndDate > deliverable.PPEndDate)
            {
                return new ValidationResult(" Deliverable End Date should be earlier than Project phase End Date");
            }
            if (deliverable.StartDate > deliverable.EndDate)
            {
                return new ValidationResult(" Deliverable End Date should be greater than Deliverable Start Date");
            }
            return ValidationResult.Success;
        }
    }
}
