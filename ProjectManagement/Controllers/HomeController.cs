using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PMISBLayer.Repositories;
using ProjectManagement.Models;
using ProjectManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProjectRepository _projectRepository;
        private readonly IInvoiceRepository _InvoiceRepository;
        private readonly IClientRepository _clientRepository;

        public HomeController(ILogger<HomeController> logger, IProjectRepository repository, IInvoiceRepository invoiceRepository, IClientRepository clientRepository)
        {
            _logger = logger;
            _projectRepository = repository;
            _InvoiceRepository = invoiceRepository;
            _clientRepository = clientRepository;
        }

        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
