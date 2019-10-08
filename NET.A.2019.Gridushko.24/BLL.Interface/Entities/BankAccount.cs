using System;

namespace NET.A._2019.Gridushko._22
{
    /// <summary>
    /// Aspects for working with the account.
    /// </summary>
    public class BankAccount
    {
        private int id;
        private string nameOwner;
        private string ownerSurname;
        private double amount;
        private int bonusPoints;
        private GradingVariant typeGrading;

        public BankAccount(int id, string nameOwner, string ownerSurname, double amount, int bonusPoints, GradingVariant gradingType)
        {
            this.Id = id;
            this.NameOwner = nameOwner;
            this.SurnameOwner = ownerSurname;
            this.Amount = amount;
            this.PointsForBonus = bonusPoints;
            this.GradingVariants = gradingType;
        }

        /// <summary>
        /// Account id.
        /// </summary>
        public int Id
        {
            get => this.id;
 
            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Name holder of bank account
        /// </summary>
        public string NameOwner
        {
            get => this.nameOwner;

            set
            {
                this.nameOwner = value;
            }
        }

        /// <summary>
        /// Surname holder of bank account
        /// </summary>
        public string SurnameOwner
        {
            get => this.ownerSurname;

            set
            {
                this.ownerSurname = value;
            }
        }

        public double Amount
        {
            get => this.amount;

            set
            {
                this.amount = value;
            }
        }

        public int PointsForBonus
        {
            get => this.bonusPoints;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(value));
                }

                this.bonusPoints = value;
            }
        }

        /// <summary>
        /// Type of bank account graduation.
        /// </summary>
        public GradingVariant GradingVariants
        {
            get => this.typeGrading;

            set
            {
                this.typeGrading = value;
            }
        }

        /// <summary>
        /// If object is equal to the current object.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
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

            return this.Equals((BankAccount)obj);
        }

        /// <summary>
        /// If object is equal to the current object
        /// </summary>
        public bool Equals(BankAccount other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Id.Equals(other.id)
                && this.NameOwner.Equals(other.NameOwner)
                && this.SurnameOwner.Equals(other.SurnameOwner)
                && this.Amount.Equals(other.Amount)
                && this.PointsForBonus.Equals(other.PointsForBonus)
                && this.GradingVariants.Equals(other.GradingVariants);
        }

        public override string ToString()
        {
            return $"Id: {Id};\nOwnerName: {NameOwner};\nOwnerSurname: {SurnameOwner};\nAmount: {Amount};\nBonusPoints: {PointsForBonus};\nTypeGrading: {GradingVariants}.";
        }

        /// <summary>
        /// Works as the  hash function.
        /// </summary>
        /// 
        public override int GetHashCode()
        {
            int hashcode = this.Id.GetHashCode();
            hashcode = (11 * hashcode) + this.NameOwner.GetHashCode();
            hashcode = (11 * hashcode) + this.SurnameOwner.GetHashCode();
            hashcode = (11 * hashcode) + this.Amount.GetHashCode();
            hashcode = (11 * hashcode) + this.PointsForBonus.GetHashCode();
            hashcode = (11 * hashcode) + this.GradingVariants.GetHashCode();
            return hashcode;
        }
    }
}