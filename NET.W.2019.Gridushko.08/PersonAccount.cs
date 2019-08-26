using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Gridushko._08
{
    public class PersonAccount
    {
        #region Fields

        private int _numvalue;
        private string _ownerFirstName;
        private string _ownerSecondName;
        private double value_amount;
        private int _bonusSpecialPoints;
        private AccountsSortingGrades _grade;
        private TypeOfGrade _typeOfGrade;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// A complete constructor to initialize the object.
        /// </summary>
        /// <param name="numvalue">PersonAccount numvalue.</param>
        /// <param name="ownerFirstName">Name of account holder.</param>
        /// <param name="ownerSecondName">Surname of account holder.</param>
        /// <param name="valueAmount">The valueAmount on the account.</param>
        /// <param name="bonusSpecialPoints">Bonus points on the account.</param>
        /// <param name="typeOfGrade">Type of account graduation.</param>
        public PersonAccount(int numvalue, string ownerFirstName, string ownerSecondName, double valueAmount, int bonusSpecialPoints, TypeOfGrade typeOfGrade)
        {
            Numvalue = numvalue;
            OwnerFirstName = ownerFirstName;
            OwnerSecondName = ownerSecondName;
            ValueAmount = valueAmount;
            BonusSpecialPoints = bonusSpecialPoints;
            TypeOfGrade = typeOfGrade;
            Grading = FactoryOfGrades.GetGrading(typeOfGrade);
        }

        /// <summary>
        /// A constructor to initialize the object.
        /// </summary>
        /// <param name="numvalue">PersonAccount numvalue.</param>
        /// <param name="ownerFirstName">Name of account holder.</param>
        /// <param name="ownerSecondName">Surname of account holder.</param>
        /// <param name="typeOfGrade">Type of account graduation.</param>
        public PersonAccount(int numvalue, string ownerFirstName, string ownerSecondName, TypeOfGrade typeOfGrade)
            : this(numvalue, ownerFirstName, ownerSecondName, 0, 0, typeOfGrade)
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// PersonAccount numvalue.
        /// </summary>
        public int Numvalue
        {
            get
            {
                return _numvalue;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(value));
                }

                _numvalue = value;
            }
        }

        /// <summary>
        /// Name of account holder.
        /// </summary>
        public string OwnerFirstName
        {
            get
            {
                return _ownerFirstName;
            }

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _ownerFirstName = value;
            }
        }

        /// <summary>
        /// Surname of account holder.
        /// </summary>
        public string OwnerSecondName
        {
            get
            {
                return _ownerSecondName;
            }

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _ownerSecondName = value;
            }
        }

        /// <summary>
        /// The valueAmount on the account.
        /// </summary>
        public double ValueAmount
        {
            get
            {
                return value_amount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(value));
                }

                value_amount = value;
            }
        }

        /// <summary>
        /// Bonus points on the account.
        /// </summary>
        public int BonusSpecialPoints
        {
            get
            {
                return _bonusSpecialPoints;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(value));
                }

                _bonusSpecialPoints = value;
            }
        }

        /// <summary>
        /// Type of account graduation.
        /// </summary>
        public TypeOfGrade TypeOfGrade
        {
            get
            {
                return _typeOfGrade;
            }

            private set
            {
                if (value == 0)
                {
                    throw new ArgumentException(nameof(value));
                }

                _typeOfGrade = value;
            }
        }

        private AccountsSortingGrades Grading
        {
            get
            {
                return _grade;
            }

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _grade = value;
            }
        }

        #endregion Properties

        #region Overridden methods

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((PersonAccount)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object, otherwise false.</returns>
        public bool Equals(PersonAccount other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Numvalue.Equals(other.Numvalue)
                && OwnerFirstName.Equals(other.OwnerFirstName)
                && OwnerSecondName.Equals(other.OwnerSecondName)
                && ValueAmount.Equals(other.ValueAmount)
                && BonusSpecialPoints.Equals(other.BonusSpecialPoints)
                && TypeOfGrade.Equals(other.TypeOfGrade);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>The string of a data about account.</returns>
        public override string ToString()
        {
            return $"Numvalue: {Numvalue};\nOwnerFirstName: {OwnerFirstName};\nOwnerSecondName: {OwnerSecondName};\nValueAmount: {ValueAmount};\nBonusPoints: {BonusSpecialPoints};\nTypeOfGrade: {TypeOfGrade}.";
        }

        /// <summary>
        /// Serves as the  hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            int hashcode = Numvalue.GetHashCode();
            hashcode = (11 * hashcode) + OwnerFirstName.GetHashCode();
            hashcode = (11 * hashcode) + OwnerSecondName.GetHashCode();
            hashcode = (11 * hashcode) + ValueAmount.GetHashCode();
            hashcode = (11 * hashcode) + BonusSpecialPoints.GetHashCode();
            hashcode = (11 * hashcode) + TypeOfGrade.GetHashCode();
            return hashcode;
        }

        #endregion Overridden methods

        #region Public methods for account replenishment/debit from account

        /// <summary>
        /// Replenishes the account with the specified valueAmount.
        /// </summary>
        /// <param name="valueAmount">The valueAmount to replenish the account.</param>
        public void AccountRefill(double valueAmount)
        {
            ValueAmount = ValueAmount + valueAmount;
            BonusSpecialPoints = Grading.IncreaseBonusPoints(BonusSpecialPoints);
        }

        /// <summary>
        /// Removes the specified valueAmount from the account.
        /// </summary>
        /// <param name="valueAmount">ValueAmount to withdraw from the account.</param>
        /// <exception cref="ArgumentException">Throw when the valueAmount to withdraw 
        /// from the account more than the available account balance.</exception>
        public void WithdrawalsFromAccount(double valueAmount)
        {
            if (valueAmount > ValueAmount)
            {
                throw new ArgumentException(nameof(valueAmount));
            }

            ValueAmount = ValueAmount - valueAmount;
            BonusSpecialPoints = Grading.ReductionBonusPoints(BonusSpecialPoints);
        }

        #endregion Public methods for account replenishment/debit from account
    }
}