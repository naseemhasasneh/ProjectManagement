using Domain.Dtos;
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

        public void CreateClient(CreateClientDto clientDto)
        {
            Client Newclient = new Client()
            {
                Name = clientDto.Name,
                Email = clientDto.Email,
                Address=clientDto.Address,
                PhoneNumber=clientDto.PhoneNumber
            };
            _context.Clients.Add(Newclient);
            _context.SaveChanges();
        }

        public void DeleteClient(int clientId)
        {
            var clientToDelete = GetClient(clientId);
            _context.Clients.Remove(clientToDelete);
            _context.SaveChanges();
        }

        public Client GetClient(int clientId)
        {
            var client = _context.Clients.Find(clientId);
            return client;
        }

        public List<Client> GetClients()
        {
            return _context.Clients.ToList();
        }

        public void UpdateClient(Client client)
        {
            var clientToUpdate = _context.Clients.Find(client.Id);
            clientToUpdate.Name = client.Name;
            clientToUpdate.Email = client.Email;
            clientToUpdate.Address = client.Address;
            clientToUpdate.PhoneNumber = client.PhoneNumber;
            _context.SaveChanges();
        }
    }
}
