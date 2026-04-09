
using System;
using System.Collections.Generic;
using System.IO;
using System.Transactions;

namespace CoreBankSystem
{
    class CoreBankDataStore
    {
        public List<Account> Accounts { get; set; }
        public List<Branch> Branches { get; set; }
        public List<Customer> Customers { get; set; }
        public List<LoginDetails> Logins { get; set; }
        public List<Transaction> Transactions { get; set; }

        public CoreBankDataStore()
        {
            Accounts = new List<Account>();
            Branches = new List<Branch>();
            Customers = new List<Customer>();
            Logins = new List<LoginDetails>();
            Transactions = new List<Transaction>();

            FetchAccounts();
            FetchBranches();
            FetchCustomers();
            FetchLogins();
            FetchTransactions();
        }


        public void FetchAccounts()
        {
            if (File.Exists("Accounts.csv"))
            {
                var lines = File.ReadAllLines("Accounts.csv");

                foreach (var line in lines)
                {
                    var data = line.Split(',');

                    if (data.Length == 7)
                    {
                        Account acc = new Account(
                            data[0],                     // AccountHolderName
                            data[1],                     // AccountType
                            data[2],                     // BranchName
                            decimal.Parse(data[3]),      // Balance
                            data[4],                     // IFSCCode
                            data[5],                     // CurrencyType
                            data[6]                      // Language
                        );

                        Accounts.Add(acc);
                    }
                }
            }
        }


        public void FetchBranches()
        {
            if (File.Exists("Branches.csv"))
            {
                var lines = File.ReadAllLines("Branches.csv");
                foreach (var line in lines)
                {
                    var data = line.Split(',');
                    Branch branch = new Branch(data[0], data[1]);
                    Branches.Add(branch);
                }
            }
        }

        public void FetchCustomers()
        {
            if (File.Exists("Customers.csv"))
            {
                var lines = File.ReadAllLines("Customers.csv");
                foreach (var line in lines)
                {
                    var data = line.Split(',');
                    Customer cust = new Customer(data[0], data[1]);
                    Customers.Add(cust);
                }
            }
        }

        public void FetchLogins()
        {
            if (File.Exists("Login.csv"))
            {
                var lines = File.ReadAllLines("Login.csv");
                foreach (var line in lines)
                {
                    var data = line.Split(',');
                    LoginDetails login = new LoginDetails(data[0]);
                    Logins.Add(login);
                }
            }
        }

        public void FetchTransactions()
        {
            if (File.Exists("Transactions.csv"))
            {
                var lines = File.ReadAllLines("Transactions.csv");
                foreach (var line in lines)
                {
                    var data = line.Split(',');
                    Transaction t = new Transaction(data[1], data[2],
                        decimal.Parse(data[4]), data[6],
                        decimal.Parse(data[5]));
                    Transactions.Add(t);
                }
            }
        }


        public void AddAccount(Account obj)
        {
            if (obj == null)
                throw new NullReferenceException("Account details can’t be null");

            Accounts.Add(obj);
            File.AppendAllText("Accounts.csv",
                $"{obj.AccountID},{obj.AccountType},{obj.Balance}\n");
        }

        public void AddBranch(Branch obj)
        {
            if (obj == null)
                throw new NullReferenceException("Branch details can’t be null");

            Branches.Add(obj);
            File.AppendAllText("Branches.csv",
                $"{obj.BranchName},{obj.Location}\n");
        }

        public void AddCustomers(Customer obj)
        {
            if (obj == null)
                throw new NullReferenceException("Customer details can’t be null");

            Customers.Add(obj);
            File.AppendAllText("Customers.csv",
                $"{obj.CustomerName},{obj.City}\n");
        }

        public void AddLogin(LoginDetails obj)
        {
            if (obj == null)
                throw new NullReferenceException("Login details can’t be null");

            Logins.Add(obj);
            File.AppendAllText("Login.csv",
                $"{obj.LoginID},{obj.LoginType}\n");
        }

        public void AddTransactions(Transaction obj)
        {
            if (obj == null)
                throw new NullReferenceException("Transaction details can’t be null");

            Transactions.Add(obj);
            File.AppendAllText("Transactions.csv",
                $"{obj.TransactionID},{obj.AccountID},{obj.TransactionType},{obj.TransactionDate},{obj.Amount},{obj.BalanceAfterTransaction},{obj.Email},{obj.TransactionStatus}\n");
        }


        public void DisplayAccounts()
        {
            foreach (var acc in Accounts)
                acc.DisplayAccountDetails();
        }

        public void DisplayBranches()
        {
            foreach (var branch in Branches)
                branch.DisplayBranchDetails();
        }

        public void DisplayCustomers()
        {
            foreach (var cust in Customers)
                cust.DisplayCustomerDetails();
        }

        
    }
}
