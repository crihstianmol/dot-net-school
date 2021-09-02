using System;
using System.Collections.Generic;
using SchoolCore.Util;
namespace SchoolCore.Entities
{
    public class Grade:SchoolBaseObject, iPlace
    {
        public string Address { get; set; }
        public JournalTypes Journal { get; set; }
        public List<Course> Courses{ get; set; }
        public List<Student> Students{ get; set; }

        public void ClearPlace()
        {
            Printer.DrawLine();
            Printer.WriteLine("Cleaning Grade Place");
            Printer.WriteLine($"Grade {Name} is Clean");
        }
    }
}