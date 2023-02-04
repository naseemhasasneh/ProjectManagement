using Microsoft.AspNetCore.Mvc;
using PMISBLayer.Entities;
using PMISBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepo;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepo = invoiceRepository;
        }
        [HttpGet]
        public ActionResult<List<Invoice>> Get()
        {
            return Ok(_invoiceRepo.GetInvoices());
        }

    }
}
