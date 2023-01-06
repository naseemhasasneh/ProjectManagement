using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.CustomValidation
{
    public class ProjectPhaseEndDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var projectPhase = (CreateProjectPhaseDto)validationContext.ObjectInstance;
            
            if (projectPhase.ProjectEndDate < projectPhase.EndDate)
            {
                return new ValidationResult("projectPhase End Date should be earlier than  Project end Date");
            }
            if (projectPhase.StartDate > projectPhase.EndDate)
            {
                return new ValidationResult("project Phase End Date should be later than Project phase start Date");
            }

            return ValidationResult.Success;

        }
    }
}
