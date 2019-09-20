using Clubber.Data;
using Clubber.Models;
using Clubber.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clubber.WebMVC.Controllers
{
    public class SponsorController : Controller
    {
        private readonly Guid _userId;

        private SponsorService CreateSponsorService(Guid userId)
        {
            var service = new SponsorService(userId);
            return service;
        }
        // GET: Sponsor
        public ActionResult Index()
        {
            SponsorService service = CreateSponsorService(_userId);
            var model = service.GetSponsors();

            return View(model);
        }

        // GET: Create Sponsor
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SponsorCreateView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateSponsorService(_userId);

            if (service.CreateSponsor(model))
            {
                // ViewBag.SaveResult = "Your sponsor was created";
                TempData["SaveResult"] = "Your sponsor was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Sponsor could not be created");

            return View();
        }

 
    }
}