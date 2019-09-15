using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FileCabinet
{
    public class Validators
    {
        public static void CheckFirstNameAnnotation(Person person)
        {
            bool IsValid = false;

            while (!IsValid)
            {
                Console.WriteLine("Insert the first name of person");
                person.FirstName = Console.ReadLine();
                IsValid = CommonCheckingLogic(person);
            }
        }
        public static void CheckLastNameAnnotation(Person person)
        {
            bool IsValid = false;

            while (!IsValid)
            {
                Console.WriteLine("Insert the last name of person");
                person.LastName = Console.ReadLine();
                IsValid = CommonCheckingLogic(person);
            }
        }
        /// <summary>
        /// Cheks is valid due annotations in model
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static bool CommonCheckingLogic(Person person)
        {
            var context = new ValidationContext(person, null, null);

            var result = new List<ValidationResult>();

            if (Validator.TryValidateObject(person, context, result, true))
            {
                return true;
            }
            else
            {
                foreach (var x in result)
                {
                    Console.WriteLine(x.ErrorMessage);
                }
                return false;
            }
        }

        public static void Asigning(int identis, Person person)
        {
            Console.WriteLine("Insert the date of birth");
            System.DateTime birthdate = Convert.ToDateTime(Console.ReadLine());
            person.Id = identis;
            person.BirthDate = birthdate;
        }
    }
}
