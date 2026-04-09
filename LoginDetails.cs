using System;

namespace CoreBankSystem
{
    class LoginDetails
    {
        public string LoginID { get; private set; }
        public string Password { get; private set; }
        public string LoginType { get; private set; }

        public LoginDetails(string customerId)
        {
            LoginType = "Customer";
            LoginID = customerId;      
            Password = LoginID; 
        }

       

        public void DisplayLoginDetails()
        {
            Console.WriteLine("Login ID: " + LoginID);
            Console.WriteLine("Login Type: " + LoginType);
            Console.WriteLine("Password: " + Password);
        }
    }
}
