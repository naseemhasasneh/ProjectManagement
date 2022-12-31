using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
    public interface IPaymentTermRepository
    {
        List<PaymentTerm> GetPaymentTermsByDId(int deliverableId);
        List<PaymentTerm> GetPaymentTermsByPId(int projectId);
        List<PaymentTerm> GetAllPayments(string userId);
        void CreatePaymentTerm(PaymentTerm paymentTerm);
        PaymentTerm GetPaymentTerm(int paymentTermId);
        void UpdatePaymentTerm(PaymentTerm paymentTerm);
        void DeletePaymentTerm(int paymentTermId);
     
    }
}
