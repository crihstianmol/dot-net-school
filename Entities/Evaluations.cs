using System;

namespace SchoolCore.Entities
{
    public class Evaluations
    {
        public string UniqueId { get; private set; }
        public string Name { get; set; }

        public Student Student { get; set; }
        public Course Course  { get; set; }

        public float Score { get; set; }

        public Evaluations() => UniqueId = Guid.NewGuid().ToString();
    }
}