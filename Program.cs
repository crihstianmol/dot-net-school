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
            var reporter = new Reporter(engine.GetObjectDictionary());
            var evList = reporter.GetEvaluationList();
            var courseList = reporter.GetCourseList();
            var evXCourseList = reporter.GetEvaluationByCourse();
            var aveXCourseList = reporter.GetEvalAverageByCourse();
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
