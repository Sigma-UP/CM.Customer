using System.Collections.Generic;
using Xunit;
using CustomerLib.Data.Repositories;
namespace CustomerLib.IntegrationTests.Repositories
{
    public class NotesRepositoryTest
    {
        [Fact]
        public void ShouldBeAbleToCreateNotesRepository()
        {
            var noteRepository = new NoteRepository();
            Assert.NotNull(noteRepository);
        }


        [Fact]
        public void ShouldBeAbleToCreateNotes()
        {
            var noteRepository = new NoteRepository();
            var fixture = new RepositoriesFixture();
            var customer = fixture.CreateMockCustomer();

            var readedNote = noteRepository.Read(1, 1);

            Assert.NotNull(readedNote);
            Assert.Equal(customer.Notes[0], readedNote);
        }

        [Fact]
        public void ShouldBeAbleToReadNotes()
        {
            var noteRepository = new NoteRepository();
            var fixture = new RepositoriesFixture();
            var customer = fixture.CreateMockCustomer();
            noteRepository.Create("Customer Note Second", 1);

            var readedNote1 = noteRepository.Read(1, 1);
            var readedNote2 = noteRepository.Read(1, 2);
            
            Assert.NotNull(readedNote1);
            Assert.NotNull(readedNote2);
            Assert.Equal(customer.Notes[0], readedNote1);
            Assert.Equal("Customer Note Second", readedNote2);
        }

        [Fact]
        public void ShouldBeAbleToUpdateNotes()
        {
            var noteRepository = new NoteRepository();
            var fixture = new RepositoriesFixture();
            var customer = fixture.CreateMockCustomer();

            Assert.Equal(customer.Notes[0], noteRepository.Read(1, 1));
            
            var note = "Updated Customer Note First";
            noteRepository.Update(note, 1, 1);
            var updatedNote = noteRepository.Read(1, 1);
            Assert.Equal(note, updatedNote);
        }

        [Fact]
        public void ShouldBeAbleToDeleteNote()
        {
            var noteRepository = new NoteRepository();
            var fixture = new RepositoriesFixture();
            var customer = fixture.CreateMockCustomer();

            
            noteRepository.Delete(1, 1);
            Assert.Null(noteRepository.Read(1, 1));
        }

        [Fact]
        public void ShouldBeAbleToReadAllNotes()
        {
            var noteRepository = new NoteRepository();
            var fixture = new RepositoriesFixture();
            var customer = fixture.CreateMockCustomer();

            List<string> readedNotes = noteRepository.ReadAllNotes(1);

            Assert.Equal(customer.Notes[0], readedNotes[0]);
        }
    }
}
