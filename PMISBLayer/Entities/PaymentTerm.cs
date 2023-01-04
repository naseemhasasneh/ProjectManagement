using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMISBLayer.Entities
{
    public class PaymentTerm
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "PaymentTerm Name is Required")]

        public string Name { get; set; }
        [Required(ErrorMessage = "PaymentTerm Amount is Required")]
        public double Amount { get; set; }
        public int DeliverableId { get; set; }
        public Deliverable Deliverable { get; set; }
        public List<InvoicePaymentTerm> InvoicePaymentTerms { get; set; }

    }
}
