using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.CustomValidation
{
    public class PaymentAmount : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var payment = (CreatePaymentDto)validationContext.ObjectInstance;
            if (payment.Amount > payment.ProjectAmount)
            {
                return new ValidationResult("Payment Amount should be less than project Amount");
            }
            return ValidationResult.Success;
        }
    }
}
