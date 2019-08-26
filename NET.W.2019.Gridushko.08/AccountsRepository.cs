using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NET.W._2019.Gridushko._08
{
    public static class AccountsRepository
    {
        #region Static constructor

        /// <summary>
        /// The static cinstructor to initialize the Path.
        /// </summary>
        static AccountsRepository()
        {
            Path = AppDomain.CurrentDomain.BaseDirectory + "AccountListRepository.txt";
        }

        #endregion Static constructor

        #region Properties

        /// <summary>
        /// The path to the file with the collection of accounts.
        /// </summary>
        public static string Path { get; private set; }

        #endregion Properties

        #region Method for working with file

        /// <summary>
        /// Reads account data from a file and creates a collection.
        /// </summary>
        /// <returns>The collection of accounts.</returns>
        public static List<PersonAccount> ReadDataFromFile()
        {
            var listAccounts = new List<PersonAccount>();

            FileStream file = new FileStream(Path, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(file);

            if (reader.PeekChar() == -1)
            {
                throw new IOException("File is empty.");
            }

            while (reader.PeekChar() != -1)
            {
                listAccounts.Add(new PersonAccount(
                    reader.ReadInt32(),
                    reader.ReadString(),
                    reader.ReadString(),
                    reader.ReadDouble(),
                    reader.ReadInt32(),
                    (TypeOfGrade)reader.ReadInt32()));
            }

            reader.Close();
            file.Close();

            return listAccounts;
        }

        /// <summary>
        /// Writes the collection to a file.
        /// </summary>
        /// <param name="listAccounts">The collection of accounts.</param>
        public static void WriteDataToFile(List<PersonAccount> listAccounts)
        {
            if (ReferenceEquals(null, listAccounts))
            {
                throw new ArgumentNullException(nameof(listAccounts));
            }

            FileStream file = new FileStream(Path, FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);

            for (int i = 0; i < listAccounts.Count; i++)
            {
                writer.Write(listAccounts.ElementAt(i).Numvalue);
                writer.Write(listAccounts.ElementAt(i).OwnerFirstName);
                writer.Write(listAccounts.ElementAt(i).OwnerSecondName);
                writer.Write(listAccounts.ElementAt(i).ValueAmount);
                writer.Write(listAccounts.ElementAt(i).BonusSpecialPoints);
                writer.Write((int)listAccounts.ElementAt(i).TypeOfGrade);
            }

            writer.Close();
            file.Close();
        }

        #endregion Method for working with file
    }
}
