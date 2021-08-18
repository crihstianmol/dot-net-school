using System;
using System.Collections.Generic;

namespace SchoolCore.Entities
{
    public class Grade:SchoolObjectBase
    {
        public JournalTypes Journal { get; set; }
        public List<Course> Courses{ get; set; }
        public List<Student> Students{ get; set; }
        
    }
}