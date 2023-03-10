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
    [Authorize(Roles = "PROJECT MANAGER")]
    public class DeliverablesController : Controller
    {
        private readonly IDeliverableRepository _deliverableRepo;
        private readonly IPhaseRepository _phaseRepo;
        private readonly IProjectRepository _projectRepo;
        private readonly IProjectPhaseRepository _projectPhaseRepo;

        public DeliverablesController(IDeliverableRepository repository, IPhaseRepository phaseRepository, IProjectRepository projectRepository, IProjectPhaseRepository projectPhaseRepository)
        {
            _deliverableRepo = repository;
            _phaseRepo = phaseRepository;
            _projectRepo = projectRepository;
            _projectPhaseRepo = projectPhaseRepository;
        }
        public IActionResult Index(int projectId)
        {
            try
            {
                if (TempData["ProjectId"] != null)
                {
                    projectId = (int)TempData["ProjectId"];
                }

                var project = _projectRepo.GetProject(projectId);
                ViewBag.deliverables = _deliverableRepo.GetDeliverablesByProject(projectId);
                return View(project);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
           
        }

        public IActionResult AllDeliverables()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var d = _deliverableRepo.GetDeliverables(userId);
            return View(d);
        }

        public JsonResult GetProjectPhase(int projectPhaseId)
        {
            var projectPhase = _projectPhaseRepo.GetProjectPhase(projectPhaseId);
            return new JsonResult(projectPhase);
        }

        public IActionResult NewDeliverable(int projectId)
        {
            try
            {
                if (TempData["ProjectId"] != null)
                {
                    projectId = (int)TempData["ProjectId"];
                }
                ViewBag.project = _projectRepo.GetProject(projectId);
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDeliverable(CreateDeliverableDto deliverableDto)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _deliverableRepo.CreateDeliverable(deliverableDto);
                    TempData["ProjectId"] = deliverableDto.projectId;
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ProjectId"] = deliverableDto.projectId;
                    ViewBag.project = _projectRepo.GetProject(deliverableDto.projectId);
                    //deliverableDto.ProjectPhaseId = 0; //when data is not valid , make the user choose his phase again.
                    return View(nameof(NewDeliverable),deliverableDto);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
           
        }
        
        public IActionResult EditDeliverable(int deliverableId)
        {
            try
            {
                var deliverable = _deliverableRepo.GetDeliverable(deliverableId);
                return View(deliverable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
           
        }
        [HttpPost]
        public IActionResult UpdateDeliverable(UpdateDeliverableDto updateDeliverable)
        {
            try
            {
                _deliverableRepo.UpdateDeliverable(updateDeliverable);
                TempData["ProjectId"] = updateDeliverable.projectId;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
           
        }

        public IActionResult DeleteDeliverable(int deliverableId,int projectId)
        {
            try
            {
                _deliverableRepo.DeleteDeliverable(deliverableId);
                TempData["ProjectId"] = projectId;
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
