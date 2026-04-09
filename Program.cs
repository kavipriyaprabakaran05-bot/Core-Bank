using CoreBankSystem;

static void Main(string[] args)
{
    try
    {
        Console.WriteLine("Enter Account Holder Name:");
        string name = Console.ReadLine() ?? "";

        Console.WriteLine("Enter Account Type:");
        string type = Console.ReadLine() ?? "";

        Console.WriteLine("Enter Branch Name:");
        string branch = Console.ReadLine() ?? "";

        Console.WriteLine("Enter Initial Balance:");
        decimal balance = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Enter IFSC Code:");
        string ifsc = Console.ReadLine() ?? "";

        Console.WriteLine("Enter Currency Type:");
        string currency = Console.ReadLine() ?? "";

        Console.WriteLine("Enter Language (English/Tamil):");
        string language = Console.ReadLine() ?? "";

        Account account = new Account(name, type, branch, balance, ifsc, currency, language);

        account.DisplayAccountDetails();

        Console.WriteLine("\nEnter Transaction Type (Deposit/Withdrawal):");
        string transactionType = Console.ReadLine() ?? "";

        Console.WriteLine("Enter Amount:");
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Enter Email:");
        string email = Console.ReadLine() ?? "";

        Transaction transaction = new Transaction(account, transactionType, amount, email);

        transaction.DisplayTransactionDetails();
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }

    Console.WriteLine("Press Enter to Exit...");
    Console.ReadLine();
}
