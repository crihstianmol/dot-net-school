using System;
using System.Collections.Generic;
using System.Linq;
using SchoolCore.Entities;

namespace SchoolCore
{
    public sealed class SchoolEngine
    {
        public School School { get; set; }

        public SchoolEngine()
        {

        }

        public void Initialize()
        {
            School = new School("Platzi Academy", 2012, SchoolTypes.Academy,
            city: "Bogotá", country: "Colombia"
            );

            LoadGrades();
            LoadCourses();
            LoadEvaluations();

        }

        private void LoadEvaluations()
        {

            foreach (var grade in School.Grades)
            {
                foreach (var course in grade.Courses)
                {
                    foreach (var student in grade.Students)
                    {
                        var rnd = new Random(System.Environment.TickCount);

                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluation
                            {
                                Course = course,
                                Name = $"{course.Name} Ev#{i + 1}",
                                Score = (float)(5 * rnd.NextDouble()),
                                Student = student
                            };
                            student.Evaluations.Add(ev);
                        }
                    }
                }
            }

        }

        public List<SchoolObjectBase> GetSchoolObjects()
        {
            var objList = new List<SchoolObjectBase>();
            objList.Add(School);
            objList.AddRange(School.Grades);

            foreach (var grade in School.Grades)
            {
                objList.AddRange(grade.Courses);
                objList.AddRange(grade.Students);

                foreach (var student in grade.Students)
                {
                    objList.AddRange(student.Evaluations);
                }
            }

            return objList;
        }

        private void LoadCourses()
        {
            foreach (var grade in School.Grades)
            {
                var courseList = new List<Course>(){
                            new Course{Name="Matemáticas"} ,
                            new Course{Name="Educación Física"},
                            new Course{Name="Castellano"},
                            new Course{Name="Ciencias Naturales"}
                };
                grade.Courses = courseList;
            }
        }

        private List<Student> GenerateRandomStudents(int studentsAmount)
        {
            string[] name1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] lastname1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] name2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var studentsList = from n1 in name1
                               from n2 in name2
                               from a1 in lastname1
                               select new Student { Name = $"{n1} {n2} {a1}" };

            return studentsList.OrderBy((al) => al.UniqueId).Take(studentsAmount).ToList();
        }

        private void LoadGrades()
        {
            School.Grades = new List<Grade>(){
                        new Grade(){ Name = "101", Journal = JournalTypes.Morning },
                        new Grade() {Name = "201", Journal = JournalTypes.Morning},
                        new Grade{Name = "301", Journal = JournalTypes.Morning},
                        new Grade(){ Name = "401", Journal = JournalTypes.Evening },
                        new Grade() {Name = "501", Journal = JournalTypes.Evening},
            };

            Random rnd = new Random();
            foreach (var c in School.Grades)
            {
                int randomAmount = rnd.Next(5, 20);
                c.Students = GenerateRandomStudents(randomAmount);
            }
        }
    }
}