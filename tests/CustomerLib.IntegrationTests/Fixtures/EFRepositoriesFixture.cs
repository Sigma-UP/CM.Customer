using System.Collections.Generic;
using CustomerLib.Entities;
using CustomerLib.Data.EF;
using CustomerLib.Data.Repositories;
using Xunit;
using System.Diagnostics.CodeAnalysis;
namespace CustomerLib.IntegrationTests.Fixtures
{
    [ExcludeFromCodeCoverage]
    public class EFRepositoriesFixture
    {
        public Customer CreateMockCustomer()
        {
            var customerRepository = new EFCustomerRepository();
            customerRepository.DeleteAll();
        
            var customer = MockCustomer();
            customerRepository.Create(customer);
        
            return customer;
        }

        public Address CreateMockAddress()
        {
            var addressRepository = new EFAddressRepository();

            var address = MockAddress();
            addressRepository.Create(address);

            return address;
        }

        public Note CreateMockNote()
        {
            var noteRepository = new EFNoteRepository();

            var note = MockNote();
            noteRepository.Create(note);

            return note;
        }

        #region Mock Entities
        public Note MockNote()
        {
            return new Note()
            {
                NoteID = 1,
                Line = "NoteLine1"
            };
        }
        public Address MockAddress()
        {
            return new Address()
            {
                CustomerID = 1,
                Line1 = "CustomerLine1",
                Line2 = "CustomerLine2",
                AddressType = "Shipping",
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
                Notes = new List<Note>() {
                    MockNote()
                    },
                PhoneNumber = "+36098983443",
                Email = "myname@gmail.com",
                TotalPurchasesAmount = (decimal?)1234.3
            };
        }
        #endregion
        #region Compare Entities
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

            Assert.Equal(expectedNote.Line, actualNote.Line);
        }
        #endregion
    }
}
