using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PMISBLayer.Repositories;
using ProjectManagement.Models;
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
        { //refactor viewbag to viewModel
            ViewBag.inProgress = _projectRepository.GetInProgressProjects();
            ViewBag.completed = _projectRepository.GetCompletedProjects();
            ViewBag.notStarted = _projectRepository.GetCompletedProjects();
            ViewBag.projectTotalAmounts = _projectRepository.GetAllProjectsAmounts();
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
