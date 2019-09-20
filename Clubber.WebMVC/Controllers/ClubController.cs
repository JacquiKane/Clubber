using Clubber.Models;
using Clubber.services;
using Clubber.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clubber.WebMVC.Controllers
{
    public class ClubController : Controller
    {
        public enum AllDays {Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday }

        private readonly Guid _userId;

        private ClubService CreateClubService(Guid userId)
        {
            var service = new ClubService(userId);
            return service;
        }
        private SponsorService CreateSponsorService(Guid userId)
        {
            var service = new SponsorService(userId);
            return service;
        }
        // GET: Clubs Index View
        public ActionResult Index()
        {
            var service = CreateClubService(_userId);
            var model =service.GetClubs();
            return View(model);
        }

        // GET: Create Club
        public ActionResult Create()
        {
            var service = CreateSponsorService(_userId);
            var myList = service.GetSponsors();
            ViewBag.SponsorId = new SelectList(myList.ToList(),
                                                "SponsorId",
                                                "FullName");
            var days = Enum.GetValues(typeof(AllDays));

            ViewBag.Days = new SelectList(days,
                                    "Days");
            var temp = ViewBag.CategoryID;
            return View();
        }

        //Add code here vvvv
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClubCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateClubService(_userId);

            if (service.CreateClub(model))
            {
                // ViewBag.SaveResult = "Your note was created";
                TempData["SaveResult"] = "This club was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "This club could not be created");

            return View();
        }



        public ActionResult Edit(int id)
        {
            var service = CreateClubService(_userId);
            var detail = service.GetClubById(id);
            var model =
                new ClubEdit
                {
                    ClubId = detail.ClubId,
                    Title = detail.Title,
                    MeetingDay = detail.MeetingDay,
                    MeetingTime = detail.MeetingTime,
                    SponsorId = detail.SponsorId,
                    Sponsor = detail.Sponsor
                };
            var sponsorService = CreateSponsorService(_userId);
            var myList = sponsorService.GetSponsors();
            ViewBag.SponsorId = new SelectList(myList.ToList(),
                                                "SponsorId",
                                                "FullName");
            var days = Enum.GetValues(typeof(AllDays));

            ViewBag.Days = new SelectList(days,
                                    "Days");
            var temp = ViewBag.CategoryID;
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClubEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ClubId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateClubService(_userId);

            if (service.UpdateClub(model))
            {
                TempData["SaveResult"] = "Your Club info was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your club info could not be updated.");
            return View(model);
        }



        public ActionResult Details(int id)
        {
            var svc = CreateClubService(_userId);
            var model = svc.GetClubById(id);

            return View(model);
        }



        public ActionResult Delete(int id)
        {
            var svc = CreateClubService(_userId);
            var model = svc.GetClubById(id);

            return View(model);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateClubService(_userId);


            service.DeleteClub(id);

            TempData["SaveResult"] = "Your Club was deleted, it is no more";

            return RedirectToAction("Index");
        }




    }
}