using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Gridushko._08
{
    public class FactoryOfGrades
    {
        /// <summary>
        /// Initializes the account gradation object, depending on the type.
        /// </summary>
        /// <param name="gradeType">The type of account graduation.</param>
        /// <returns>The object corresponding to the type of account graduation.</returns>
        public static AccountsSortingGrades GetGrading(TypeOfGrade gradeType)
        {
            AccountsSortingGrades grade = null;

            switch (gradeType)
            {
                case TypeOfGrade.Basic:
                    {
                        grade = new Basics();
                        break;
                    }

                case TypeOfGrade.Golden:
                    {
                        grade = new GoldCashMoney();
                        break;
                    }

                case TypeOfGrade.Platinus:
                    {
                        grade = new PlatinumCashMoney();
                        break;
                    }
            }

            return grade;
        }
    }
}

