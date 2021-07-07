using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using CustomerLib.Entities;
using System;

namespace CustomerLib.Data.Repositories
{
    [ExcludeFromCodeCoverage]
    public class NoteRepository : BaseRepository
    {
        public void Create(Note note)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "INSERT " +
                    "INTO [dbo].[Notes] " +
                    "( CustomerID, Line ) " +
                    "VALUES " +
                    "( @CustomerID, @Line )", 
                    connection);
                var noteCustomerIDParam = new SqlParameter("@CustomerID", System.Data.SqlDbType.Int)
                {
                    Value = note.CustomerID
                };

                var noteNoteParam = new SqlParameter("@Line", System.Data.SqlDbType.VarChar, 500)
                {
                    Value = note.Line
                };

                command.Parameters.Add(noteCustomerIDParam);
                command.Parameters.Add(noteNoteParam);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Note note)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "UPDATE [dbo].[Notes] " +
                    "SET " +
                    "[dbo].[Notes].[Line] = @Line " +
                    "WHERE " +
                    "[dbo].[Notes].[NoteID] = @NoteID AND " +
                    "[dbo].[Notes].[CustomerID] = @CustomerID", 
                    connection);
                var noteLineParam = new SqlParameter("@Line", System.Data.SqlDbType.VarChar, 500)
                {
                    Value = note.Line
                };
                var noteCustomerIDParam = new SqlParameter("@CustomerID", System.Data.SqlDbType.Int)
                {
                    Value = note.CustomerID
                };
                var noteNoteIDParam = new SqlParameter("@NoteID", System.Data.SqlDbType.Int)
                {
                    Value = note.NoteID
                };

                command.Parameters.Add(noteLineParam);
                command.Parameters.Add(noteCustomerIDParam);
                command.Parameters.Add(noteNoteIDParam);
                
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int customerId, int noteId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "DELETE " +
                    "FROM [dbo].[Notes] " +
                    "WHERE " +
                    "[dbo].[Notes].[CustomerID] = @CustomerID AND " +
                    "[dbo].[Notes].[NoteID] = @NoteID", 
                    connection);

                var noteCustomerIDParam = new SqlParameter("@CustomerID", System.Data.SqlDbType.Int)
                {
                    Value = customerId
                };
                var noteNoteIDParam = new SqlParameter("@NoteID", System.Data.SqlDbType.Int)
                {
                    Value = noteId
                };

                command.Parameters.Add(noteCustomerIDParam);
                command.Parameters.Add(noteNoteIDParam);


                command.ExecuteNonQuery();
            }
        }

        public Note Read(int customerId, int noteId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT * " +
                    "FROM [dbo].[Notes] " +
                    "WHERE " +
                    "[dbo].[Notes].[CustomerID] = @CustomerID AND " +
                    "[dbo].[Notes].[NoteID] = @NoteID", 
                    connection);

                var noteCustomerIDParam = new SqlParameter("@CustomerID", System.Data.SqlDbType.Int)
                {
                    Value = customerId
                };
                var noteNoteIDParam = new SqlParameter("@NoteID", System.Data.SqlDbType.Int)
                {
                    Value = noteId
                };

                command.Parameters.Add(noteCustomerIDParam);
                command.Parameters.Add(noteNoteIDParam);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return new Note
                        {
                            CustomerID = Convert.ToInt32(reader["CustomerID"]),
                            NoteID = Convert.ToInt32(reader["NoteID"]),
                            Line = reader["Line"]?.ToString() 
                        };
                }

                command.ExecuteNonQuery();
            }

            return null;
        }
        
        public List<Note> ReadAllNotes(int customerId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT [dbo].[Notes].[CustomerID], " +
                    "[dbo].[Notes].[NoteID], " +
                    "[dbo].[Notes].[Line] " +
                    "FROM [dbo].[Notes] " +
                    "WHERE " +
                    "[dbo].[Notes].[CustomerID] = @CustomerID", 
                    connection);

                var notesCustomerIDParam = new SqlParameter("@CustomerID", System.Data.SqlDbType.Int)
                {
                    Value = customerId
                };

                command.Parameters.Add(notesCustomerIDParam);

                List<Note> readedNotes = new List<Note>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        readedNotes.Add(new Note{
                            CustomerID = Convert.ToInt32(reader["CustomerID"]),
                            NoteID = Convert.ToInt32(reader["NoteID"]),
                            Line = reader["Line"]?.ToString()
                        });
                    }
                }

                command.ExecuteNonQuery();
                return readedNotes;
            }
        }

        public void DeleteAll(int customerId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "DELETE " +
                    "FROM [dbo].[Notes] " +
                    "WHERE " +
                    "[dbo].[Notes].[Customer] = @CustomerID;" +
                    "DBCC CHECKIDENT (Notes, RESEED, 0);", 
                    connection);
                var noteCustomerIDParam = new SqlParameter("@CustomerID", System.Data.SqlDbType.Int)
                {
                    Value = customerId
                };

                command.Parameters.Add(noteCustomerIDParam);
                command.ExecuteNonQuery();
            }
        }
    }
}
