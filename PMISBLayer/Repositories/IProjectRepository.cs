using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace PMISBLayer.Repositories
{
    public interface IProjectRepository
    {
        List<Project> GetManagerProjects(string userId);
        Project GetProject(int projectId);
        List<Project> GetAllProjects();
        void CreateProject(CreateProjectDto projectDto);
        void UpdateProject(UpdateProjectDto projectDto);
        Byte[] GetContractBytes(CreateProjectDto projectDto);
        FileStreamResult ViewContract(int projectId);
        void DeleteProject(int projectId);
        void Save();
    }
}
