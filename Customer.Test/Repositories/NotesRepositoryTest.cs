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

            var note = "NOTE";
            notesRepository.Create(note, 2);

            var createdNote = notesRepository.Read(2, 2);
            Assert.NotNull(createdNote);

            Assert.Equal("NOTE", createdNote);
        }

        [Fact]
        public void ShouldBeAbleToReadNotes()
        {
            var noteRepository = new NoteRepository();

            var readedNote = noteRepository.Read(1, 3);
            Assert.NotNull(readedNote);

            Assert.Equal("NOTE", readedNote);
        }

        [Fact]
        public void ShouldBeAbleToUpdateNotes()
        {
            var noteRepository = new NoteRepository();
            Assert.Equal("NOTE", noteRepository.Read(1, 3));
            
            var note = "UPDATED NOTE";
            noteRepository.Update(note, 1, 3);

            Assert.Equal("UPDATED NOTE", noteRepository.Read(1, 3));
        }

        [Fact]
        public void ShouldBeAbleToDeleteNote()
        {
            var noteRepository = new NoteRepository();
            int noteId = 1, customerId = 1;

            noteRepository.Delete(customerId, noteId);
            Assert.Null(noteRepository.Read(customerId, noteId));
        }

        [Fact]
        public void ShouldBeAbleToReadAllNotes()
        {
            List<string> readedNotes = NoteRepository.ReadAllNotes(1);

            Assert.Equal("NOTE", readedNotes[0]);
            Assert.Equal("a", readedNotes[25]);
        }
    }
}
