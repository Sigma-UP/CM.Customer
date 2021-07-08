using CustomerLib.IntegrationTests.Fixtures;
using CustomerLib.Data.Repositories;
using CustomerLib.Data.EF;
using CustomerLib.Entities;
using Xunit;

namespace CustomerLib.IntegrationTests.EF
{
    public class EFNoteRepositoryTest
    {
        [Fact]
        public void ShouldBeAbleToCreateEFNoteRepository()
        {
            var noteRepository = new EFNoteRepository();
            Assert.NotNull(noteRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateNote()
        {
            var cc = new CustomerRepository();
            cc.DeleteAll(); //method contains refresh ID`s

            var noteRepository = new EFNoteRepository();
            var customerRepository = new EFCustomerRepository();
            var fixture = new EFRepositoriesFixture();
            var customer = fixture.CreateMockCustomer();

            noteRepository.Create(new Note{
                CustomerID = 1,
                Line = "Customer Line"
                }
            );

            var createdNote = noteRepository.Read(1);

            fixture.EqualNotes(customer.Notes[0], createdNote);
        }

        [Fact]
        public void ShouldBeAbleToReadNote()
        {
            var cc = new CustomerRepository();
            cc.DeleteAll(); //method contains refresh ID`s

            var noteRepository = new EFNoteRepository();
            var fixture = new EFRepositoriesFixture();

            var customer = fixture.CreateMockCustomer();

            var createdNote = noteRepository.Read(1);
            fixture.EqualNotes(customer.Notes[0], createdNote);
        }

        [Fact]
        public void ShouldBeAbleToUpdateNote()
        {
            var cc = new CustomerRepository();
            cc.DeleteAll(); //method contains refresh ID`s

            var noteRepository = new EFNoteRepository();
            var fixture = new EFRepositoriesFixture();

            var customer = fixture.CreateMockCustomer();

            var createdNote = noteRepository.Read(1);
            fixture.EqualNotes(customer.Notes[0], createdNote);

            var newNote = new Note
            {
                CustomerID = 1,
                NoteID = 1,
                Line = "Updated Line"
            };
            noteRepository.Update(newNote);

            var updatedNote = noteRepository.Read(1);
            Assert.NotNull(updatedNote);

            fixture.EqualNotes(newNote, updatedNote);
        }

        [Fact]
        public void ShouldBeAbleToDeleteAddress()
        {
            var cc = new CustomerRepository();
            cc.DeleteAll(); //method contains refresh ID`s

            var noteRepository = new EFNoteRepository();
            var fixture = new EFRepositoriesFixture();

            var customer = fixture.CreateMockCustomer();
            Assert.NotNull(noteRepository.Read(1));

            noteRepository.Delete(1);
            Assert.Null(noteRepository.Read(1));
        }

        [Fact]
        public void ShouldBeAbleToReadAllAddresses()
        {
            var cc = new CustomerRepository();
            cc.DeleteAll(); //method contains refresh ID`s

            var noteRepository = new EFNoteRepository();
            var fixture = new EFRepositoriesFixture();

            var customer = fixture.CreateMockCustomer();
            var manualCreatedNote = new Note
            {
                NoteID = 2,
                CustomerID = 1,
                Line = "Line, second Note"
            };

            var readedNote = noteRepository.Read(1);
            noteRepository.Create(manualCreatedNote);

            Assert.NotNull(noteRepository.Read(1));
            Assert.NotNull(noteRepository.Read(2));

            customer.Notes = noteRepository.ReadAllNotes(1);
            fixture.EqualNotes(customer.Notes[0], readedNote);
            fixture.EqualNotes(customer.Notes[1], manualCreatedNote);
        }
    }
}
