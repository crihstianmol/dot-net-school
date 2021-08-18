using System;
using System.Collections.Generic;
using SchoolCore.Util;

namespace SchoolCore.Entities
{
    public class School : SchoolObjectBase, iPlace
    {
        public int FoundationYear { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public SchoolTypes SchoolType { get; set; }
        public List<Grade> Grades { get; set; }

        public School(string name, int year) => (Name, FoundationYear) = (name, year);

        public School(string name, int year,
                       SchoolTypes stype,
                       string country = "", string city = "") : base()
        {
            (Name, FoundationYear) = (name, year);
            Country = country;
            City = city;
        }

        public override string ToString()
        {
            return $"Name: \"{Name}\", Type: {SchoolType} {System.Environment.NewLine} Country: {Country}, City:{City}";
        }

        public void ClearPlace()
        {
            Printer.Beep();
            Printer.DrawLine();
            Printer.WriteLine("Cleaning School");
            Grades.ForEach(grade => grade.ClearPlace());
            Printer.DrawLine();
            Printer.WriteTitle("The School is Clean");
        }
    }
}
