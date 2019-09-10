using System;
using System.Collections.Generic;
namespace NET.A._2019.Gridushko._15.BLL.Interface.Interfaces
{
    public interface IBankAccountService
    {
        IEnumerable<BankAccount> GetAll();
        void Open(string ownerName, string ownerSurname, double amount, GradingVariant gradingType);
        void Close(int id);
        void Refill(int id, double amount);
        void Withdrawal(int id, double amount);        
    }
}