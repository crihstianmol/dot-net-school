using System;

namespace SchoolCore.Entities
{
    public class SchoolObjectBase
    {
        public string UniqueId { get; private set; }
        public string Name { get; set; }

        public SchoolObjectBase()
        {
            UniqueId = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Name},{UniqueId}";
        }
    }
}