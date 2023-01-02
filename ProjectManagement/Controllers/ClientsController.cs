using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using PMISBLayer.Entities;
using PMISBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientRepository _clientRepo;

        public ClientsController(IClientRepository Repository)
        {
            _clientRepo = Repository;
        }
        public IActionResult Index()
        {
            try
            {
                var clients = _clientRepo.GetClients();
                return View(clients);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
           
        }
        public IActionResult NewClient()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }

        }
        public IActionResult CreateClient(CreateClientDto clientDto)
        {
            try
            {
                _clientRepo.CreateClient(clientDto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }

        }
        public IActionResult EditClient(int clientId)
        {
            try
            {
                var client = _clientRepo.GetClient(clientId);
                return View(client);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }

        }
        public IActionResult UpdateClient(Client client)
        {
            try
            {
                _clientRepo.UpdateClient(client);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }

        }
        public IActionResult DeleteClient(int clientId)
        {
            try
            {
                _clientRepo.DeleteClient(clientId);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }

        }
    }
}
