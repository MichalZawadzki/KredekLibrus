//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MichalZawadzkiLibrus.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PresenceSet
    {
        public int Id { get; set; }
        public bool Present { get; set; }
        public Nullable<int> Activity { get; set; }
        public Nullable<int> Student_Id { get; set; }
        public Nullable<int> Lesson_Id { get; set; }
    
        public virtual LessonSet LessonSet { get; set; }
        public virtual StudentSet StudentSet { get; set; }
    }
}
