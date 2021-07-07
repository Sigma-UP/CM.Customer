using CustomerLib.Entities;
using Xunit;
namespace CustomerLib.Test.Entities
{
    public class NoteTest
    {
        private Note _note = new Note ();
        
        [Fact]
        public void LineShouldSaveNullIfStringIsEmpty()
        {
            Assert.Null(_note.Line);
            _note.Line = "";
            Assert.Null(_note.Line);
        }
        [Fact]
        public void LineShouldSaveStringIfItIsNotEmpty()
        {
            Assert.Null(_note.Line);
            _note.Line = "LINE!";
            Assert.Equal("LINE!", _note.Line);
        }
        [Fact]
        public void ShouldSaveCustomerID()
        {
            _note.CustomerID = 1;
            Assert.Equal(1, _note.CustomerID);
        }
        [Fact]
        public void ShouldSaveNoteID()
        {
            _note.NoteID = 1;
            Assert.Equal(1, _note.NoteID);
        }
    }
}
