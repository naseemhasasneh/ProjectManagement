using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos
{
    public class CreateInvoiceDto
    {
        [Required(ErrorMessage = "Invoice Name is Required")]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Project Name is Required")]
        public int ProjectId { get; set; }
        public List<int> PaymentTermIds { get; set; }
      
    }
}
