using Clubber.Models;
using Clubber.services;
using Clubber.WebMVC.Models;
using Microsoft.AspNet.Identity;
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
 

        private ClubService CreateClubService(Guid _userId)
        {
            var service = new ClubService(_userId);
            return service;
        }


        private StudentProfileService CreateStudentProfileService(Guid userId)
        {
            var service = new StudentProfileService(userId);
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
            var res = HttpContext.User.IsInRole("Admin");
            var _userId = Guid.Parse(User.Identity.GetUserId());
            var service = CreateClubService(_userId);
            var profileService = CreateStudentProfileService(_userId);
            ViewBag.HasProfile = profileService.hasStudentProfile(_userId);
            var model =service.GetClubs();
            return View(model);
        }

        // GET: Create Club
        public ActionResult Create()
        {
            var _userId = Guid.Parse(User.Identity.GetUserId());
            var service = CreateSponsorService(_userId);
            var myList = service.GetSponsors();

            //ClubCreate newModel = new ClubCreate();
            ViewBag.SponsorId = new SelectList(myList.ToList(),   // List of items
                                               "SponsorId",       // Data Value Field to be bound    
                                               "FullName");       // Data Text Field to be shown
            var days = Enum.GetValues(typeof(AllDays));

            ViewBag.Days = new SelectList(days,
                                          "Days");

             
            return View();
        }

        //Add code here 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClubCreate model)
        {
            var _userId = Guid.Parse(User.Identity.GetUserId());

            var service = CreateClubService(_userId);

            var myList = service.GetSponsors();
            ViewBag.SponsorId = new SelectList(myList.ToList(),   // List of items
                                                "SponsorId",      // Data Value Field    
                                                "FullName");      // Data Text Field

           
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (service.CreateClub(model))
            {
                // ViewBag.SaveResult = "Your club created";
                TempData["SaveResult"] = "This club was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "This club could not be created");

            return View();
        }



        public ActionResult Edit(int id)
        {
            var _userId = Guid.Parse(User.Identity.GetUserId());
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
            var _userId = Guid.Parse(User.Identity.GetUserId());
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
            var _userId = Guid.Parse(User.Identity.GetUserId());
            var svc = CreateClubService(_userId);
            var model = svc.GetClubById(id);

            return View(model);
        }



        public ActionResult Delete(int id)
        {
            var _userId = Guid.Parse(User.Identity.GetUserId());
            var svc = CreateClubService(_userId);
            var model = svc.GetClubById(id);

            return View(model);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var _userId = Guid.Parse(User.Identity.GetUserId());
            var service = CreateClubService(_userId);

            service.DeleteClub(id);

            TempData["SaveResult"] = "Your Club was deleted, it is no more";

            return RedirectToAction("Index");
        }


        // Get : Join
        public ActionResult Join(int id)
        {
            //var service = CreateClubService(_userId);
            // Change the Db table to include student id? JoinClub already has this, as does student.
            // How to relate student id to the user? Take this in from the register panel?
            //service.CreateNewClubMember(id);
            //return RedirectToAction("Index");
            // Get the club name from the id
            var _userId = Guid.Parse(User.Identity.GetUserId());
            var service = CreateClubService(_userId);
            ClubDetail club = service.GetClubById(id);
            JoinClub clubToJoin = 
                new JoinClub
                    {
                    StudentId = 0,
                    ClubTitle = club.Title,
                    ClubId = club.ClubId
                    };
            return View(clubToJoin);

        }

        // POST : Join Club
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Join(JoinClub model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var _userId = Guid.Parse(User.Identity.GetUserId());
            var service = CreateClubService(_userId);

            if (service.CreateNewClubMember(model.ClubId, model.StudentId))
            {
                TempData["SaveResult"] = "You have joined " + model.ClubTitle;
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Sorry, you could not join the club");

            return View();
        }


        public ActionResult ListMembers(int id)
        {
            var _userId = Guid.Parse(User.Identity.GetUserId());
            var service = CreateClubService(_userId);
            var models = service.GetMembersOfClub(id);
            return View(models);
        }

    }
}