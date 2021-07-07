using System.Collections.Generic;
using CustomerLib.Entities;
using CustomerLib.Data.Repositories;
using Xunit;
using System.Diagnostics.CodeAnalysis;
namespace CustomerLib.IntegrationTests.Fixtures
{
    [ExcludeFromCodeCoverage]
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
            addressRepository.Create(address);

            return address;
        }

        #region Mock Repos
        public Customer MockCustomer() => new Customer()
        {
            CustomerID = 1,
            FirstName = "Alex",
            LastName = "Xlea",
            Addresses = new List<Address>() {
                MockAddress()
                },
            Notes = new List<Note>() {
                MockNote()
                },
            PhoneNumber = "+36098983443",
            Email = "myname@gmail.com",
            TotalPurchasesAmount = (decimal?)1234.3
        };
        public Address MockAddress() => new Address()
        {
            CustomerID = 1,
            AddressID = 1,
            Line1 = "CustomerLine1",
            Line2 = "CustomerLine2",
            AddressType = Address.EAddressType.Shipping,
            City = "Denver",
            PostalCode = "121212",
            State = "State",
            Country = "Canada"
        };
        public Note MockNote() => new Note()
        {
            CustomerID = 1,
            NoteID = 1,
            Line = "Mocked Note"
        };
        #endregion
        #region Compare Repos
        public void EqualCustomers(Customer expectedCustomer, Customer actualCustomer)
        {
            Assert.NotNull(actualCustomer);

            Assert.Equal(expectedCustomer.FirstName, actualCustomer.FirstName);
            Assert.Equal(expectedCustomer.LastName, actualCustomer.LastName);
            Assert.Equal(expectedCustomer.PhoneNumber, actualCustomer.PhoneNumber);
            Assert.Equal(expectedCustomer.Email, actualCustomer.Email);
            Assert.Equal(expectedCustomer.TotalPurchasesAmount, actualCustomer.TotalPurchasesAmount);

            for (int i = 0; i < expectedCustomer.Addresses.Count; i++)
                EqualAddresses(expectedCustomer.Addresses[i], actualCustomer.Addresses[i]);

            for (int i = 0; i < expectedCustomer.Notes.Count; i++)
                EqualNotes(expectedCustomer.Notes[i], actualCustomer.Notes[i]);
        }
        public void EqualAddresses(Address expectedAddress, Address actualAddress)
        {
            Assert.NotNull(actualAddress);

            Assert.Equal(expectedAddress.Line1, actualAddress.Line1);
            Assert.Equal(expectedAddress.Line2, actualAddress.Line2);
            Assert.Equal(expectedAddress.AddressType, actualAddress.AddressType);
            Assert.Equal(expectedAddress.City, actualAddress.City);
            Assert.Equal(expectedAddress.PostalCode, actualAddress.PostalCode);

            Assert.Equal(expectedAddress.State, actualAddress.State);
            Assert.Equal(expectedAddress.Country, actualAddress.Country);
        }
        public void EqualNotes(Note expectedNote, Note actualNote)
        {
            Assert.NotNull(actualNote);

            Assert.Equal(expectedNote.NoteID, actualNote.NoteID);
            Assert.Equal(expectedNote.CustomerID, actualNote.CustomerID);
            Assert.Equal(expectedNote.Line, actualNote.Line);
        }
        #endregion
    }
}