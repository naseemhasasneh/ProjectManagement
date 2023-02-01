using AutoMapper;
using Domain.Dtos;
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
        private readonly IMapper _mapper;

        public ProjectPhaseRepository(ApplicationDbContext dbContext,IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public void CreateProjectPhase(CreateProjectPhaseDto projectPhaseDto)
        {
            ProjectPhase projectPhase = _mapper.Map<ProjectPhase>(projectPhaseDto);
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
        public List<ProjectPhase> GetProjectPhasesByP(int projectId)
        {
            return _context.ProjectPhases
                .Include(pp => pp.Phase)
                .Where(p => p.ProjectId==projectId)
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
