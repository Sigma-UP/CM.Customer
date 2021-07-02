using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CustomerLib.Repositories;
namespace CustomerLib.Test.Repositories
{
    public class NotesRepositoryTest
    {
        [Fact]
        public void ShouldBeAbleToCreateNotesRepository()
        {
            var notesRepository = new NoteRepository();
            Assert.NotNull(notesRepository);
        }


        [Fact]
        public void ShouldBeAbleToCreateNotes()
        {
            var notesRepository = new NoteRepository();
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
                        "Customer Note First"
                    },
                Phone = "+36098983443",
                Email = "myname@gmail.com",
                TotalPurchasesAmount = (decimal?)1234.3
            });

            var createdNote = "Customer Note Second";
            notesRepository.Create(createdNote, 1);


            var readedNote = notesRepository.Read(1, 2);
            Assert.NotNull(readedNote);
            Assert.Equal(createdNote, readedNote);
        }

        [Fact]
        public void ShouldBeAbleToReadNotes()
        {
            var noteRepository = new NoteRepository();
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
                        "Customer Note First",
                        "Customer Note Second"
                    },
                Phone = "+36098983443",
                Email = "myname@gmail.com",
                TotalPurchasesAmount = (decimal?)1234.3
            });

            var readedNote1 = noteRepository.Read(1, 1);
            var readedNote2 = noteRepository.Read(1, 2);
            
            Assert.NotNull(readedNote1);
            Assert.NotNull(readedNote2);
            Assert.Equal("Customer Note First", readedNote1);
            Assert.Equal("Customer Note Second", readedNote2);
        }

        [Fact]
        public void ShouldBeAbleToUpdateNotes()
        {
            var noteRepository = new NoteRepository();
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
                        "Customer Note First",
                        "Customer Note Second"
                    },
                Phone = "+36098983443",
                Email = "myname@gmail.com",
                TotalPurchasesAmount = (decimal?)1234.3
            });

            Assert.Equal("Customer Note First", noteRepository.Read(1, 1));
            
            var note = "Updated Customer Note First";
            noteRepository.Update(note, 1, 2);
            var updatedNote = noteRepository.Read(1, 2);
            Assert.Equal(note, updatedNote);
        }

        [Fact]
        public void ShouldBeAbleToDeleteNote()
        {
            int noteId = 1, customerId = 1;
            var noteRepository = new NoteRepository();
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
                        "Customer Note First",
                        "Customer Note Second"
                    },
                Phone = "+36098983443",
                Email = "myname@gmail.com",
                TotalPurchasesAmount = (decimal?)1234.3
            });


            noteRepository.Delete(customerId, noteId);
            Assert.Null(noteRepository.Read(customerId, noteId));
            Assert.NotNull(noteRepository.Read(customerId, noteId+1));
        }

        [Fact]
        public void ShouldBeAbleToReadAllNotes()
        {
            var noteRepository = new NoteRepository();
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
                        "Customer Note First",
                        "Customer Note Second"
                    },
                Phone = "+36098983443",
                Email = "myname@gmail.com",
                TotalPurchasesAmount = (decimal?)1234.3
            });

            List<string> readedNotes = noteRepository.ReadAllNotes(1);

            Assert.Equal("Customer Note First", readedNotes[0]);
            Assert.Equal("Customer Note Second", readedNotes[1]);
        }
    }
}
