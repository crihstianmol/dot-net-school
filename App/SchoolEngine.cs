using System;
using System.Collections.Generic;
using System.Linq;
using SchoolCore.Entities;
using SchoolCore.Util;

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
            School =
                new School("Platzi Academy",
                    2012,
                    SchoolTypes.Academy,
                    city: "Bogotá",
                    country: "Colombia");

            LoadGrades();
            LoadCourses();
            LoadEvaluations();
        }

        public void PrintDictionary(Dictionary<DictionaryKeys, IEnumerable<SchoolBaseObject>> dic)
        {
            foreach (var obj in dic)
            {
                Printer.WriteLine(obj.Key.ToString());
                foreach (var listVal in obj.Value)
                {
                    if (listVal is Evaluation)
                    {
                        var eval = (Evaluation)listVal;
                        Printer.WriteLine("Evaluation: " +eval.ToString());
                    }
                    
                    if (listVal is Student)
                    {
                        var eval = (Student)listVal;
                        Printer.WriteLine("Student: " +eval.ToString());
                    }
                    if (listVal is Course)
                    {
                        var eval = (Course)listVal;
                        Printer.WriteLine("Course: " +eval.ToString());
                    }
                    if (listVal is Grade)
                    {
                        var eval = (Grade)listVal;
                        Printer.WriteLine("Grade: " +eval.ToString());
                    }

                }
            }
        }
        public Dictionary<DictionaryKeys, IEnumerable<SchoolBaseObject>> GetObjectDictionary()
        {
            var dic = new Dictionary<DictionaryKeys, IEnumerable<SchoolBaseObject>>();
            dic.Add(DictionaryKeys.School, new[] { this.School });
            dic.Add(DictionaryKeys.Grades, this.School.Grades.Cast<SchoolBaseObject>());
            var ListStudents = new List<Student>();
            var ListCourses = new List<Course>();
            var ListEvaluations = new List<Evaluation>();
            foreach (var grades in this.School.Grades)
            {
                ListCourses.AddRange(grades.Courses);
                ListStudents.AddRange(grades.Students);
                grades.Students.ForEach(stud => { ListEvaluations.AddRange(stud.Evaluations); });
            }
            dic.Add(DictionaryKeys.Courses, ListCourses.Cast<SchoolBaseObject>());
            dic.Add(DictionaryKeys.Students, ListStudents.Cast<SchoolBaseObject>());
            dic.Add(DictionaryKeys.Evaluations, ListEvaluations.Cast<SchoolBaseObject>());
            return dic;
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
                            var ev =
                                new Evaluation
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

        public IReadOnlyList<SchoolBaseObject>
        GetSchoolObjects(
            bool getEvaluation = true,
            bool getStudent = true,
            bool getCourses = true,
            bool getGrades = true
        )
        {
            return this
                .GetSchoolObjects(out int dummy,
                out dummy,
                out dummy,
                out dummy,
                getEvaluation,
                getStudent,
                getCourses,
                getGrades);
        }

        public IReadOnlyList<SchoolBaseObject>
        GetSchoolObjects(
            out int evaluationCount,
            out int studentCount,
            out int courseCount,
            out int gradeCount,
            bool getEvaluation = true,
            bool getStudent = true,
            bool getCourses = true,
            bool getGrades = true
        )
        {
            evaluationCount = 0;
            studentCount = 0;
            courseCount = 0;
            gradeCount = 0;
            var objList = new List<SchoolBaseObject>();
            objList.Add(School);
            if (getGrades)
            {
                objList.AddRange(School.Grades);
            }
            gradeCount = School.Grades.Count;
            foreach (var grade in School.Grades)
            {
                courseCount = grade.Courses.Count;
                if (getCourses)
                {
                    objList.AddRange(grade.Courses);
                }
                studentCount = grade.Students.Count;
                if (getStudent)
                {
                    objList.AddRange(grade.Students);
                }
                if (getEvaluation)
                {
                    foreach (var student in grade.Students)
                    {
                        objList.AddRange(student.Evaluations);
                        evaluationCount += student.Evaluations.Count;
                    }
                }
            }

            return objList.AsReadOnly();
        }

        private void LoadCourses()
        {
            foreach (var grade in School.Grades)
            {
                var courseList =
                    new List<Course>()
                    {
                        new Course { Name = "Matemáticas" },
                        new Course { Name = "Educación Física" },
                        new Course { Name = "Castellano" },
                        new Course { Name = "Ciencias Naturales" }
                    };
                grade.Courses = courseList;
            }
        }

        private List<Student> GenerateRandomStudents(int studentsAmount)
        {
            string[] name1 =
            {
                "Alba",
                "Felipa",
                "Eusebio",
                "Farid",
                "Donald",
                "Alvaro",
                "Nicolás"
            };
            string[] lastname1 =
            {
                "Ruiz",
                "Sarmiento",
                "Uribe",
                "Maduro",
                "Trump",
                "Toledo",
                "Herrera"
            };
            string[] name2 =
            {
                "Freddy",
                "Anabel",
                "Rick",
                "Murty",
                "Silvana",
                "Diomedes",
                "Nicomedes",
                "Teodoro"
            };

            var studentsList =
                from n1 in name1
                from n2 in name2
                from a1 in lastname1
                select new Student { Name = $"{n1} {n2} {a1}" };

            return studentsList
                .OrderBy((al) => al.UniqueId)
                .Take(studentsAmount)
                .ToList();
        }

        private void LoadGrades()
        {
            School.Grades =
                new List<Grade>()
                {
                    new Grade()
                    { Name = "101", Journal = JournalTypes.Morning },
                    new Grade()
                    { Name = "201", Journal = JournalTypes.Morning },
                    new Grade { Name = "301", Journal = JournalTypes.Morning },
                    new Grade()
                    { Name = "401", Journal = JournalTypes.Evening },
                    new Grade() { Name = "501", Journal = JournalTypes.Evening }
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
