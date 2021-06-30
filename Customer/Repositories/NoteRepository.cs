using System.Collections.Generic;
using System.Data.SqlClient;
namespace CustomerLib.Repositories
{
    public class NoteRepository
    {
        public void Create(string note, int customerIdx)
        {
            using (var connection = new SqlConnection("Server=ALFA;Database=CustomerLib_Bezslyozniy;Trusted_Connection=True;"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Notes] (CustomerID, Note)" +
                    "VALUES(@CustomerID, @Note)", connection);
                var noteCustomerIDParam = new SqlParameter("CustomerID", System.Data.SqlDbType.Int)
                {
                    Value = customerIdx
                };

                var noteNoteParam = new SqlParameter("@Note", System.Data.SqlDbType.VarChar, 500)
                {
                    Value = note
                };

                command.Parameters.Add(noteCustomerIDParam);
                command.Parameters.Add(noteNoteParam);

                command.ExecuteNonQuery();
            }
        }

        public void Update(string note, int customerIdx, int noteIdx)
        {

            using (var connection = new SqlConnection("Server=ALFA;Database=CustomerLib_Bezslyozniy;Trusted_Connection=True;"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("UPDATE [dbo].[Notes] SET Note = @Note", connection);
                var noteNoteParam = new SqlParameter("Note", System.Data.SqlDbType.VarChar, 500)
                {
                    Value = note
                };

                command.Parameters.Add(noteNoteParam);
                
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int customerId, int noteId)
        {
            using (var connection = new SqlConnection("Server=ALFA;Database=CustomerLib_Bezslyozniy;Trusted_Connection=True;"))
            {
                connection.Open();

                var command = new SqlCommand("DELETE FROM [Notes] WHERE CustomerID = @CustomerID AND NoteID = @NoteID", connection);

                var noteCustomerIDParam = new SqlParameter("CustomerID", System.Data.SqlDbType.Int)
                {
                    Value = customerId
                };
                var noteNoteIDParam = new SqlParameter("NoteID", System.Data.SqlDbType.Int)
                {
                    Value = noteId
                };

                command.Parameters.Add(noteCustomerIDParam);
                command.Parameters.Add(noteNoteIDParam);


                command.ExecuteNonQuery();
            }
        }

        public string Read(int customerId, int noteId)
        {
            using (var connection = new SqlConnection("Server=ALFA;Database=CustomerLib_Bezslyozniy;Trusted_Connection=True;"))
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM [Notes] WHERE CustomerID = @customerId AND NoteID = @NoteID", connection);

                var noteCustomerIDParam = new SqlParameter("CustomerID", System.Data.SqlDbType.Int)
                {
                    Value = customerId
                };
                var noteNoteIDParam = new SqlParameter("NoteID", System.Data.SqlDbType.Int)
                {
                    Value = noteId
                };

                command.Parameters.Add(noteCustomerIDParam);
                command.Parameters.Add(noteNoteIDParam);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return reader["Note"]?.ToString();
                }

                command.ExecuteNonQuery();
            }

            return null;
        }
        
        public static List<string> ReadAllNotes(int customerId)
        {
            using (var connection = new SqlConnection("Server=ALFA;Database=CustomerLib_Bezslyozniy;Trusted_Connection=True;"))
            {
                connection.Open();

                var command = new SqlCommand("SELECT Note FROM [Notes] WHERE CustomerID = @CustomerID", connection);

                var notesCustomerIDParam = new SqlParameter("CustomerID", System.Data.SqlDbType.Int)
                {
                    Value = customerId
                };

                command.Parameters.Add(notesCustomerIDParam);

                List<string> readedNotes = new List<string>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        readedNotes.Add(reader["Note"]?.ToString());
                    }
                }

                command.ExecuteNonQuery();
                return readedNotes;
            }
        }

        public void DeleteAll()
        {
            using (var connection = new SqlConnection("Server=ALFA;Database=CustomerLib_Bezslyozniy;Trusted_Connection=True;"))
            {
                connection.Open();

                var command = new SqlCommand("DELETE FROM [Addresses]", connection);

                command.ExecuteNonQuery();
            }
        }


    }
}
