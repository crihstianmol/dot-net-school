using System;
using System.Collections.Generic;

namespace SchoolCore.Entities
{
    public class Student: SchoolObjectBase
    {
        public List<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
    }
}