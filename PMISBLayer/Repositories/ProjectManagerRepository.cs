using Domain.Dtos;
using Microsoft.AspNetCore.Identity;
using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMISBLayer.Repositories
{
    public class ProjectManagerRepository : IProjectManagerRepository
    {
        private readonly ApplicationDbContext _context;
        private UserManager<Person> _userManager;

        public ProjectManagerRepository(ApplicationDbContext context, UserManager<Person> usermanager)
        {
            _context = context;
            _userManager = usermanager;
        }
        public async Task CreateProjectManager(CreateManagerDto managerDto)
        {
            ProjectManager projectManager = new ProjectManager()
            {
                FullName = managerDto.FullName,
                Email = managerDto.Email,
                UserName = managerDto.Email,
                EmailConfirmed = true,
            };
            await _userManager.CreateAsync(projectManager, managerDto.Password);
            await _userManager.AddToRoleAsync(projectManager, Helper.ProjectManager);
        }

        public List<ProjectManager> GetProjectManagers()
        {
            return _context.ProjectManagers.ToList();
        }
    }
}
