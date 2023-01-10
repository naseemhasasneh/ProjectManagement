using Domain.Dtos;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PMISBLayer.Repositories
{
    public interface IProjectManagerRepository
    {
        List<ProjectManager> GetProjectManagers();
        Task CreateProjectManager(CreateManagerDto managerDto);
    }
}
