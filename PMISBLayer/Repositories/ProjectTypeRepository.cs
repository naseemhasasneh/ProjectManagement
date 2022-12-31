using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
    public class ProjectTypeRepository : IProjectTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<ProjectType> GetProjectTypes()
        {
            return _context.ProjectTypes.ToList();
        }
    }
}
