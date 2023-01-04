using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PMISBLayer.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Invoice Name is Required")]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Project Name is Required")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public List<InvoicePaymentTerm> InvoicePaymentTerms { get; set; }
    }
}
