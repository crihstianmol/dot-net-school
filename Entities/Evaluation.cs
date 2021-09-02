using System;

namespace SchoolCore.Entities
{
    public class Evaluation:SchoolBaseObject
    {
        public Student Student { get; set; }
        public Course Course  { get; set; }

        public float Score { get; set; }

        public override string ToString()
        {
            return $"{Score}, {Student.Name}, {Course.Name}";
        }
    }
}