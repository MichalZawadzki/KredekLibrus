using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MichalZawadzkiLibrus.Models;

namespace MichalZawadzkiLibrus.Services
{
    interface IApplicationService
    {
        void AddGroup(GroupSet group, string teacherId);
        void EditGroup(GroupSet group, string teacherId);
        void RemoveGroupById(string groupId);
        List<GroupSet> GetGroupsByTeacherId(string teacherId);
        GroupSet GetGroupById(string groupId);
        TeacherSet GetTeacherByLogin(string login);
        StudentSet GetStudentByLogin(string login);
    }
}
