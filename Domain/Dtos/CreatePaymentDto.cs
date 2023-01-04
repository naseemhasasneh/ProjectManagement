using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos
{
    public class CreatePaymentDto
    {
        [Required(ErrorMessage = "PaymentTerm Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "PaymentTerm Amount is Required")]
        public double Amount { get; set; }
        public int DeliverableId { get; set; }
    }
}
