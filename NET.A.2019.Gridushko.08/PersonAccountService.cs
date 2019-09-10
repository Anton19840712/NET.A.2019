using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Gridushko._08
{
    public class PersonAccountService
    {
        #region Fields

        private List<PersonAccount> _listAccounts;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// A complete constructor to initialize the object.
        /// </summary>
        /// <param name="listAccounts">Collection of accounts.</param>
        public PersonAccountService(List<PersonAccount> listAccounts)
        {
            ListAccounts = listAccounts;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PersonAccountService() : this(new List<PersonAccount>())
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Collection of accounts.
        /// </summary>
        public List<PersonAccount> ListAccounts
        {
            get
            {
                return _listAccounts;
            }

            private set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _listAccounts = value;
            }
        }

        /// <summary>
        /// The number of items in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                return _listAccounts.Count;
            }
        }

        #endregion Properties

        #region Public methods for working with list of accounts

        /// <summary>
        /// Adds a new account to an existing collection.
        /// </summary>
        /// <param name="account">A new account.</param>
        public void AddNewAccount(PersonAccount account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }

            _listAccounts.Add(account);
        }

        /// <summary>
        /// Removes an account from an existing collection.
        /// </summary>
        /// <param name="account">An account to remove from the collection.</param>
        public void CloseAccount(PersonAccount account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }

            _listAccounts.Remove(account);
        }

        #endregion Public methods for working with list of accounts

        #region Public methods for writing to/reading from a file

        /// <summary>
        /// Reads account data from a file.
        /// </summary>
        public void ReadDataFromFile()
        {
            ListAccounts = AccountsRepository.ReadDataFromFile();
        }

        /// <summary>
        /// Writes the collection to a file.
        /// </summary>
        public void WriteDataToFile()
        {
            AccountsRepository.WriteDataToFile(ListAccounts);
        }

        #endregion Public methods for writing to/reading from a file
    }
}
