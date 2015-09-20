using System;

namespace geiko.DZ_54.Entities
{
    public class Author : Person
    {
        public Author(string Name) : base(Name) { }

        public new Author DeepCopy(Person current)
        {
            return new Author(current.Name);
        }
    }
}
