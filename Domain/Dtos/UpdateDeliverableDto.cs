using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos
{
    public class UpdateDeliverableDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Deliverable Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Deliverable Name is Required")]
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int projectId { get; set; }
    }
}
