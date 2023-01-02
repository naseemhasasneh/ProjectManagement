using Domain.CustomValidation;
using PMISBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace PMISBLayer.Entities
{
    public class ProjectPhase
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Project Name is Required")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        [Required(ErrorMessage = "Phase Name is Required")]
        public int PhaseId { get; set; }
        public Phase Phase { get; set; }
        [ProjectPhaseDates]
        public DateTime? StartDate { get; set; }
        [ProjectPhaseDates]
        public DateTime? EndDate { get; set; }
    }
}
