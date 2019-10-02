using Clubber.services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clubber.WebMVC.Controllers
{
    public class ClubMemberController : Controller
    {

        private ClubMemberService CreateClubMemberService(Guid _userId)
        {
            var service = new ClubMemberService(_userId);
            return service;
        }

        // GET: ClubMember
        public ActionResult Index()
        {
            var _userId = Guid.Parse(User.Identity.GetUserId());
            var service = CreateClubMemberService(_userId);
            //service.GetMembersOfClub()
            return View();
        }
    }
}