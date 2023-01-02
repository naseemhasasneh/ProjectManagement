using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public List<Client> GetClients()
        {
            return _context.Clients.ToList();
        }
    }
}
