using Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Invoice> GetInvoices()
        {
            return _context.Invoices
               .Include(I => I.InvoicePaymentTerms)
               .ThenInclude(IP => IP.PaymentTerm)
               .ThenInclude(p => p.Deliverable)
               .ThenInclude(d => d.ProjectPhase)
               .ThenInclude(pp => pp.Project)
               .ToList();
        }
        public void CreateInvoice(CreateInvoiceDto invoiceDto)
        {
            Invoice invoice = new Invoice()
            {
                Title = invoiceDto.Title,
                Date = invoiceDto.Date,
                ProjectId=invoiceDto.ProjectId 
            };
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
            foreach (var paymentid in invoiceDto.PaymentTermIds)
            {
                InvoicePaymentTerm invoicePayment = new InvoicePaymentTerm()
                {
                    InvoiceId = invoice.Id,
                    PaymentTermId = paymentid
                };
                _context.InvoicePaymentTerms.Add(invoicePayment);
                _context.SaveChanges();
            }
            
        }

        public void DeleteInvoice(int invoiceId)
        {
            var invoiceToDelete = _context.Invoices.Find(invoiceId);
            _context.Invoices.Remove(invoiceToDelete);
            _context.SaveChanges();
        }

        public Invoice GetInvoice(int invoiceId)
        {
            return _context.Invoices
                .Include(i=>i.Project)
                .ThenInclude(p=>p.Client)
                .Include(I=>I.InvoicePaymentTerms)
                .ThenInclude(IP=>IP.PaymentTerm)
                .ThenInclude(p=>p.Deliverable)
                .SingleOrDefault(I => I.Id == invoiceId);
        }

        public List<Invoice> GetInvoices(string userId)
        {
            //refactor
            var allInovices = _context.Invoices
                .Include(I => I.InvoicePaymentTerms)
                .ThenInclude(IP => IP.PaymentTerm)
                .ThenInclude(p => p.Deliverable)
                .ThenInclude(d => d.ProjectPhase)
                .ThenInclude(pp => pp.Project)
                .ToList();
            List<Invoice> userInvoices = new List<Invoice>();
            ;
            foreach(var invoice in allInovices)
            {
                var invoicePayments = invoice.InvoicePaymentTerms.ToList();
                foreach (var pi in invoicePayments)
                {
                    if (pi.PaymentTerm.Deliverable.ProjectPhase.Project.ProjectManagerId == userId)
                    {
                        userInvoices.Add(invoice);
                    }
                }
               
            }
            return userInvoices.Distinct().ToList();    // we use distinct because we won't to duplicate invoice in index view;
        }

        public List<InvoicePaymentTerm> invoicePayments()
        {
             return _context.InvoicePaymentTerms.ToList();
        }
    }
}
