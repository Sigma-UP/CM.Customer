using System.Collections.Generic;
using Xunit;
using CustomerLib.Data.Repositories;
using CustomerLib.Entities;
using CustomerLib.IntegrationTests.Fixtures;

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

            fixture.EqualNotes(customer.Notes[0], readedNote);
        }

        [Fact]
        public void ShouldBeAbleToReadNotes()
        {
            var noteRepository = new NoteRepository();
            var fixture = new RepositoriesFixture();
            var customer = fixture.CreateMockCustomer();
            var newNote = new Note
            {
                CustomerID = 1,
                NoteID = 2,
                Line = "Customer Note Second",
            };
            noteRepository.Create(newNote);

            var readedNote1 = noteRepository.Read(1, 1);
            var readedNote2 = noteRepository.Read(1, 2);
            
            Assert.NotNull(readedNote1);
            Assert.NotNull(readedNote2);

            fixture.EqualNotes(customer.Notes[0], readedNote1);
            fixture.EqualNotes(newNote, readedNote2);
        }

        [Fact]
        public void ShouldBeAbleToUpdateNotes()
        {
            var noteRepository = new NoteRepository();
            var fixture = new RepositoriesFixture();
            var customer = fixture.CreateMockCustomer();

            fixture.EqualNotes(customer.Notes[0], noteRepository.Read(1, 1));
            
            var updatedNote = new Note
            {
                CustomerID = 1,
                NoteID = 1,
                Line = "Updated Customer Note First",
            };
            noteRepository.Update(updatedNote);
            var readedNote = noteRepository.Read(1, 1);
            fixture.EqualNotes(updatedNote, readedNote);
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
            List<Note> readedNotes = noteRepository.ReadAllNotes(1);
            
            fixture.EqualNotes(customer.Notes[0], readedNotes[0]);
        }
    }
}
