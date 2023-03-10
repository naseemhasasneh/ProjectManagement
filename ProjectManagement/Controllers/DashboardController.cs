using Microsoft.AspNetCore.Mvc;
using PMISBLayer.Repositories;
using ProjectManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IInvoiceRepository _InvoiceRepository;
        private readonly IClientRepository _clientRepository;

        public DashboardController( IProjectRepository repository, IInvoiceRepository invoiceRepository, IClientRepository clientRepository)
        {
            
            _projectRepository = repository;
            _InvoiceRepository = invoiceRepository;
            _clientRepository = clientRepository;
        }
        public IActionResult Index()
        {
            var cardsModel = new DashboardViewModel()
            {
                ProgressProjectsNumber = _projectRepository.GetInProgressProjects(),
                CompletedProjectsNumber = _projectRepository.GetCompletedProjects(),
                NotStartedProjectsNumber = _projectRepository.GetNotStartedProjects(),
                TotalProjectsAmount = _projectRepository.GetAllProjectsAmounts(),
                ProjectsTotalNumber = _projectRepository.GetProjectsNumber(),
                TotalInvoices = _InvoiceRepository.GetTotalInvoices(),
                ClientsNumber = _clientRepository.TotalClients(),
                carfoorProjectsNumber= _projectRepository.GetCarfoorProjectsNumber(),
                tajMallProjectsNumber= _projectRepository.GetTajMallProjectsNumber(),
                ZyadProjectsNumber= _projectRepository.GetZayadProjectsNumber()
            };
            return View(cardsModel);
        }
    }
}
