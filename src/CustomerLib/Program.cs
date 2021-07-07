using System;
using CustomerLib.Entities.Validators;
using CustomerLib.Entities;

namespace CustomerLib
{
    public class Program
    {
        public static IConsoleWrapper ConsoleWrapper { get; set; } = new ConsoleWrapper();
        public static void Main(string[] args)
        {
            Customer customer = new Customer();
            ConsoleWrapper.WriteLine("Enter new customer`s data: \n");
            
            ConsoleWrapper.Write("Name: ");     customer.FirstName = ConsoleWrapper.ReadLine();
            ConsoleWrapper.Write("Surname: ");  customer.LastName = ConsoleWrapper.ReadLine();
            ConsoleWrapper.Write("Phone: ");    customer.PhoneNumber = ConsoleWrapper.ReadLine();
            ConsoleWrapper.Write("Email: ");    customer.Email = ConsoleWrapper.ReadLine();
            ConsoleWrapper.Write("TPA: ");   customer.TotalPurchasesAmount = Convert.ToDecimal(ConsoleWrapper.ReadLine());

            do {
                ConsoleWrapper.Write("Enter at least one note about customer: \n");
                customer.Notes.Add(new Note
                {
                    Line = ConsoleWrapper.ReadLine()
                });
                ConsoleWrapper.Write("Do you want to add another one? (Y/n) \n");
                
            } while (ConsoleWrapper.ReadLine() == "Y");
            
            do
            {
                ConsoleWrapper.Write("Enter at least one customer`s address: \n");
                Address address = new Address();
                ConsoleWrapper.Write("Line1: ");             address.Line1 = ConsoleWrapper.ReadLine();
                ConsoleWrapper.Write("Billing or Shipping? (0/1)"); 
                address.AddressType = (Address.EAddressType)Convert.ToInt32(ConsoleWrapper.ReadLine());
                ConsoleWrapper.Write("City: ");              address.City = ConsoleWrapper.ReadLine();
                ConsoleWrapper.Write("Postal Code: ");       address.PostalCode = ConsoleWrapper.ReadLine();
                ConsoleWrapper.Write("State: ");             address.State = ConsoleWrapper.ReadLine();
                ConsoleWrapper.Write("Country: ");           address.Country = ConsoleWrapper.ReadLine();
            
                if (new AddressValidator().Validate(address).IsValid)
                    customer.Addresses.Add(address);
                else
                    ConsoleWrapper.WriteLine("Address has incorrect values.");
                
                ConsoleWrapper.Write("Do you want to add another one address? (Y/n) \n");

            } while (ConsoleWrapper.ReadLine() == "Y");

            if (new CustomerValidator().Validate(customer).IsValid)
                ConsoleWrapper.WriteLine("Success");
            else
                ConsoleWrapper.WriteLine("Fail");

        }
    }
}
