using System;
using CustomerLib.Entities.Validators;
using System.Collections.Generic;
using System.Text;
namespace CustomerLib
{
    public class Program
    {
        public static IConsoleWrapper ConsoleWrapper { get; set; } = new ConsoleWrapper();
        public static void Main(string[] args)
        {
            Customer customer = new Customer();
            ConsoleWrapper.WriteLine("Enter new customer`s data: \n");
            
            ConsoleWrapper.Write("Name: ");     
            customer.FirstName = ConsoleWrapper.ReadLine();
            ConsoleWrapper.Write("Surname: ");  
            customer.LastName = ConsoleWrapper.ReadLine();
            ConsoleWrapper.Write("Phone: ");    customer.Phone = ConsoleWrapper.ReadLine();
            ConsoleWrapper.Write("Email: ");    customer.Email = ConsoleWrapper.ReadLine();
            ConsoleWrapper.Write("Total purchases amount: ");   customer.TotalPurchasesAmount = Convert.ToDecimal(ConsoleWrapper.ReadLine());
            int key;
            do {
                ConsoleWrapper.Write("Enter at least one note about customer: \n");
                customer.Notes.Add(ConsoleWrapper.ReadLine());
                ConsoleWrapper.Write("Do you want to add another one? (1/2) \n");
                key = Convert.ToInt32(ConsoleWrapper.ReadLine());
            } while (key == '1');
            //do
            //{
            //    ConsoleWrapper.Write("Enter at least one customer`s address: \n");
            //    Address address = new Address();
            //    ConsoleWrapper.Write("Line1: ");             address.Line1 = ConsoleWrapper.ReadLine();
            //    ConsoleWrapper.Write("US or Canada? (1/2)"); 
            //    address.AddressType = (Address.EAddressType)Convert.ToInt32(ConsoleWrapper.ReadLine());
            //    ConsoleWrapper.Write("City: ");              address.City = ConsoleWrapper.ReadLine();
            //    ConsoleWrapper.Write("Postal Code: ");       address.PostalCode = ConsoleWrapper.ReadLine();
            //    ConsoleWrapper.Write("State: ");             address.State = ConsoleWrapper.ReadLine();
            //    ConsoleWrapper.Write("Country: ");           address.Country = ConsoleWrapper.ReadLine();
            //
            //    AddressValidator addressValidator = new AddressValidator();
            //    if (addressValidator.Validate(address).IsValid)
            //    {
            //        customer.Addresses.Add(address);
            //        ConsoleWrapper.Write("Do you want to add another one address? (Y/n) \n");
            //        key = Convert.ToInt32(ConsoleWrapper.ReadLine());
            //    }
            //    else
            //        ConsoleWrapper.WriteLine("Address has incorrect values.");
            //} while (key == 'Y');
            customer.Addresses.Add(new Address() { 
                Line1 = "dd", 
                AddressType = Address.EAddressType.Biling,
                City = "Denver",
                PostalCode = "121212",
                State = "State",
                Country = "United States"
            });
            CustomerValidator customerValidator = new CustomerValidator();
            if (customerValidator.Validate(customer).IsValid)
                ConsoleWrapper.WriteLine("Success");
            else
                ConsoleWrapper.WriteLine("Fail");

        }
    }
}
