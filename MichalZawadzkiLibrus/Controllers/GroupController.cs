using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MichalZawadzkiLibrus.Models;
using MichalZawadzkiLibrus.Services;

namespace MichalZawadzkiLibrus.Controllers
{
    public class GroupController : Controller
    {
        private IApplicationService _applicationService;
        private IAuthenticationService _authenticationService;

        public GroupController()
        {
            _applicationService = new ApplicationService();
            _authenticationService = new AuthenticationService();
        }

        [HttpGet]
        public ActionResult List()
        {
            var teacherId = _authenticationService.GetUserIdFromRequest(Request);
            var groups = _applicationService.GetGroupsByTeacherId(teacherId);
            return View(groups);
        }


        [HttpPost]
        public ActionResult Remove(string groupId)
        {
            _applicationService.RemoveGroupById(groupId);
            var teacherId = _authenticationService.GetUserIdFromRequest(Request);
            var groups = _applicationService.GetGroupsByTeacherId(teacherId);
            return View("List", groups);
        }

        [HttpGet]
        public ActionResult Edit(string groupId)
        {
            var group = _applicationService.GetGroupById(groupId);
            return View(group);
        }

        [HttpPost]
        public ActionResult Edit(GroupSet group)
        {
            var teacherId = _authenticationService.GetUserIdFromRequest(Request);
            _applicationService.EditGroup(group, teacherId);
            var groups = _applicationService.GetGroupsByTeacherId(teacherId);
            return View("List", groups);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new GroupSet());
        }

        [HttpPost]
        public ActionResult Add(GroupSet group)
        {
            var teacherId = _authenticationService.GetUserIdFromRequest(Request);
            _applicationService.AddGroup(group, teacherId);
            var groups = _applicationService.GetGroupsByTeacherId(teacherId);
            return View("List", groups);
        }
	}
}