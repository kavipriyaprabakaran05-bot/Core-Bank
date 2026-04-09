using System;

namespace CoreBankSystem
{
    internal class Account
    {
        public string AccountID { get; private set; }
        public string AccountHolderName { get; set; }
        public string AccountType { get; set; }
        public string BranchName { get; set; }
        public decimal Balance { get; set; }
        public string IFSCCode { get; private set; }
        public string CurrencyType { get; set; }
        public string Language { get; set; }

        public Account(string accountName, string accountType, string branchName,
                       decimal balance, string ifscCode,
                       string currencyType, string language)
        {
            // 🔹 Validation (Section 2 Requirement)

            if (balance <= 0)
            {
                throw new InvalidBalanceException();
            }

            if (language != "English" && language != "Tamil")
            {
                throw new InvalidLanguageException();
            }

            // 🔹 Assign values correctly
            AccountHolderName = accountName;
            AccountType = accountType;
            BranchName = branchName;
            Balance = balance;
            IFSCCode = ifscCode;
            CurrencyType = currencyType;
            Language = language;

            // 🔹 Generate Account ID
            AccountID =
                accountName.Substring(0, 2).ToUpper() + "-" +
                accountType.Substring(0, 2).ToUpper() + "-" +
                branchName.Substring(0, 2).ToUpper() + "-" +
                language.Substring(0, 2).ToUpper();
        }

        public void DisplayAccountDetails()
        {
            Console.WriteLine("Account ID: " + AccountID);
            Console.WriteLine("Name: " + AccountHolderName);
            Console.WriteLine("Type: " + AccountType);
            Console.WriteLine("Branch: " + BranchName);
            Console.WriteLine("Balance: " + Balance);
            Console.WriteLine("IFSC Code: " + IFSCCode);
            Console.WriteLine("Currency: " + CurrencyType);
            Console.WriteLine("Language: " + Language);
        }
    }
}
