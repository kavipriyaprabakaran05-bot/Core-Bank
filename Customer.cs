using System;

namespace CoreBankSystem
{
    class Customer
    {
        public string CustomerID { get; private set; }   
        public string CustomerName { get; set; }
        public string City { get; set; }

        public Customer(string customerName, string city)
        {
            CustomerName = customerName;
            City = city;

            CustomerID =
                CustomerName.Substring(0, 2).ToUpper() + "-" +
                City.Substring(0, 2).ToUpper();
               
        }

        
        public void DisplayCustomerDetails()
        {
            Console.WriteLine("Customer ID: " + CustomerID);
            Console.WriteLine("Customer Name: " + CustomerName);
            Console.WriteLine("City: " + City);
        }
    }
}

