using System;
using NUnit.Framework;

namespace NET.W._2019.Gridushko._08
{
    [TestFixture]
    public class AccountNUnitTests
    {
        #region Equals tests

        [TestCase(ExpectedResult = true)]
        public bool Equals_AccountAndAccount_SuccessfulExecution()
        {
            PersonAccount firstOneAccount = new PersonAccount(131, "Байцов", "Александр", 1000, 200, TypeOfGrade.Golden);
            PersonAccount secondAccount = new PersonAccount(131, "Байцов", "Александр", 1000, 200, TypeOfGrade.Golden);
            return firstOneAccount.Equals(secondAccount);
        }

        [TestCase(ExpectedResult = true)]
        public bool Equals_AccountAndObject_SuccessfulExecution()
        {
            PersonAccount firstOneAccount = new PersonAccount(131, "Байцов", "Александр", 1000, 200, TypeOfGrade.Golden);
            object secondAccount = new PersonAccount(131, "Байцов", "Александр", 1000, 200, TypeOfGrade.Golden);
            return firstOneAccount.Equals(secondAccount);
        }

        [TestCase(ExpectedResult = false)]
        public bool Equals_AccountAndAccount_UnsuccessfulExecution()
        {
            PersonAccount firstOneAccount = new PersonAccount(131, "Байцов", "Александр", 1000, 200, TypeOfGrade.Golden);
            PersonAccount secondAccount = new PersonAccount(132, "Байцов", "Александр", 1000, 200, TypeOfGrade.Golden);
            return firstOneAccount.Equals(secondAccount);
        }

        #endregion Equals tests
    }
}