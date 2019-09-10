using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.A._2019.Gridushko._15
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string NameOwner { get; set; }
        public string SurnameOwner { get; set; }
        public decimal Amount { get; set; }
        public int PointsForBonus { get; set; }
        public int GradingVariants { get; set; }
    }
}
