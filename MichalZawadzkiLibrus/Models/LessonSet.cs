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
    
    public partial class LessonSet
    {
        public LessonSet()
        {
            this.PresenceSet = new HashSet<PresenceSet>();
            this.TaskSet = new HashSet<TaskSet>();
        }
    
        public int Id { get; set; }
        public string Topic { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> Group_Id { get; set; }
    
        public virtual GroupSet GroupSet { get; set; }
        public virtual ICollection<PresenceSet> PresenceSet { get; set; }
        public virtual ICollection<TaskSet> TaskSet { get; set; }
    }
}
