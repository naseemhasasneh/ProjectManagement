using Domain.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Domain.Dtos
{
    public class CreateProjectPhaseDto
    {
        [Required(ErrorMessage = "Project Name is Required")]
        public int ProjectId { get; set; }
        [Required(ErrorMessage = "Phase Name is Required")]
        public int PhaseId { get; set; }
        [ProjectPhaseDates]
        public DateTime? StartDate { get; set; }
        [ProjectPhaseDates]
        public DateTime? EndDate { get; set; }
        public DateTime? ProjectStartDate { get; set; }
        public DateTime? ProjectEndDate { get; set; }

    }
}
