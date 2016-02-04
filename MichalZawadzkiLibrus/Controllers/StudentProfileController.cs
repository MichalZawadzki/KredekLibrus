﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MichalZawadzkiLibrus.Services;

namespace MichalZawadzkiLibrus.Controllers
{
    public class StudentProfileController : Controller
    {
        private IApplicationService _applicationService;

        public StudentProfileController()
        {
            _applicationService = new ApplicationService(); 
        }

        [HttpGet]
        public ActionResult Profile(string studentId)
        {
            //Jakis viewmodel zrobic i wyswietlic
            return View();
        }
	}
}