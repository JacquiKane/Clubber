using Clubber.Models;
using Clubber.services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clubber.WebMVC.Controllers
{
    public class StudentProfileController : Controller
    {
        private readonly Guid _userId;

        private StudentProfileService CreateStudentProfileService(Guid userId)
        {
            var service = new StudentProfileService(userId);
            return service;
        }


        // GET: StudentProfile
        public ActionResult Index()
        {
            return View();
        }

        // Get: Create Student Profile
        public ActionResult Create()
        {
            StudentProfileCreate model = new StudentProfileCreate
            {
                UserId = Guid.Parse(User.Identity.GetUserId()),
                StudentId = 0,
                UserName = User.Identity.GetUserName()
            };
            return View(model);
        }

 
        // POST : Create Student Profile
        [HttpPost]
        public ActionResult Create(StudentProfileCreate model)
        {
            // Add to DB
            var service = new StudentProfileService(_userId);
            service.CreateProfile(model);
            ViewBag.HasProfile = true;
            return RedirectToAction("Index", "Club");
        }
    }
}