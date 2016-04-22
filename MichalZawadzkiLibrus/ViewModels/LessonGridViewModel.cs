using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MichalZawadzkiLibrus.Models;

namespace MichalZawadzkiLibrus.ViewModels
{
    public class LessonGridViewModel
    {
        public List<LessonSet> Lessons { get; set; }
        public List<StudentSet> Students { get; set; }
        public int RowSize { get; set; }

        public LessonGridViewModel()
        {
            Lessons = new List<LessonSet>();
            Students = new List<StudentSet>();
        }
    }
}