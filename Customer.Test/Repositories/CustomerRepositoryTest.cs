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
            var customerRepository = new CustomerRepository();
            customerRepository.DeleteAll();
            customerRepository.Create(new Customer()
            {
                FirstName = "Alex",
                LastName = "Xlea",
                Addresses = new List<Address>() {
                        new Address(){
                        Line1 = "CustomerLine1",
                        Line2 = "CustomerLine2",
                        AddressType = Address.EAddressType.Shipping,
                        City = "Denver",
                        PostalCode = "121212",
                        State = "State",
                        Country = "Canada" }
                    },
                Notes = new List<string>() {
                        "Customer Note"
                    },
                Phone = "+36098983443",
                Email = "myname@gmail.com",
                TotalPurchasesAmount = (decimal?)1234.3
            });

            var createdCustomer = customerRepository.Read(1);
            Assert.NotNull(createdCustomer);

            Assert.Equal("Alex", createdCustomer.FirstName);
            Assert.Equal("Xlea", createdCustomer.LastName);

            Assert.Equal(Address.EAddressType.Shipping, createdCustomer.Addresses[0].AddressType);
            Assert.Equal("Denver", createdCustomer.Addresses[0].City);
            Assert.Equal("121212", createdCustomer.Addresses[0].PostalCode);

            Assert.Equal("Customer Note", createdCustomer.Notes[0]);

        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            var customerRepository = new CustomerRepository();
            customerRepository.DeleteAll();

            customerRepository.Create(new Customer()
            {
                FirstName = "Alex",
                LastName = "Xlea",
                Addresses = new List<Address>() {
                        new Address(){
                        Line1 = "CustomerLine1",
                        Line2 = "CustomerLine2",
                        AddressType = Address.EAddressType.Shipping,
                        City = "Denver",
                        PostalCode = "121212",
                        State = "State",
                        Country = "Canada" }
                    },
                Notes = new List<string>() {
                        "Customer Note"
                    },
                Phone = "+36098983443",
                Email = "myname@gmail.com",
                TotalPurchasesAmount = (decimal?)1234.3
            });

            var readedCustomer = customerRepository.Read(1);

            Assert.NotNull(readedCustomer);

            Assert.Equal("Alex", readedCustomer.FirstName);
            Assert.Equal("Xlea", readedCustomer.LastName);

            Assert.Equal(Address.EAddressType.Shipping, readedCustomer.Addresses[0].AddressType);
            Assert.Equal("Denver", readedCustomer.Addresses[0].City);
            Assert.Equal("121212", readedCustomer.Addresses[0].PostalCode);

            Assert.Equal("Customer Note", readedCustomer.Notes[0]);

        }

        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            var customerRepository = new CustomerRepository();
            customerRepository.DeleteAll();

            var customer = new Customer()
            {
                FirstName = "Alex",
                LastName = "Xlea",
                Addresses = new List<Address>() {
                        new Address(){
                        Line1 = "CustomerLine1",
                        Line2 = "CustomerLine2",
                        AddressType = Address.EAddressType.Shipping,
                        City = "Denver",
                        PostalCode = "121212",
                        State = "State",
                        Country = "Canada" }
                    },
                Notes = new List<string>() {
                        "Customer Note"
                    },
                Phone = "+36098983443",
                Email = "myname@gmail.com",
                TotalPurchasesAmount = (decimal?)1234.3
            };
            customerRepository.Create(customer);
            customer.FirstName = "Mikhail";
            customerRepository.Update(customer, 1);

            var updatedCustomer = customerRepository.Read(1);
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
            customerRepository.DeleteAll();
            customerRepository.Create(new Customer()
            {
                FirstName = "Alex",
                LastName = "Xlea",
                Addresses = new List<Address>() {
                        new Address(){
                        Line1 = "CustomerLine1",
                        Line2 = "CustomerLine2",
                        AddressType = Address.EAddressType.Shipping,
                        City = "Denver",
                        PostalCode = "121212",
                        State = "State",
                        Country = "Canada" }
                    },
                Notes = new List<string>() {
                        "Customer Note"
                    },
                Phone = "+36098983443",
                Email = "myname@gmail.com",
                TotalPurchasesAmount = (decimal?)1234.3
            });
            customerRepository.Delete(customerId);
            Assert.Null(customerRepository.Read(customerId));

        }
    }
}
