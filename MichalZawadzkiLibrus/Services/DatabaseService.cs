using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using MichalZawadzkiLibrus.Models;

namespace MichalZawadzkiLibrus.Services
{
    public class DatabaseService : IDatabaseService
    {
        private EvaluationSystemEntities context;

        public DatabaseService()
        {
            context = new EvaluationSystemEntities();
        }

        public void AddGroup(GroupSet groupSet)
        {
            context.GroupSet.Add(groupSet);
            context.SaveChanges();
        }

        public void EditGroup(GroupSet groupSet)
        {
            context.GroupSet.AddOrUpdate(groupSet);
            context.SaveChanges();
        }

        public void RemoveGroup(GroupSet groupSet)
        {
            context.GroupSet.Remove(groupSet);
            context.SaveChanges();
        }

        public List<GroupSet> GetGroupsByTeacherId(int teacherId)
        {
            var groupSets = context.GroupSet.Where(g => g.TeacherSet.Id == teacherId).ToList();
            return groupSets;
        }

        public GroupSet GetGroupById(int groupSetId)
        {
            var groupSet = context.GroupSet.FirstOrDefault(g => g.Id == groupSetId);
            return groupSet;
        }

        public TeacherSet GetTeacherByLogin(string login)
        {
            var teacher = context.TeacherSet.FirstOrDefault(t => t.Login == login);
            return teacher;
        }

        public StudentSet GetStudentByLogin(string login)
        {
            var student = context.StudentSet.FirstOrDefault(s => s.Login == login);
            return student;
        }

        public List<StudentSet> GetStudentsByGroupId(int groupId)
        {
            var students = context.StudentSet.Where(s => s.Group_Id == groupId).ToList();
            return students;
        }
        
        public void RemoveStudent(StudentSet student)
        {
            context.StudentSet.Remove(student);
            context.SaveChanges();
        }

        public void AddStudent(StudentSet student)
        {
            context.StudentSet.Add(student);
            context.SaveChanges();
        }

        public void EditStudent(StudentSet student)
        {
            context.StudentSet.AddOrUpdate(student);
            context.SaveChanges();
        }

        public StudentSet GetStudentById(int studentId)
        {
            var student = context.StudentSet.SingleOrDefault(s => s.Id == studentId);
            return student;
        }
    }
}