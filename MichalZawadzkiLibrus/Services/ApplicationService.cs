using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using MichalZawadzkiLibrus.Models;

namespace MichalZawadzkiLibrus.Services
{
    public class ApplicationService : IApplicationService
    {
        private IMappingService _mappingService;
        private IDatabaseService _databaseService;

        public ApplicationService()
        {
            _mappingService = new MappingService();
            _databaseService = new DatabaseService();
        }

        public void AddGroup(GroupSet group, string teacherId)
        {
            group.Teacher_Id = Int32.Parse(teacherId);
            _databaseService.AddGroup(group);
        }

        public void EditGroup(GroupSet group, string teacherId)
        {
            group.Teacher_Id = Int32.Parse(teacherId);
            _databaseService.EditGroup(group);
        }


        public List<GroupSet> GetGroupsByTeacherId(string teacherId)
        {
            var id = Int32.Parse(teacherId);
            var groups = _databaseService.GetGroupsByTeacherId(id);
            return groups;
        }

        public GroupSet GetGroupById(string groupId)
        {
            var id = Int32.Parse(groupId);
            var group = _databaseService.GetGroupById(id);
            return group;
        }


        public void RemoveGroupById(string groupId)
        {
            var id = Int32.Parse(groupId);
            var group = _databaseService.GetGroupById(id);
            _databaseService.RemoveGroup(group);
        }


        public TeacherSet GetTeacherByLogin(string login)
        {
            var teacher = _databaseService.GetTeacherByLogin(login);
            return teacher;
        }

        public StudentSet GetStudentByLogin(string login)
        {
            var student = _databaseService.GetStudentByLogin(login);
            return student;
        }
    }
}