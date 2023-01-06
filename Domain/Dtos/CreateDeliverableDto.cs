using Domain.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos
{
    public class CreateDeliverableDto
    {
        [Required(ErrorMessage = "Deliverable Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Deliverable Description is Required")]
        public string Description { get; set; }
        [DeliverableStartDate]
        public DateTime StartDate { get; set; }
        [DeliverableEndDate]
        public DateTime EndDate { get; set; }
        public DateTime PPStartDate { get; set; }
        public DateTime PPEndDate { get; set; }
        [Required]
        public int ProjectPhaseId { get; set; }
        public int projectId { get; set; }
    }
}
