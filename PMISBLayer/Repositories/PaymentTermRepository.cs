using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
    public class PaymentTermRepository : IPaymentTermRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentTermRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public void CreatePaymentTerm(PaymentTerm paymentTerm)
        {
            PaymentTerm NewPaymentTerm = new PaymentTerm()
            {
                Name = paymentTerm.Name,
                Amount = paymentTerm.Amount,
                DeliverableId = paymentTerm.DeliverableId
            };

            _context.PaymentTerms.Add(NewPaymentTerm);
            _context.SaveChanges();
        }

        public void DeletePaymentTerm(int paymentTermId)
        {
            var paymentToDelete = GetPaymentTerm(paymentTermId);
            _context.PaymentTerms.Remove(paymentToDelete);
            _context.SaveChanges();
        }

        public List<PaymentTerm> GetAllPayments(string userId)
        {
            return _context.PaymentTerms
                 .Include(p => p.Deliverable)
                 .ThenInclude(d => d.ProjectPhase)
                 .ThenInclude(pp => pp.Project)
                 .Where(p=>p.Deliverable.ProjectPhase.Project.ProjectManagerId==userId)
                 .ToList();
        }

        public PaymentTerm GetPaymentTerm(int paymentTermId)
        {
            return _context.PaymentTerms.SingleOrDefault(pt=>pt.Id==paymentTermId);
        }

        public List<PaymentTerm> GetPaymentTermsByDId(int deliverableId)
        {
            return _context.PaymentTerms.Include(p => p.Deliverable)
                .ThenInclude(d=>d.ProjectPhase)
                .ThenInclude(pp=>pp.Project)
                .Where(p => p.DeliverableId == deliverableId)
                .ToList();
        }

        public List<PaymentTerm> GetPaymentTermsByPId(int projectId)
        {
                var sql = $"exec GetPaymnets '{projectId}'";
                var paymnets= _context.PaymentTerms.FromSqlRaw(sql).ToList();
                foreach(var p in paymnets)
            {
                p.Deliverable = _context.Deliverables.Find(p.DeliverableId);
            };
            return paymnets;
            //return _context.PaymentTerms
            //    //.Include(p=>p.InvoicePaymentTerms)
            //    .Include(p => p.Deliverable)
            //    .ThenInclude(d => d.ProjectPhase)
            //    .Where(p =>p.Deliverable.ProjectPhase.ProjectId==projectId)
            //    .ToList();
        }

        public void UpdatePaymentTerm(PaymentTerm paymentTerm)
        {
            var pT = GetPaymentTerm(paymentTerm.Id);
            pT.Name = paymentTerm.Name;
            pT.Amount = paymentTerm.Amount;
            _context.SaveChanges();
        }
    }
}
