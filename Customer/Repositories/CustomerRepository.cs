using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace CustomerLib.Repositories
{
    public class CustomerRepository
    {
        public static int GetCustomerIndex(Customer customer)
        {
            using (var connection = new SqlConnection(
                "Server=ALFA;" +
                "Database=CustomerLib_Bezslyozniy;" +
                "Trusted_Connection=True;"))
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT * " +
                    "FROM [dbo].[Customers] " +
                    "WHERE " +
                    "[dbo].[Customers].[PhoneNumber] = @PhoneNumber", 
                    connection);

                var customerPhoneParam = new SqlParameter("@PhoneNumber", System.Data.SqlDbType.VarChar, 15)
                {
                    Value = customer.Phone
                };

                command.Parameters.Add(customerPhoneParam);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return Convert.ToInt32(reader["CustomerID"]);
                }

                command.ExecuteNonQuery();

                return -1;
            }
        }

        public void Create(Customer customer)
        {
            using (var connection = new SqlConnection(
                "Server=ALFA;" +
                "Database=CustomerLib_Bezslyozniy;" +
                "Trusted_Connection=True;"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "INSERT INTO [dbo].[Customers] " +
                    "( FirstName, LastName, PhoneNumber, Email, TotalPurchasesAmount ) " +
                    "VALUES " +
                    "( @FirstName, @LastName, @PhoneNumber, @Email, @TotalPurchasesAmount );", 
                    connection);

                var customerFirstNameParam = new SqlParameter("@FirstName", System.Data.SqlDbType.VarChar, 50)
                {
                    Value = customer.FirstName
                };

                var customerLastNameParam = new SqlParameter("@LastName", System.Data.SqlDbType.VarChar, 50)
                {
                    Value = customer.LastName
                };

                var customerPhoneParam = new SqlParameter("@PhoneNumber", System.Data.SqlDbType.VarChar, 15)
                {
                    Value = customer.Phone
                };

                var customerEmailParam = new SqlParameter("@Email", System.Data.SqlDbType.VarChar, 320)
                {
                    Value = customer.Email
                };

                var customerTotalPurchasesAmountParam = new SqlParameter("@TotalPurchasesAmount", System.Data.SqlDbType.Money)
                {
                    Value = customer.TotalPurchasesAmount
                };

                command.Parameters.Add(customerFirstNameParam);
                command.Parameters.Add(customerLastNameParam);
                command.Parameters.Add(customerPhoneParam);
                command.Parameters.Add(customerEmailParam);
                command.Parameters.Add(customerTotalPurchasesAmountParam);

                command.ExecuteNonQuery();

                int customerIndex = GetCustomerIndex(customer);
                AddressRepository addressRepository = new AddressRepository();
                NoteRepository noteRepository = new NoteRepository();

                foreach (Address address in customer.Addresses)
                    addressRepository.Create(address, customerIndex);
                foreach (string note in customer.Notes)
                    noteRepository.Create(note, customerIndex);

            }
        }

        public Customer Read(int customerID)
        {
            using (var connection = new SqlConnection(
                "Server=ALFA;" +
                "Database=CustomerLib_Bezslyozniy;" +
                "Trusted_Connection=True;"))
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT * " +
                    "FROM [dbo].[Customers] " +
                    "WHERE " +
                    "[dbo].[Customers].[CustomerID] = @CustomerId", 
                    connection);

                var customerCustomerIDParam = new SqlParameter("@CustomerID", System.Data.SqlDbType.Int)
                {
                    Value = customerID
                };

                command.Parameters.Add(customerCustomerIDParam);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Customer()
                        {
                            FirstName = reader["FirstName"]?.ToString(),
                            LastName = reader["LastName"]?.ToString(),
                            Phone = reader["PhoneNumber"].ToString(),
                            Email = reader["Email"]?.ToString(),
                            TotalPurchasesAmount = Convert.ToDecimal(reader["TotalPurchasesAmount"]),
                            Addresses = new AddressRepository().ReadAllAddresses(customerID),
                            Notes = new NoteRepository().ReadAllNotes(customerID)
                        };
                    }
                }

                command.ExecuteNonQuery();
            }

            return null;
        }

        public void Update(Customer customer, int customerIdx)
        {
            using (var connection = new SqlConnection(
                "Server=ALFA;" +
                "Database=CustomerLib_Bezslyozniy;" +
                "Trusted_Connection=True;"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "UPDATE [dbo].[Customers] " +
                    "SET" +
                    "[dbo].[Customers].[FirstName] = @FirstName," +
                    "[dbo].[Customers].[LastName] = @LastName," +
                    "[dbo].[Customers].[PhoneNumber] = @PhoneNumber," +
                    "[dbo].[Customers].[Email] = @Email, " +
                    "[dbo].[Customers].[TotalPurchasesAmount] = @TotalPurchasesAmount " +
                    "WHERE " +
                    "[dbo].[Customers].[CustomerID] = @CustomerID; ", 
                    connection);
                var customerFirstNameParam = new SqlParameter("@FirstName", System.Data.SqlDbType.VarChar, 50)
                {
                    Value = customer.FirstName
                };

                var customerLastNameParam = new SqlParameter("@LastName", System.Data.SqlDbType.VarChar, 50)
                {
                    Value = customer.LastName
                };

                var customerPhoneNumberParam = new SqlParameter("@PhoneNumber", System.Data.SqlDbType.VarChar, 15)
                {
                    Value = customer.Phone
                };

                var customerEmailParam = new SqlParameter("@Email", System.Data.SqlDbType.VarChar, 320)
                {
                    Value = customer.Email
                };

                var customerTotalPurchasesAmountParam = new SqlParameter("@TotalPurchasesAmount", System.Data.SqlDbType.Money)
                {
                    Value = customer.TotalPurchasesAmount
                };

                var customerCustomerIDParam = new SqlParameter("@CustomerID", System.Data.SqlDbType.Int)
                {
                    Value = customerIdx
                };

                command.Parameters.Add(customerFirstNameParam);
                command.Parameters.Add(customerLastNameParam);
                command.Parameters.Add(customerPhoneNumberParam);
                command.Parameters.Add(customerEmailParam);
                command.Parameters.Add(customerTotalPurchasesAmountParam);
                command.Parameters.Add(customerCustomerIDParam);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int customerId)
        {
            using (var connection = new SqlConnection(
                "Server=ALFA;" +
                "Database=CustomerLib_Bezslyozniy;" +
                "Trusted_Connection=True;"))
            {
                connection.Open();

                var command = new SqlCommand(
                    "DELETE " +
                    "FROM [dbo].[Customers] " +
                    "WHERE " +
                    "[dbo].[Customers].[CustomerID] = @CustomerID", 
                    connection);

                var customerCustomerIDParam = new SqlParameter("@CustomerID", System.Data.SqlDbType.Int)
                {
                    Value = customerId
                };

                command.Parameters.Add(customerCustomerIDParam);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteAll()
        {
            using (var connection = new SqlConnection(
                "Server=ALFA;" +
                "Database=CustomerLib_Bezslyozniy;" +
                "Trusted_Connection=True;"))
            {
                connection.Open();

                var command = new SqlCommand(
                    "DELETE FROM [Customers];" +
                    "DELETE FROM [Addresses];" +
                    "DELETE FROM [Notes];" +
                    "DBCC CHECKIDENT (Customers, RESEED, 0);" +
                    "DBCC CHECKIDENT (Addresses, RESEED, 0);" +
                    "DBCC CHECKIDENT (Notes, RESEED, 0);", 
                    connection);

                command.ExecuteNonQuery();
            }
        }
    }
}
