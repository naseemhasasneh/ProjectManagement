using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class CreatePaymentDto
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public int DeliverableId { get; set; }
    }
}
