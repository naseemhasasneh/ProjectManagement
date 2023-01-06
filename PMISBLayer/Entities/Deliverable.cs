using Domain.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMISBLayer.Entities
{
    public class Deliverable
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Deliverable Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Deliverable Description is Required")]
        public string Description { get; set; }
        [DeliverableStartDate]
        public DateTime StartDate { get; set; }
        [DeliverableEndDate]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Phase Name is Required")]
        public int ProjectPhaseId { get; set; }
        public ProjectPhase ProjectPhase { get; set; }
    }
}
