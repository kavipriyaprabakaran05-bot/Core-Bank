using System;

public class InvalidBalanceException : Exception
{
    public InvalidBalanceException()
        : base("The mentioned account balance is invalid. Please ensure to enter a valid balance")
    {
    }
}
