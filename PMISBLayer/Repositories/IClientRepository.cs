using Domain.Dtos;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
    public interface IClientRepository
    {
        List<Client> GetClients();
        void CreateClient(CreateClientDto clientDto);
        Client GetClient(int clientId);
        void UpdateClient(Client client);
        void DeleteClient(int clientId);
    }
}
