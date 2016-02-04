using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MichalZawadzkiLibrus.Models;
using MichalZawadzkiLibrus.ViewModels;

namespace MichalZawadzkiLibrus.Services
{
    public class MappingService : IMappingService
    {
        public StudentListViewModel MapToStudentListViewModel(GroupSet group, List<StudentSet> students)
        {
            var studentListViewModel = new StudentListViewModel()
            {
                Group = group,
                Students = students
            };
            return studentListViewModel;
        }
    }
}