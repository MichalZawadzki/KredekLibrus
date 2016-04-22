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

        public LessonController(IApplicationService applicationService)
        {
            _applicationService = applicationService; 
        }

        public ActionResult LessonGrid()
        {

            return View();
        }
	}
}