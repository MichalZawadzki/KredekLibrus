using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MichalZawadzkiLibrus.Models;
using Microsoft.Owin.Security;

namespace MichalZawadzkiLibrus.Services
{
    interface IAuthenticationService
    {
        bool IsAuthenticated(HttpRequestBase request);
        IAuthenticationManager GetAuthManager(HttpRequestBase request);
        string GetUserIdFromRequest(HttpRequestBase request);
        void SignIn(ClaimsIdentity identity, HttpRequestBase request);
        void SignOut(HttpRequestBase request);
        ClaimsIdentity CreateTeacherIdentity(TeacherSet user);
        ClaimsIdentity CreateStudentIdentity(StudentSet user);
    }
}
