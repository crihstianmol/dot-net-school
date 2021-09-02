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
            Dictionary<int, string> diccionario = new Dictionary<int, string>();
            diccionario.Add(1,"Crihstian");
            diccionario.Add(2,"Alejandro");
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
