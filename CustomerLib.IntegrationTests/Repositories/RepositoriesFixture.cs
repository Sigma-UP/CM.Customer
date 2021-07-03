using System;
using System.Collections.Generic;
using CustomerLib.Repositories;
using Xunit;

namespace CustomerLib.IntegrationTests.Repositories
{
    public class RepositoriesFixture
    {
        public Customer CreateMockCustomer()
        {
            var customerRepository = new CustomerRepository();
            customerRepository.DeleteAll();

            var customer = MockCustomer();
            customerRepository.Create(customer);

            return customer;
        }

        public Address CreateMockAddress()
        {
            var addressRepository = new AddressRepository();

            var address = MockAddress();
            addressRepository.Create(address, 1);

            return address;
        }

        #region Mock Repos
        public Address MockAddress()
        {
            return new Address()
            {
                Line1 = "CustomerLine1",
                Line2 = "CustomerLine2",
                AddressType = Address.EAddressType.Shipping,
                City = "Denver",
                PostalCode = "121212",
                State = "State",
                Country = "Canada"
            };
        }
        public Customer MockCustomer()
        {
            return new Customer()
            {
                FirstName = "Alex",
                LastName = "Xlea",
                Addresses = new List<Address>() {
                    MockAddress()
                    },
                Notes = new List<string>() {
                        "Customer Note"
                    },
                Phone = "+36098983443",
                Email = "myname@gmail.com",
                TotalPurchasesAmount = (decimal?)1234.3
            };
        }
        #endregion
        #region Compare Repos
        public void EqualAddresses(Address address, Address readedAddress)
        {
            Assert.NotNull(readedAddress);

            Assert.Equal(address.Line1, readedAddress.Line1);
            Assert.Equal(address.Line2, readedAddress.Line2);
            Assert.Equal(address.AddressType, readedAddress.AddressType);
            Assert.Equal(address.City, readedAddress.City);
            Assert.Equal(address.PostalCode, readedAddress.PostalCode);

            Assert.Equal(address.State, readedAddress.State);
            Assert.Equal(address.Country, readedAddress.Country);
        }
        public void EqualCustomers(Customer customer, Customer readedCustomer)
        {
            Assert.NotNull(readedCustomer);

            Assert.Equal(customer.FirstName, readedCustomer.FirstName);
            Assert.Equal(customer.LastName, readedCustomer.LastName);
            Assert.Equal(customer.Phone, readedCustomer.Phone);
            Assert.Equal(customer.Email, readedCustomer.Email);
            Assert.Equal(customer.TotalPurchasesAmount, readedCustomer.TotalPurchasesAmount);

            Assert.Equal(customer.Addresses[0].AddressType, readedCustomer.Addresses[0].AddressType);
            Assert.Equal(customer.Addresses[0].City, readedCustomer.Addresses[0].City);
            Assert.Equal(customer.Addresses[0].PostalCode, readedCustomer.Addresses[0].PostalCode);

            Assert.Equal(customer.Notes[0], readedCustomer.Notes[0]);
        }
        #endregion
    }
}
