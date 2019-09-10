using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NET.A._2019.Gridushko._15
{
    public class AccountsFileStorage : IRepository
    {
        static AccountsFileStorage()
        {
            Path = AppDomain.CurrentDomain.BaseDirectory + "AccountListStorage.txt";
        }
        public AccountsFileStorage(IEnumerable<Account> listAccounts)
        {
            this.WriteDataToFile(listAccounts);
        }
        public static string Path { get; private set; }
        public IEnumerable<Account> GetAll()
        {
            return this.ReadDataFromFile();
        }
        public Account Get(int id)
        {
            Account account = this.ReadDataFromFile()
                .ToList()
                .Find(element => element.Id == id);

            if (ReferenceEquals(null, account))
            {
                throw new KeyNotFoundException("Account with such id is not found.");
            }

            return account;
        }
        public void Add(Account account)
        {
            List<Account> listAccounts = this.ReadDataFromFile().ToList();

            if (listAccounts.Exists(element => element.Id == account.Id))
            {
                throw new DuplicateWaitObjectException("This account already exists.");
            }

            listAccounts.Add(account);
            this.AppendDataToFile(account);
        }
        public void Update(Account account)
        {
            List<Account> listAccounts = this.ReadDataFromFile().ToList();

            Account findingAccount = listAccounts.Find(element => element.Id == account.Id);

            if (ReferenceEquals(null, findingAccount))
            {
                throw new KeyNotFoundException("This account is not found.");
            }

            int index = listAccounts.IndexOf(findingAccount);

            listAccounts.Remove(findingAccount);
            listAccounts.Insert(index, account);

            this.WriteDataToFile(listAccounts);
        }
        public void Delete(Account account)
        {
            List<Account> listAccounts = this.ReadDataFromFile().ToList();

            Account findingAccount = listAccounts.Find(element => element.Id == account.Id);

            if (ReferenceEquals(null, findingAccount))
            {
                throw new KeyNotFoundException("This account is not found.");
            }

            listAccounts.Remove(findingAccount);

            this.WriteDataToFile(listAccounts);
        }
        private IEnumerable<Account> ReadDataFromFile()
        {
            var listAccounts = new List<Account>();

            FileStream file = new FileStream(Path, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(file);

            while (reader.PeekChar() != -1)
            {
                Account account = new Account
                {
                    Id = reader.ReadInt32(),
                    NameOwner = reader.ReadString(),
                    SurnameOwner = reader.ReadString(),
                    Amount = reader.ReadDouble(),
                    PointsForBonus = reader.ReadInt32(),
                    GradingVariants = reader.ReadInt32()
                };
                listAccounts.Add(account);
            }

            reader.Close();
            file.Close();

            return listAccounts;
        }

        private void WriteDataToFile(IEnumerable<Account> listAccounts)
        {
            if (ReferenceEquals(null, listAccounts))
            {
                throw new ArgumentNullException(nameof(listAccounts));
            }

            FileStream file = new FileStream(Path, FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);

            foreach (var account in listAccounts)
            {
                writer.Write(account.Id);
                writer.Write(account.NameOwner);
                writer.Write(account.SurnameOwner);
                writer.Write(account.Amount);
                writer.Write(account.PointsForBonus);
                writer.Write(account.GradingVariants);
            }

            writer.Close();
            file.Close();
        }
        private void AppendDataToFile(Account account)
        {
            if (ReferenceEquals(null, account))
            {
                throw new ArgumentNullException(nameof(account));
            }

            FileStream file = new FileStream(Path, FileMode.Append, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);

            writer.Write(account.Id);
            writer.Write(account.NameOwner);
            writer.Write(account.SurnameOwner);
            writer.Write(account.Amount);
            writer.Write(account.PointsForBonus);
            writer.Write(account.GradingVariants);

            writer.Close();
            file.Close();
        }
    }
}