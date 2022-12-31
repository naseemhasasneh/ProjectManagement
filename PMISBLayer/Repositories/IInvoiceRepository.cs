using Domain.Dtos;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
    public interface IInvoiceRepository
    {
        List<Invoice> GetInvoices();
        List<InvoicePaymentTerm> invoicePayments();
        List<Invoice> GetInvoices(string userId);
        void CreateInvoice(CreateInvoiceDto invoiceDto);
        Invoice GetInvoice(int invoiceId);
        void DeleteInvoice(int invoiceId);
    }
}
