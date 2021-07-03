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
            var fixture = new CustomerRepositoryFixture();
            var customer = fixture.CreateMockCustomer();

            var createdCustomer = customerRepository.Read(1);
            fixture.Equal(customer, createdCustomer);
        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            var customerRepository = new CustomerRepository();
            var fixture = new CustomerRepositoryFixture();
            var customer = fixture.CreateMockCustomer();
            var readedCustomer = customerRepository.Read(1);
            fixture.Equal(customer, readedCustomer);
        }

        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            var customerRepository = new CustomerRepository();
            var fixture = new CustomerRepositoryFixture();
            var customer = fixture.CreateMockCustomer();

            customer.FirstName = "Mikhail";
            customerRepository.Update(customer, 1);
            
            var readedCustomer = customerRepository.Read(1);
            fixture.Equal(customer, readedCustomer);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var customerRepository = new CustomerRepository();
            var fixture = new CustomerRepositoryFixture();
            var customer = fixture.CreateMockCustomer();

            Assert.NotNull(customerRepository.Read(1));

            customerRepository.Delete(1);

            Assert.Null(customerRepository.Read(1));
        }
    }
    public class CustomerRepositoryFixture
    {
        public Customer CreateMockCustomer()
        {
            var customerRepository = new CustomerRepository();
            customerRepository.DeleteAll();

            var customer = MockCustomer();
            customerRepository.Create(customer);

            return customer;
        }

        public Customer MockCustomer()
        {
            return new Customer()
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
        }

        public void Equal(Customer customer, Customer readedCustomer)
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
    }
}
