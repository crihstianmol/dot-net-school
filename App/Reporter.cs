using System;
using System.Linq;
using System.Collections.Generic;
using SchoolCore.Entities;

namespace SchoolCore
{
    public class Reporter
    {
        Dictionary<DictionaryKeys, IEnumerable<SchoolBaseObject>> _dictionary;
        public Reporter(Dictionary<DictionaryKeys, IEnumerable<SchoolBaseObject>> dicSchObj)
        {
            if (dicSchObj == null)
                throw new ArgumentNullException(nameof(dicSchObj));
            _dictionary = dicSchObj;
        }

        public IEnumerable<Evaluation> GetEvaluationList()
        {
            if (_dictionary.TryGetValue(DictionaryKeys.Evaluations, out IEnumerable<SchoolBaseObject> evList))
            {
                return evList.Cast<Evaluation>();
            }
            {
                return new List<Evaluation>();
            }
        }
        public IEnumerable<String> GetCourseList()
        {
            return GetCourseList(out IEnumerable<Evaluation> courseList);
        }
        public IEnumerable<String> GetCourseList(out IEnumerable<Evaluation> courseList)
        {
            courseList = GetEvaluationList();

            return (from course in courseList
                        // where course.Score >= 3.0f
                    select course.Course.Name).Distinct();
        }
        public Dictionary<String, IEnumerable<Evaluation>> GetEvaluationByCourse()
        {
            var evDic = new Dictionary<String, IEnumerable<Evaluation>>();
            var courseList = GetCourseList(out var evList);
            foreach (var course in courseList)
            {
                var evalList = from eval in evList
                               where eval.Course.Name == course
                               select eval;
                evDic.Add(course, evalList);
            }
            return evDic;
        }
        public Dictionary<String, IEnumerable<object>> GetEvalAverageByCourse()
        {
            var evDic = new Dictionary<String, IEnumerable<object>>();
            var courseList = GetEvaluationByCourse();

            foreach (var courseWEv in courseList)
            {
                var studentAve = (from course in courseWEv.Value
                                  group course by new { course.Student.UniqueId, course.Student.Name }
                                into StudentEvalGroup
                                  select new StudentAverage { 
                                      Average = StudentEvalGroup.Average(eval => eval.Score), 
                                      Student = StudentEvalGroup.Key.UniqueId,
                                      StudentName = StudentEvalGroup.Key.Name
                                  }
                        );
                evDic.Add(courseWEv.Key, studentAve);
            }
            return evDic;
        }
    }
}