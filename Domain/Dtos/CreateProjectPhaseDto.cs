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
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? ProjectStartDate { get; set; }
        public DateTime? ProjectEndDate { get; set; }

    }
}
