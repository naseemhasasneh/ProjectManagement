using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class CreateInvoiceDto
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int ProjectId { get; set; }
        public List<int> PaymentTermIds { get; set; }
      
    }
}
