﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMISBLayer.Entities;
using PMISBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    [Authorize]
    public class PaymentTermsController : Controller
    {
        private readonly IPaymentTermRepository _paymentTermRepo;
        private readonly IDeliverableRepository _deliverableRepo;

        public PaymentTermsController(IPaymentTermRepository paymentTermRepository, IDeliverableRepository deliverableRepository)
        {
            _paymentTermRepo = paymentTermRepository;
            _deliverableRepo = deliverableRepository;
        }
        public IActionResult Index(int deliverableId)
        {
            try
            {
                if (TempData["deliverableId"] != null && deliverableId == 0)
                {
                    deliverableId = Convert.ToInt32(TempData["deliverableId"]);
                }
                var paymentTerms = _paymentTermRepo.GetPaymentTermsByDId(deliverableId);
                TempData["deliverableId"] = deliverableId;
                return View(paymentTerms);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
            
        }

        public IActionResult AllPayments()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var p = _paymentTermRepo.GetAllPayments(userId);
            return View(p);
        }

        public IActionResult NewPaymentTerm(PaymentTerm paymentTerm)
        {
            try
            {
                paymentTerm.DeliverableId = Convert.ToInt32(TempData["deliverableId"]);
                return View(paymentTerm);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
           
        }

        public IActionResult CreatePaymentTerm(PaymentTerm paymentTerm)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _paymentTermRepo.CreatePaymentTerm(paymentTerm);
                    TempData["deliverableId"] = paymentTerm.DeliverableId;
                    return RedirectToAction(nameof(Index));
                }

                else
                {
                    TempData["deliverableId"] = paymentTerm.DeliverableId;
                    return RedirectToAction(nameof(NewPaymentTerm), paymentTerm);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
            
        }
        public IActionResult EditPaymentTerm(int paymentTermId)
        {
            try
            {
                var paymentTerm = _paymentTermRepo.GetPaymentTerm(paymentTermId);
                return View(paymentTerm);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
            
        }
        public IActionResult UpdatePaymentTerm(PaymentTerm paymentTerm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _paymentTermRepo.UpdatePaymentTerm(paymentTerm);
                    TempData["deliverableId"] = paymentTerm.DeliverableId;
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["deliverableId"] = paymentTerm.DeliverableId;
                    return RedirectToAction(nameof(NewPaymentTerm), paymentTerm);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
        }

        public IActionResult DeletePaymentTerm(int paymentTermId)
        {
            try
            {
                _paymentTermRepo.DeletePaymentTerm(paymentTermId);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
           
        }
    }
}
