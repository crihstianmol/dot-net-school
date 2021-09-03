using System;
using System.Collections.Generic;
using System.Linq;
using SchoolCore.Entities;
using SchoolCore.Util;
using static System.Console;

namespace SchoolCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new SchoolEngine();
            engine.Initialize();
            Printer.WriteTitle("Welcome to " + engine.School.Name);
            PrintSchoolGrades(engine.School);
            var dic = engine.GetObjectDictionary();
            foreach (var item in dic)
            {
                foreach (var obj in item.Value)
                {
                    Printer.WriteTitle(obj.Name);
                }
            }
        }

        private static void PrintSchoolGrades(School school)
        {
            Printer.WriteTitle("Morning Grades");
            if (school?.Grades != null)
            {
                foreach (var grade in school.Grades)
                {
                    WriteLine($"Name {grade.Name  }, Id  {grade.UniqueId}");
                }
            }
        }
    }
}
