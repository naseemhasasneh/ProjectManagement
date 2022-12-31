using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
    public class PhaseRepository : IPhaseRepository
    {
        private readonly ApplicationDbContext _context;

        public PhaseRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public List<Phase> GetAllPhases()
        {
            return _context.Phases.ToList();
        }
    }
}
