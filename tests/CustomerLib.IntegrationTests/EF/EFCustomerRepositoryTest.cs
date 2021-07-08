using CustomerLib.IntegrationTests.Fixtures;
using CustomerLib.Data.Repositories;
using CustomerLib.Data.EF;
using CustomerLib.Entities;
using Xunit;
using System.Collections.Generic;

namespace CustomerLib.IntegrationTests.EF
{
    public class EFCustomerRepositoryTest
    {
        [Fact]
        public void ShouldBeAbleToCreateEFCustomerRepository()
        {
            var customerRepository = new EFCustomerRepository();
            Assert.NotNull(customerRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var cc = new CustomerRepository();
            cc.DeleteAll(); //method contains refresh ID`s

            var customerRepository = new EFCustomerRepository();
            var fixture = new EFRepositoriesFixture();
            var customer = fixture.CreateMockCustomer();

            var createdCustomer = customerRepository.Read(1);

            fixture.EqualCustomers(customer, createdCustomer);
        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            var cc = new CustomerRepository();
            cc.DeleteAll(); //method contains refresh ID`s

            var customerRepository = new EFCustomerRepository();
            var fixture = new EFRepositoriesFixture();

            var customer = fixture.CreateMockCustomer();

            var createdCustomer = customerRepository.Read(1);
            fixture.EqualCustomers(customer, createdCustomer);
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            var cc = new CustomerRepository();
            cc.DeleteAll(); //method contains refresh ID`s

            var customerRepository = new EFCustomerRepository();
            var fixture = new EFRepositoriesFixture();

            var customer = fixture.CreateMockCustomer();

            var createdCustomer = customerRepository.Read(1);
            fixture.EqualCustomers(customer, createdCustomer);

            var newCustomer = new Customer
            {
                CustomerID = 1,
                FirstName = "Andrew",
                LastName = "Zabrodskiy",
                PhoneNumber = "+38000909",
                Email = "mail@g.com",
                TotalPurchasesAmount = (decimal)9.33,
                Addresses = new List<Address> {
                    new Address
                    {
                    CustomerID = 1,
                    AddressID = 1,
                    Line1 = "CustomerLine1",
                    Line2 = "CustomerLine2",
                    AddressType = "Shipping",
                    City = "Denver",
                    PostalCode = "121212",
                    State = "State",
                    Country = "Canada"
                    }
                },
                Notes = new List<Note>{
                     new Note()
                     {
                         NoteID = 1,
                         CustomerID = 1,
                         Line = "NoteLine1"
                     }
                }
            };
            customerRepository.Update(newCustomer);

            var updatedCustomer = customerRepository.Read(1);
            Assert.NotNull(updatedCustomer);

            fixture.EqualCustomers(newCustomer, updatedCustomer);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var cc = new CustomerRepository();
            cc.DeleteAll(); //method contains refresh ID`s

            var customerRepository = new EFCustomerRepository();
            var fixture = new EFRepositoriesFixture();

            var customer = fixture.CreateMockCustomer();
            Assert.NotNull(customerRepository.Read(1));

            customerRepository.Delete(1);
            Assert.Null(customerRepository.Read(1));

        }

        [Fact]
        public void ShouldBeAbleToReadAllCustomers()
        {
            var cc = new CustomerRepository();
            cc.DeleteAll(); //method contains refresh ID`s
    
            var customerRepository = new EFCustomerRepository();
            var fixture = new EFRepositoriesFixture();

            var customer = fixture.CreateMockCustomer();
            var manualCreatedCustomer = new Customer
            {
                CustomerID = 1,
                FirstName = "Mikhail",
                LastName = "Erevanov",
                PhoneNumber = "+38098978",
                Email = "mungb@ff.com",
                TotalPurchasesAmount = (decimal)23.7,
                Addresses = new List<Address>
                {
                    new Address
                    {
                        CustomerID = 2,
                        Line1 = "Line1, second Address",
                        Line2 = "Line1, second Address",
                        City = "Denver",
                        State = "Ilinois",
                        PostalCode = "123212",
                        Country = "United States",
                        AddressType = "Billing"
                    }
                },
                Notes = new List<Note>
                {
                    new Note
                    {
                        CustomerID = 2,
                        Line = "Some line"
                    }
                }

            };
            customerRepository.Create(manualCreatedCustomer);

            Assert.NotNull(customerRepository.Read(1));
            Assert.NotNull(customerRepository.Read(2));

            List<Customer> readedCustomers = customerRepository.ReadAllCustomers();
            fixture.EqualCustomers(readedCustomers[0], fixture.MockCustomer());
            fixture.EqualCustomers(readedCustomers[1], manualCreatedCustomer);
        }
    }
}
