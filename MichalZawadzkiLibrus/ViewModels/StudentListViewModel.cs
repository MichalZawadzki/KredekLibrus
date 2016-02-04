using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MichalZawadzkiLibrus.Models;

namespace MichalZawadzkiLibrus.ViewModels
{
    public class StudentListViewModel
    {
        public GroupSet Group { get; set; }
        public List<StudentSet> Students { get; set; }

        public StudentListViewModel()
        {
            Group = new GroupSet();
            Students = new List<StudentSet>();
        }
    }
}