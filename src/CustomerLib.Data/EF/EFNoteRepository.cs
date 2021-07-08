using CustomerLib.Entities;
using System.Collections.Generic;


namespace CustomerLib.Data.EF
{
    public class EFNoteRepository
    {
        private CustomerDataContext _context;
        public EFNoteRepository()
        {
            _context = new CustomerDataContext();
        }

        public void Create(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        public Note Read(int noteId)
        {
            return _context.Notes.Find(noteId);
        }

        public void Update(Note updatedNote)
        {
            Note note = Read(updatedNote.NoteID);
            note.Line = updatedNote.Line;
            _context.SaveChanges();
        }

        public void Delete(int noteId)
        {
            _context.Notes.Remove(_context.Notes.Find(noteId));
            _context.SaveChanges();
        }

        public List<Note> ReadAllNotes(int customerId)
        {
            List<Note> notes = new List<Note>();
            foreach (Note note in _context.Notes)
            {
                if (note.CustomerID == customerId)
                    notes.Add(note);
            }
            if (notes.Count == 0)
                return null;
            return notes;
        }
    }
}
