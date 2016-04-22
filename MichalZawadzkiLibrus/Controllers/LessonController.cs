using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MichalZawadzkiLibrus.Services;

namespace MichalZawadzkiLibrus.Controllers
{
    public class LessonController : Controller
    {
        private IApplicationService _applicationService;

        public LessonController()
        {
            _applicationService = new ApplicationService(); 
        }

        public ActionResult LessonGrid()
        {

            return View();
        }
	}
}