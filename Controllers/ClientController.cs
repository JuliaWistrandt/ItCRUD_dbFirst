using ItAgency_bdCRUD.Models;
using ItAgency_bdCRUD.Service.Client;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace ItAgency_bdCRUD.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientServiceable _clientServiceable;
        private readonly ILogger<HomeController> _logger;
        public ClientController(IClientServiceable clientServiceable, ILogger<HomeController> logger)
        {
            _clientServiceable = clientServiceable;
            _logger = logger;
        }

      
        public IActionResult Index()
        {
            var clients = _clientServiceable.GetAllClient();
            
            return View(clients);
        }

        public IActionResult AddClientPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddClient(Client client)
        {
            _clientServiceable.AddClient(client);
            return RedirectToAction("Index");
        }

        public IActionResult SearchClientPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchClient([FromForm] int id)
        {
            var temp = _clientServiceable.GetByIdClient(id);
            if (temp == null)
            {
                return View("NotFoundPage");
            }
            else
            {

                return View("ClientDitailsPage", temp);
            }

        }

        public IActionResult ClientDitailsPage()
        {
            return View(_clientServiceable.GetByIdClient);
        }

        public IActionResult NotFoundPage()
        {
            return View();
        }

        public IActionResult DeleteClient(int id)
        {
            _clientServiceable.DeleteClient(id);
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
