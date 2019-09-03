using System;
using System.Collections.Generic;
using System.Text;

namespace AttemptConsole.Repositories
{
    public class MemoryRepository
    {
        IList<Person> persons = new List<Person>()
            {
                new Person(){ Id=1, Firstname="Bill", Lastname = "Bax", BirthDate = DateTime.Parse("10-10-2014")},
                new Person(){ Id=2, Firstname="Steve", Lastname = "Bethoven", BirthDate = DateTime.Parse("10-10-2015")},
                new Person(){ Id=3, Firstname="Ramzan", Lastname = "Ivanov", BirthDate = DateTime.Parse("12-10-2014")},
                new Person(){ Id=4, Firstname = "Anton", Lastname = "Ivanov", BirthDate = DateTime.Parse("10-12-2032")},
                new Person(){ Id=5, Firstname = "Anton", Lastname = "Petrov", BirthDate = DateTime.Parse("10-12-2032")}
            };
    }
}
