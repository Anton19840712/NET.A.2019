using AttemptConsole.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttemptConsole
{
    public class PersonsService
    {
        private readonly IRepository<Person> repository = RepositoryFactory.GetFileRepository<Person>();

        private static PersonsService instance;
        public static PersonsService Instance => PersonsService.instance ?? (PersonsService.instance = new PersonsService());

        public void Create(Person person)
        {
            this.repository.Edit(person);
        }
        public void Edit(Person person)
        {
            this.repository.Edit(person);
        }
    }
}
