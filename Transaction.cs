using System;

namespace CoreBankSystem
{
    internal class Transaction
    {
        private static int counter = 10000;

        public int TransactionID { get; private set; }
        public string AccountID { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public decimal BalanceAfterTransaction { get; set; }
        public string Email { get; set; }
        public string TransactionStatus { get; set; } = "";

        // Constructor for performing real transactions
        public Transaction(Account account, string transactionType, decimal amount, string email)
        {
            TransactionID = counter++;
            AccountID = account.AccountID;
            TransactionType = transactionType;
            Amount = amount;
            Email = email;
            TransactionDate = DateTime.Now;

            if (transactionType == "Deposit")
            {
                account.Balance += amount;
            }
            else if (transactionType == "Withdrawal")
            {
                if (account.Balance < amount)
                {
                    Console.WriteLine("Insufficient Balance!");
                    TransactionStatus = "Failed";
                    return;
                }

                account.Balance -= amount;
            }

            BalanceAfterTransaction = account.Balance;
            TransactionStatus = "Success";
        }

        // ✅ Constructor for loading transactions from CSV file
        public Transaction(string accountId, string transactionType,
                           decimal amount, string email,
                           decimal balanceAfterTransaction)
        {
            TransactionID = counter++;
            AccountID = accountId;
            TransactionType = transactionType;
            Amount = amount;
            Email = email;
            BalanceAfterTransaction = balanceAfterTransaction;
            TransactionDate = DateTime.Now;
            TransactionStatus = "Success";
        }

        public void DisplayTransactionDetails()
        {
            Console.WriteLine("Transaction ID: " + TransactionID);
            Console.WriteLine("Account ID: " + AccountID);
            Console.WriteLine("Type: " + TransactionType);
            Console.WriteLine("Amount: " + Amount);
            Console.WriteLine("Date: " + TransactionDate);
            Console.WriteLine("Balance After Transaction: " + BalanceAfterTransaction);
            Console.WriteLine("Status: " + TransactionStatus);
        }
    }
}
