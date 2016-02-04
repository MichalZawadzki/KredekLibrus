using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MichalZawadzkiLibrus.Models;

namespace MichalZawadzkiLibrus.Services
{
    interface IDatabaseService
    {
        void AddGroup(GroupSet group);
        void EditGroup(GroupSet group);
        void RemoveGroup(GroupSet group);
        List<GroupSet> GetGroupsByTeacherId(int teacherId);
        GroupSet GetGroupById(int groupId);
        TeacherSet GetTeacherByLogin(string login);
        StudentSet GetStudentByLogin(string login);
        List<StudentSet> GetStudentsByGroupId(int groupId);
        void RemoveStudent(StudentSet student);
        StudentSet GetStudentById(int studentId);
        void AddStudent(StudentSet student);
        void EditStudent(StudentSet student);
    }
}
