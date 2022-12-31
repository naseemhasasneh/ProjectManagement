﻿using Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
    public class ProjectPhaseRepository : IProjectPhaseRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectPhaseRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public void CreateProjectPhase(CreateProjectPhaseDto projectPhaseDto)
        {
            ProjectPhase projectPhase = new ProjectPhase()
            {
                ProjectId = projectPhaseDto.ProjectId,
                PhaseId = projectPhaseDto.PhaseId,
                StartDate = projectPhaseDto.StartDate,
                EndDate = projectPhaseDto.EndDate,
            };
            _context.ProjectPhases.Add(projectPhase);
            _context.SaveChanges();
        }

        public void DeleteProjectPhase(int projectPhaseId)
        {
            var projectPhaseToDeleted = _context.ProjectPhases.Find(projectPhaseId);
            _context.ProjectPhases.Remove(projectPhaseToDeleted);
            _context.SaveChanges();
        }

        public ProjectPhase GetProjectPhase(int projectPhaseId)
        {
            return _context.ProjectPhases.Find(projectPhaseId);
        }

        public List<ProjectPhase> GetProjectPhases(string userId)
        {
            return _context.ProjectPhases
                .Include(pp=>pp.Project)
                .Where(p=>p.Project.ProjectManagerId==userId)
                .Include(pp=>pp.Phase)
                .ToList();
        }

        public void UpdateProjectPhase(ProjectPhase updatedProjectPhase)
        {
            var projectPhase = GetProjectPhase(updatedProjectPhase.Id);
            projectPhase.ProjectId = updatedProjectPhase.ProjectId;
            projectPhase.PhaseId = updatedProjectPhase.PhaseId;
            projectPhase.StartDate = updatedProjectPhase.StartDate;
            projectPhase.EndDate = updatedProjectPhase.EndDate;
            _context.SaveChanges();
        }
    }
}
