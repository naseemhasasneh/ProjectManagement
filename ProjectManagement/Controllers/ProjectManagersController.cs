using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using PMISBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    public class ProjectManagersController : Controller
    {
        private readonly IProjectManagerRepository _managerRepo;

        public ProjectManagersController(IProjectManagerRepository managerRepository)
        {
            _managerRepo = managerRepository;
        }
        public IActionResult Index()
        {
            var projectManagers = _managerRepo.GetProjectManagers();
            return View(projectManagers);
        }
        public IActionResult NewProjectManager()
        {
            return View();
        }
        public async Task<IActionResult> CreateProjectManager(CreateManagerDto managerDto)
        {
            await _managerRepo.CreateProjectManager(managerDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
