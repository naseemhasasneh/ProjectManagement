using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMISBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    [Authorize(Roles = "PROJECT MANAGER")]
    public class InvoicesController : Controller
    {
        private readonly IInvoiceRepository _invoiceRepo;
        private readonly IPaymentTermRepository _paymentTermRepo;
        private readonly IProjectRepository _projectRepo;

        public InvoicesController(IInvoiceRepository invoiceRepository, IPaymentTermRepository paymentTermRepository, IProjectRepository projectRepository)
        {
            _invoiceRepo = invoiceRepository;
            _paymentTermRepo = paymentTermRepository;
            _projectRepo = projectRepository;
        }
        public IActionResult Index()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var invoices = _invoiceRepo.GetInvoices(userId);
                return View(invoices);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }

        }
        public JsonResult GetPaymentsbyProjectId(int projectId)
        {
                var payments = _paymentTermRepo.GetPaymentTermsByPId(projectId);
                return new JsonResult(payments);
        }
        public JsonResult GetInvoice(int invoiceId)
        {
            var invoice = _invoiceRepo.GetInvoice(invoiceId);
            return new JsonResult(invoice);
        }
        public IActionResult NewInvoice()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.projects = _projectRepo.GetManagerProjects(userId);
                ViewBag.invoicePayments = _invoiceRepo.invoicePayments();
                return View();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
            
        }

        public IActionResult CreateInvoice(CreateInvoiceDto invoiceDto)
        {
            try
            {
                _invoiceRepo.CreateInvoice(invoiceDto);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
           
        }

        public IActionResult ViewInvoice(int invoiceId)
        {
            try
            {
                var invoice = _invoiceRepo.GetInvoice(invoiceId);
                return View(invoice);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
        }

        public IActionResult DeleteInvoice(int invoiceId)
        {
            try
            {
                _invoiceRepo.DeleteInvoice(invoiceId);
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
