using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using MichalZawadzkiLibrus.Models;
using Microsoft.Owin.Security;

namespace MichalZawadzkiLibrus.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public bool IsAuthenticated(HttpRequestBase request)
        {
            var authManager = GetAuthManager(request);
            return authManager.User.Identity.IsAuthenticated;
        }

        public IAuthenticationManager GetAuthManager(HttpRequestBase request)
        {
            var context = request.GetOwinContext();
            return context.Authentication;
        }
        public string GetUserIdFromRequest(HttpRequestBase request)
        {
            var authManager = GetAuthManager(request);
            var claim = authManager.User.Claims.SingleOrDefault(r => r.Type == ClaimTypes.Sid);
            return claim.Value;
        }


        public void SignIn(ClaimsIdentity identity, HttpRequestBase request)
        {
            var authManager = GetAuthManager(request);
            authManager.SignIn(identity);
        }

        public void SignOut(HttpRequestBase request)
        {
            var authManager = GetAuthManager(request);
            authManager.SignOut("ApplicationCookie");
        }

        public ClaimsIdentity CreateTeacherIdentity(TeacherSet user)
        {
            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.Name + " " + user.Surname),
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Teacher"),
                    new Claim(ClaimTypes.Email, user.Email)
                }, "ApplicationCookie");
            return identity;
        }

        public ClaimsIdentity CreateStudentIdentity(StudentSet user)
        {
            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.Name + " " + user.Surname),
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Student"),
                    new Claim(ClaimTypes.Email, user.Email)
                }, "ApplicationCookie");
            return identity;
        }
    }
}