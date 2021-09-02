using System;
using System.Collections.Generic;

namespace SchoolCore.Entities
{
    public class Student: SchoolBaseObject
    {
        public List<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
    }
}