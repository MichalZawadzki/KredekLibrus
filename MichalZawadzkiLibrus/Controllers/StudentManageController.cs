using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MichalZawadzkiLibrus.Models;
using MichalZawadzkiLibrus.Services;

namespace MichalZawadzkiLibrus.Controllers
{
    public class StudentManageController : Controller
    {
        private IApplicationService _applicationService;

        public StudentManageController(IApplicationService applicationService)
        {
            _applicationService = applicationService; 
        }

        [HttpGet]
        public ActionResult StudentList(string groupId)
        {
            var studentListViewModel = _applicationService.GetStudentListViewModelByGroupId(groupId);
            return View(studentListViewModel);
        }

        [HttpPost]
        public ActionResult Remove(string studentId, string groupId)
        {
            _applicationService.RemoveStudentById(studentId);
            var studentListViewModel = _applicationService.GetStudentListViewModelByGroupId(groupId);
            return View("StudentList", studentListViewModel);
        }

        [HttpGet]
        public ActionResult Add(string groupId)
        {
            var id = Int32.Parse(groupId);
            var student = new StudentSet(){Group_Id = id};
            return View(student);
        }

        [HttpPost]
        public ActionResult Add(StudentSet student)
        {
            var studentExist = _applicationService.GetStudentByLogin(student.Login);
            if (studentExist == null)
            {
                if (student.Password == null || student.Login == null)
                {
                    ModelState.AddModelError("Login", "Login and password are required");
                    return View(student);
                }
                _applicationService.AddStudent(student);
                var studentListViewModel = _applicationService.GetStudentListViewModelByGroupId(student.Group_Id.ToString());
                return View("StudentList", studentListViewModel);
            }
            else
            {
                ModelState.AddModelError("Login", "This login exists");
                return View(student);
            }
        }

        [HttpGet]
        public ActionResult Edit(string studentId)
        {
            var student = _applicationService.GetStudentById(studentId);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(StudentSet student)
        {
            if (student.Password == null)
            {
                ModelState.AddModelError("Password", "Password is required");
                return View(student);
            }
            _applicationService.EditStudent(student);
            var studentListViewModel = _applicationService.GetStudentListViewModelByGroupId(student.Group_Id.ToString());
            return View("StudentList", studentListViewModel);
        }
	}
}