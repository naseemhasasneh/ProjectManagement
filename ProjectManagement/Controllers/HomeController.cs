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
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProjectRepository _projectRepository;

        public HomeController(ILogger<HomeController> logger, IProjectRepository repository)
        {
            _logger = logger;
            _projectRepository = repository;
        }

        public IActionResult Index()
        { 
            var cardsModel = new CardsViewModel()
            {
                ProgressProjectsNumber = _projectRepository.GetInProgressProjects(),
                CompletedProjectsNumber = _projectRepository.GetCompletedProjects(),
                NotStartedProjectsNumber = _projectRepository.GetNotStartedProjects(),
                TotalProjectsAmount = _projectRepository.GetAllProjectsAmounts()

            };
            return View(cardsModel);
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
