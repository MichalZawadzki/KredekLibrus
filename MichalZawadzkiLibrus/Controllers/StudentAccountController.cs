﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MichalZawadzkiLibrus.Models;
using MichalZawadzkiLibrus.Services;

namespace MichalZawadzkiLibrus.Controllers
{
    public class StudentAccountController : Controller
    {
        private readonly IApplicationService _applicationService;
        private readonly IAuthenticationService _authenticationService;

        public StudentAccountController(IApplicationService applicationService, IAuthenticationService authenticationService)
        {
            _applicationService = applicationService;
            _authenticationService = authenticationService;
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _applicationService.GetStudentByLogin(model.Login);
            if (user == null)
            {
                AddWrongEmailPasswordError();
                return View(model);
            }

            if (model.Password == user.Password)
            {
                var identity = _authenticationService.CreateStudentIdentity(user);
                _authenticationService.SignIn(identity, Request);

                return RedirectToAction("Index", "Home");
            }
            AddWrongEmailPasswordError();
            return View(model);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            _authenticationService.SignOut(Request);
            return RedirectToAction("Index", "Home");
        }

        public string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }

        public void AddWrongEmailPasswordError()
        {
            ModelState.AddModelError("Email", "Wrong email address or password.");
        }

        public void AddDuplicatedEmailError()
        {
            ModelState.AddModelError("Email", "User with this email already exists.");
        }
	}
}