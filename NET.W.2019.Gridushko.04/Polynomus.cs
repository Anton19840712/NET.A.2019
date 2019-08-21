using System;

namespace NET.W._2019.Gridushko._04
{
    public sealed class Polynomus
    {
        /// <summary>
        /// Initialization of epsilon for accuracy during counting
        /// </summary>
        public static double epsilon = 0.001;

        private double[] multipliers;

        /// <summary>
        /// Initialization of new instance of Polynomus
        /// </summary>
        /// <param name="multiplier"></param>
        public Polynomus(params double[] multiplier)
        {
            if (multiplier == null)//Checking our coefficient for null 
            {
                throw new ArgumentNullException("Polynomus never could be null!", nameof(multiplier));
            }
            Exponent = multiplier.Length - 1;
            multipliers = new double[Exponent + 1];
            int nullCoef = 0;
            for (int i = 0; i <= Exponent; i++)
            {
                if (multiplier[i] == 0)
                {
                    nullCoef++;
                }
                this[i] = multiplier[i];
            }

            if (nullCoef == Exponent + 1)
            {
                Exponent = 0;
                multipliers = new double[Exponent + 1];
                multipliers[0] = 0;
            }
        }
        private Polynomus(int exponent)
        {
            Exponent = exponent;
            multipliers = new double[Exponent + 1];
        }
        /// <summary>
        /// Getting exponent 
        /// </summary>
        public int Exponent { get; private set; }

        /// <summary>
        /// Indexer
        /// </summary>
        public double this[int i]
        {
            get
            {
                if (Exponent > multipliers.Length)
                {
                    throw new ArgumentOutOfRangeException("Wrong index");
                }
                return multipliers[i];
            }
            private set
            {
                if (i < 0 && i >= multipliers.Length)
                {
                    throw new ArgumentOutOfRangeException("Wrong index");
                }
                multipliers[i] = value;
            }
        }

        /// <summary>
        /// Overloads and operators
        /// </summary>
        /// <param name="firstPolinom"></param>
        /// <param name="secondPolinom"></param>
        /// <returns></returns>
        public static Polynomus operator +(Polynomus firstPolinom, Polynomus secondPolinom)
        {
            if (firstPolinom is null)
            {
                throw new ArgumentNullException("First Polynomus isnt null");
            }
            if (secondPolinom is null)
            {
                throw new ArgumentNullException("Second potynomial inst null");
            }

            Polynomus more, less;
            if (firstPolinom.Exponent > secondPolinom.Exponent)
            {
                more = firstPolinom.Clone();
                less = secondPolinom.Clone();
            }
            else
            {
                more = secondPolinom.Clone();
                less = firstPolinom.Clone();
            }

            for (int i = 0; i <= less.Exponent; i++)
            {
                more[i] += less[i];
            }

            Polynomus resultPolynomial = new Polynomus(more.multipliers);
            return resultPolynomial;
        }

        /// <summary>
        /// Operator "-" overloading
        /// </summary>
        /// <param name="firstPolinom"></param>
        /// <param name="secondPolinom"></param>
        /// <returns></returns>
        public static Polynomus operator -(Polynomus firstPolinom, Polynomus secondPolinom)
        {
            if (firstPolinom is null)
            {
                throw new ArgumentNullException("First Polynomus can not be null");
            }
            if (secondPolinom is null)
            {
                throw new ArgumentNullException("Second potynomial ca not be null");
            }

            Polynomus more, less;
            if (firstPolinom.Exponent > secondPolinom.Exponent)
            {
                more = firstPolinom.Clone();
                less = secondPolinom.Clone();
            }
            else
            {
                more = secondPolinom.Clone();
                less = firstPolinom.Clone();
            }

            for (int i = 0; i <= less.Exponent; i++)
            {
                more[i] -= less[i];
            }

            Polynomus resultPolynomial = new Polynomus(more.multipliers);
            return resultPolynomial;
        }

        /// <summary>
        /// Operator "*" overloading
        /// </summary>
        /// <param name="firstPolinom"></param>
        /// <param name="secondPolinom"></param>
        /// <returns></returns>
        public static Polynomus operator *(Polynomus firstPolinom, Polynomus secondPolinom)
        {
            Polynomus resultPolynomial = new Polynomus(firstPolinom.Exponent + secondPolinom.Exponent);
            for (int i = 0; i <= firstPolinom.Exponent; i++)
            {
                for (int j = 0; j <= secondPolinom.Exponent; j++)
                {
                    resultPolynomial.multipliers[i + j] += firstPolinom[i] * secondPolinom[j];
                }
            }
            return resultPolynomial;
        }

        /// <summary>
        /// Operator "==" overloading
        /// </summary>
        /// <param name="firstPolinom"></param>
        /// <param name="secondPolinom"></param>
        /// <returns></returns>
        public static bool operator ==(Polynomus firstPolinom, Polynomus secondPolinom)
        {
            if (ReferenceEquals(firstPolinom, secondPolinom))
            {
                return true;
            }

            if (firstPolinom is null || secondPolinom is null)
            {
                return false;
            }

            if (firstPolinom.Exponent != secondPolinom.Exponent)
            {
                return false;
            }
            else
            {
                for (int i = 0; i <= firstPolinom.Exponent; i++)
                {
                    if (Math.Abs(firstPolinom[i] - secondPolinom[i]) >= epsilon)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Operator "!=" overloading
        /// </summary>
        /// <param name="firstPolinom"></param>
        /// <param name="secondPolinom"></param>
        /// <returns></returns>
        public static bool operator !=(Polynomus firstPolinom, Polynomus secondPolinom)
        {
            return !(firstPolinom.Exponent == secondPolinom.Exponent);
        }

        public override string ToString()
        {
            string stringRepresentation = null;
            for (int i = 0; i <= Exponent; i++)
            {
                if (this[i] == 0)
                {
                    continue;
                }
                if (stringRepresentation != null)
                {
                    if (this[i] > 0)
                    {
                        stringRepresentation += "+";
                    }
                }
                if (i == 0)
                {
                    stringRepresentation += this[i];
                    continue;
                }
                if (i == 1)
                {
                    stringRepresentation += this[i];
                    stringRepresentation += $"x";
                    continue;
                }
                if (this[i] != 1)
                {
                    if (this[i] == -1)
                    {
                        stringRepresentation += "-";
                    }
                    else
                    {
                        stringRepresentation += this[i];
                    }
                }
                stringRepresentation += $"x^{i}";
            }
            return stringRepresentation;
        }

        /// <summary>
        ///  Equation of polynoms
        /// </summary>
        /// <param name="anotherOne"></param>
        /// <returns></returns>
        public bool Equals(Polynomus anotherOne)
        {
            if (anotherOne is null)
            {
                return false;
            }
            if (ReferenceEquals(this, anotherOne))
            {
                return true;
            }
            if (multipliers.Length != anotherOne.multipliers.Length)
            {
                return false;
            }
            return this == anotherOne;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != GetType())
            {
                return false;
            }
            return Equals((Polynomus)obj);
        }

        /// <summary>
        /// Getting HashCode for our instance
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hashCode = 0;
            for (int i = 0; i <= Exponent; i++)
            {
                hashCode += this[i].GetHashCode() * i.GetHashCode();
            }
            return hashCode;
        }

        private Polynomus Clone()
        {
            return new Polynomus
            {
                multipliers = multipliers,
                Exponent = Exponent
            };
        }
    }
}
