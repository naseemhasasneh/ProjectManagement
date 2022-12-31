using Domain.Dtos;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
    public interface IProjectPhaseRepository
    {
        ProjectPhase GetProjectPhase(int projectPhaseId);
        List<ProjectPhase> GetProjectPhases(string userId);
        List<ProjectPhase> GetProjectPhasesByP(int projectId);
        void CreateProjectPhase(CreateProjectPhaseDto projectPhaseDto);
        void UpdateProjectPhase(ProjectPhase updatedProjectPhase);
        void DeleteProjectPhase(int projectPhaseId);
    }
}
