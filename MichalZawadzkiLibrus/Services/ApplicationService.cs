using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using MichalZawadzkiLibrus.Models;
using MichalZawadzkiLibrus.ViewModels;

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

        public List<StudentSet> GetStudentsByGroupId(string groupId)
        {
            var id = Int32.Parse(groupId);
            var students = _databaseService.GetStudentsByGroupId(id);
            return students;
        }

        public StudentListViewModel GetStudentListViewModelByGroupId(string groupId)
        {
            var id = Int32.Parse(groupId);
            var group = _databaseService.GetGroupById(id);
            var students = _databaseService.GetStudentsByGroupId(id);
            var studentListViewModel = _mappingService.MapToStudentListViewModel(group, students);
            return studentListViewModel;
        }

        public void RemoveStudentById(string studentId)
        {
            var id = Int32.Parse(studentId);
            var student = _databaseService.GetStudentById(id);
            _databaseService.RemoveStudent(student);
        }
        
        public void AddStudent(StudentSet student)
        {
            _databaseService.AddStudent(student);
        }

        public StudentSet GetStudentById(string studentId)
        {
            var id = Int32.Parse(studentId);
            var student = _databaseService.GetStudentById(id);
            return student;
        }

        public void EditStudent(StudentSet student)
        {
            _databaseService.EditStudent(student);
        }
    }
}