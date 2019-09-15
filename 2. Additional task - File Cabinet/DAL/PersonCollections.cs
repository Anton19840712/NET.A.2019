using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FileCabinet
{
    /// <summary>
    /// Class contains initial info to work with when application starts
    /// </summary>
    internal class PersonCollections
    {
        public static IList<Person> AlluserDatas { get; set; }
        static PersonCollections()
        {
            AlluserDatas = new List<Person>()
            {
                new Person() { Id = 1, FirstName = "Bill", LastName = "Bax", BirthDate = DateTime.Parse("10-10-2014")},
                new Person() { Id = 2, FirstName = "Steve", LastName = "Bethoven", BirthDate = DateTime.Parse("10-10-2015")},
                new Person() { Id = 3, FirstName = "Ramzan", LastName = "Ivanov", BirthDate = DateTime.Parse("12-10-2014")},
                new Person() { Id = 4, FirstName = "Anton", LastName = "Ivanov", BirthDate = DateTime.Parse("10-12-2032")},
                new Person() { Id = 5, FirstName = "Anton", LastName = "Petrov", BirthDate = DateTime.Parse("10-12-2032")}
            };
        }      
    }
}
