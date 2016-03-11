using MockingTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MockingTest.Entities;
using MockingTest.Models;

namespace MockingTest.Controllers
{
    public class HomeController : Controller
    {
        private IContactService _contactService;

        public HomeController(IContactService contactService)
        {
            this._contactService = contactService;
        }

        public ActionResult Index()
        {
            var contacts = _contactService.GetAllContacts();

            var viewModel = new List<ContactViewModel>(from contact in contacts
                                                       select new ContactViewModel()
                                                       {
                                                           Id = contact.Id,
                                                           Email = contact.Email,
                                                           FirstName = contact.FirstName,
                                                           LastName = contact.LastName
                                                       });
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}