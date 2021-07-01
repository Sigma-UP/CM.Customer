using System.Collections.Generic;
using CustomerLib.Repositories;
using Xunit;
namespace CustomerLib.Test.Repositories
{
    public class CustomerRepositoryTest
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomerRepository()
        {
            var customerRepository = new CustomerRepository();
            Assert.NotNull(customerRepository);
        }


        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {

            var cutomerRepository = new CustomerRepository();

            var address1 = new Address()
            {
                Line1 = "CustomerLine1",
                Line2 = "CustomerLine2",
                AddressType = Address.EAddressType.Shipping,
                City = "Denver",
                PostalCode = "121212",
                State = "State",
                Country = "Canada"
            };

            string note1 = "Customer Note";

            var customer = new Customer() { 
                FirstName = "Alex",
                LastName = "Xlea",
                Addresses = new List<Address>() { address1 },
                Notes = new List<string>() { note1},
                Phone = "+36098983443",
                Email = "myname@gmail.com",
                TotalPurchasesAmount = (decimal?)1234.3
            };

            cutomerRepository.Create(customer);

            var createdCustomer = cutomerRepository.Read(1);
            Assert.NotNull(createdCustomer);

            Assert.Equal(customer.FirstName, createdCustomer.FirstName);
            Assert.Equal(customer.LastName, createdCustomer.LastName);


            Assert.Equal(customer.Addresses[0].AddressType, createdCustomer.Addresses[0].AddressType);
            Assert.Equal(customer.Addresses[0].City, createdCustomer.Addresses[0].City);
            Assert.Equal(customer.Addresses[0].PostalCode, createdCustomer.Addresses[0].PostalCode);

            Assert.Equal(customer.Notes[0], createdCustomer.Notes[0]);

        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            var customerRepository = new CustomerRepository();

            var address1 = new Address()
            {
                Line1 = "CustomerLine1",
                Line2 = "CustomerLine2",
                AddressType = Address.EAddressType.Shipping,
                City = "Denver",
                PostalCode = "121212",
                State = "State",
                Country = "Canada"
            };

            string note1 = "Customer Note";

            var customer = new Customer()
            {
                FirstName = "Alex",
                LastName = "Xlea",
                Addresses = new List<Address>() { address1 },
                Notes = new List<string>() { note1 },
                Phone = "+36098983443",
                Email = "myname@gmail.com",
                TotalPurchasesAmount = (decimal?)1234.3
            };
            var readedCustomer = customerRepository.Read(1);
            Assert.NotNull(readedCustomer);

            Assert.Equal(customer.FirstName, readedCustomer.FirstName);
            Assert.Equal(customer.LastName, readedCustomer.LastName);
            Assert.Equal(customer.Addresses[0].Line1, readedCustomer.Addresses[0].Line1);
            Assert.Equal(customer.Notes[0], readedCustomer.Notes[0]);
            Assert.Equal(customer.Phone, readedCustomer.Phone);
            Assert.Equal(customer.Email, readedCustomer.Email);
            Assert.Equal(customer.TotalPurchasesAmount, readedCustomer.TotalPurchasesAmount);

        }

        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            var customerRepository = new CustomerRepository();
            var address1 = new Address()
            {
                Line1 = "CustomerLine1",
                Line2 = "CustomerLine2",
                AddressType = Address.EAddressType.Shipping,
                City = "Denver",
                PostalCode = "121212",
                State = "State",
                Country = "Canada"
            };

            string note1 = "Customer Note";

            var customer = new Customer()
            {
                FirstName = "Alex",
                LastName = "Alekseev",
                Addresses = new List<Address>() { address1 },
                Notes = new List<string>() { note1 },
                Phone = "+36098983443",
                Email = "myname@gmail.com",
                TotalPurchasesAmount = (decimal?)1234.3
            };
            customerRepository.Update(customer, 2);

            var updatedCustomer = customerRepository.Read(2);
            Assert.NotNull(updatedCustomer);

            Assert.Equal(customer.FirstName, updatedCustomer.FirstName);
            Assert.Equal(customer.LastName, updatedCustomer.LastName);
            Assert.Equal(customer.Phone, updatedCustomer.Phone);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var customerRepository = new CustomerRepository();
            int customerId = 1;

            customerRepository.Delete(customerId);
            Assert.Null(customerRepository.Read(customerId));
        }
    }
}
