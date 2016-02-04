using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MichalZawadzkiLibrus.Models;
using MichalZawadzkiLibrus.ViewModels;

namespace MichalZawadzkiLibrus.Services
{
    interface IMappingService
    {
        StudentListViewModel MapToStudentListViewModel(GroupSet group, List<StudentSet> students);
    }
}
