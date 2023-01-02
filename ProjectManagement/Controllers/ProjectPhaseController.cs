using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
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
    public class ProjectPhaseController : Controller
    {
        private readonly IProjectPhaseRepository _projectPhaseRepo;
        private readonly IProjectRepository _projectRepo;
        private readonly IPhaseRepository _phaseRepo;

        public ProjectPhaseController(IProjectPhaseRepository projectPhaseRepository,IProjectRepository projectRepository,IPhaseRepository phaseRepository)
        {
            _projectPhaseRepo = projectPhaseRepository;
            _projectRepo = projectRepository;
            _phaseRepo = phaseRepository;
             
    }
        public IActionResult Index()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var projectPhases = _projectPhaseRepo.GetProjectPhases(userId);
                return View(projectPhases);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
          
        }
        public JsonResult GetPhasessbyProjectId(int projectId)
        {
            var AllPhases = _phaseRepo.GetAllPhases();
            var projectPhases = _projectPhaseRepo.GetProjectPhasesByP(projectId);
            foreach (var pp in projectPhases)
            {
                if (AllPhases.Select(x => x.Id).Contains(pp.PhaseId))    // to check if the phase already created then remove it from All phases
                {                                                        //this loop to show only avalible phases in drop down menu based on the project we selected.
                    AllPhases.Remove(pp.Phase);
                }
            }
            return new JsonResult(AllPhases);
        }

        public IActionResult NewProjectPhase(CreateProjectPhaseDto projectPhase)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.projects = _projectRepo.GetManagerProjects(userId);
                return View();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProjectPhase(CreateProjectPhaseDto projectPhase)
        {
            try
            {
                if (ModelState.IsValid)      
                {
                    _projectPhaseRepo.CreateProjectPhase(projectPhase);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(NewProjectPhase),projectPhase);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
          
        }
        public IActionResult EditProjectPhase(int projectPhaseId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.projects = _projectRepo.GetManagerProjects(userId);
                ViewBag.phases = _phaseRepo.GetAllPhases();
                var projectPhase = _projectPhaseRepo.GetProjectPhase(projectPhaseId);
                return View(projectPhase);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
            
        }
        [HttpPost]
        public IActionResult UpdateProjectPhase(ProjectPhase updatedProjectPhase)
        {
            try
            {
                   _projectPhaseRepo.UpdateProjectPhase(updatedProjectPhase);
                   return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
            
        }

        public IActionResult DeleteProjectPhase(int projectPhaseId)
        {
            try
            {
                _projectPhaseRepo.DeleteProjectPhase(projectPhaseId);
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
