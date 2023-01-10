using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMISBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    [Authorize(Roles = "PROJECT MANAGER")]
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository _projectRepo;
        private readonly IProjectTypeRepository _projectTypeRepo;
        private readonly IProjectStatusRepository _projectStatusRepo;
        private readonly IPhaseRepository _phaseRepo;
        private readonly IClientRepository _clientRepo;
        public ProjectsController(IProjectRepository repository, IProjectTypeRepository typeRepository, IProjectStatusRepository statusRepository, IPhaseRepository phaseRepository, IClientRepository clientRepository)
        {
            _projectRepo = repository;
            _projectTypeRepo = typeRepository;
            _projectStatusRepo = statusRepository;
            _phaseRepo = phaseRepository;
            _clientRepo = clientRepository;
        }
        public IActionResult Index()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var projects = _projectRepo.GetManagerProjects(userId);
                return View(projects);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
            
        }        
        public IActionResult NewProject()
        {
            try
            {
                ViewBag.projectTypes = _projectTypeRepo.GetProjectTypes();
                ViewBag.projectStatus = _projectStatusRepo.GetProjectStatus();
                ViewBag.clients = _clientRepo.GetClients();
                return View();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
           
        }
        [HttpPost]
        public IActionResult CreateProject(CreateProjectDto projectDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _projectRepo.CreateProject(projectDto);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(NewProject));
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
           
        }
        public IActionResult EditProject(int projectId)
        {
            try
            {
                ViewBag.projectTypes = _projectTypeRepo.GetProjectTypes();
                ViewBag.projectStatus = _projectStatusRepo.GetProjectStatus();
                var project = _projectRepo.GetProject(projectId);
                return View(project);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
            
        }

        public IActionResult UpdateProject(UpdateProjectDto projectDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _projectRepo.UpdateProject(projectDto);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(EditProject),projectDto.Id);
                }
               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
           
        }

        public IActionResult DeleteProject(int projectId)
        {
            try
            {
                _projectRepo.DeleteProject(projectId);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
            
        }
        public FileStreamResult ViewContract(int projectId)
        {

            var viewContract = _projectRepo.ViewContract(projectId);
            return viewContract;

        }
    }
}
