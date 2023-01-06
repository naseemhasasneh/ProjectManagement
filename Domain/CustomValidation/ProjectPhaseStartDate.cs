using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.CustomValidation
{
    public class ProjectPhaseStartDate : ValidationAttribute
    {
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           var projectPhase= (CreateProjectPhaseDto)validationContext.ObjectInstance;
            if(projectPhase.ProjectStartDate > projectPhase.StartDate)
            {
                return new ValidationResult("projectPhase start Date should be greater than Project start Date");
            }
            //if (projectPhase.ProjectEndDate < projectPhase.EndDate)
            //{
            //    return new ValidationResult("projectPhase End Date should be less than  Project end Date");
            //}

            return ValidationResult.Success;

        }
    }
}
