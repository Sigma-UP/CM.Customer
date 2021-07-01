using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace CustomerLib.Repositories
{
    public class CustomerRepository
    {
        public int GetCustomerIndex(Customer customer)
        {
            using (var connection = new SqlConnection("Server=ALFA;Database=CustomerLib_Bezslyozniy;Trusted_Connection=True;"))
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM [Customers] WHERE PhoneNumber = @PhoneNumber", connection);

                var customerPhoneParam = new SqlParameter("PhoneNumber", System.Data.SqlDbType.VarChar, 15)
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
            using (var connection = new SqlConnection("Server=ALFA;Database=CustomerLib_Bezslyozniy;Trusted_Connection=True;"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Customers] (FirstName, LastName, PhoneNumber, Email, TotalPurchasesAmount)" +
                    "VALUES(@firstName, @lastName, @phoneNumber, @email, @totalPurchasesAmount); ", connection);

                var customerFirstNameParam = new SqlParameter("@firstName", System.Data.SqlDbType.VarChar, 50)
                {
                    Value = customer.FirstName
                };

                var customerLastNameParam = new SqlParameter("@lastName", System.Data.SqlDbType.VarChar, 50)
                {
                    Value = customer.LastName
                };

                var customerPhoneParam = new SqlParameter("@phoneNumber", System.Data.SqlDbType.VarChar, 15)
                {
                    Value = customer.Phone
                };

                var customerEmailParam = new SqlParameter("@email", System.Data.SqlDbType.VarChar, 320)
                {
                    Value = customer.Email
                };

                var customerTotalPurchasesAmountParam = new SqlParameter("@totalPurchasesAmount", System.Data.SqlDbType.Money)
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
            using (var connection = new SqlConnection("Server=ALFA;Database=CustomerLib_Bezslyozniy;Trusted_Connection=True;"))
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM [Customers] WHERE CustomerID = @customerId", connection);

                var customerCustomerIDParam = new SqlParameter("CustomerID", System.Data.SqlDbType.Int)
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
                            Addresses = AddressRepository.ReadAllAddresses(customerID),
                            Notes = NoteRepository.ReadAllNotes(customerID)
                        };
                    }
                }

                command.ExecuteNonQuery();
            }

            return null;
        }

        public void Update(Customer customer, int customerIdx)
        {
            using (var connection = new SqlConnection("Server=ALFA;Database=CustomerLib_Bezslyozniy;Trusted_Connection=True;"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("UPDATE [dbo].[Customers] " +
                    "SET" +
                    "[dbo].[Customers].[FirstName] = @first_name," +
                    "[dbo].[Customers].[LastName] = @last_name," +
                    "[dbo].[Customers].[PhoneNumber] = @phone_number," +
                    "[dbo].[Customers].[Email] = @email, " +
                    "[dbo].[Customers].[TotalPurchasesAmount] = @total_purchases_amount " +
                    "WHERE dbo.Customers.CustomerID = @customer_id; ", connection);
                var customerFirstNameParam = new SqlParameter("@first_name", System.Data.SqlDbType.VarChar, 50)
                {
                    Value = customer.FirstName
                };

                var customerLastNameParam = new SqlParameter("@last_name", System.Data.SqlDbType.VarChar, 50)
                {
                    Value = customer.LastName
                };

                var customerPhoneNumberParam = new SqlParameter("@phone_number", System.Data.SqlDbType.VarChar, 15)
                {
                    Value = customer.Phone
                };

                var customerEmailParam = new SqlParameter("@email", System.Data.SqlDbType.VarChar, 320)
                {
                    Value = customer.Email
                };

                var customerTotalPurchasesAmountParam = new SqlParameter("@total_purchases_amount", System.Data.SqlDbType.Money)
                {
                    Value = customer.TotalPurchasesAmount
                };

                var customerCustomerIDParam = new SqlParameter("@customer_id", System.Data.SqlDbType.Int)
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
            using (var connection = new SqlConnection("Server=ALFA;Database=CustomerLib_Bezslyozniy;Trusted_Connection=True;"))
            {
                connection.Open();

                var command = new SqlCommand("DELETE FROM [Customers] WHERE CustomerID = @CustomerID", connection);

                var customerCustomerIDParam = new SqlParameter("CustomerID", System.Data.SqlDbType.Int)
                {
                    Value = customerId
                };

                command.Parameters.Add(customerCustomerIDParam);

                command.ExecuteNonQuery();
            }
        }
    }
}
