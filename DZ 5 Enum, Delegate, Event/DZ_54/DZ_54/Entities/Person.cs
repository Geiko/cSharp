using System;

namespace geiko.DZ_54.Entities
{
    public class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            this.Name = name;
        }

        public virtual Person DeepCopy(Person current)
        {
            Person copied = new Person(current.Name);
            return copied;
        }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}
