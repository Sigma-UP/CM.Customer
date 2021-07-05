using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using CustomerLib.Entities;

namespace CustomerLib.Data.Repositories
{
    [ExcludeFromCodeCoverage]
    public class AddressRepository : BaseRepository
    {
        public void Create(Address address, int customerIdx)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "INSERT " +
                    "INTO [dbo].[Addresses] " +
                    "( CustomerID, Line1, Line2, AddressType, City, PostalCode, [State], Country )" +
                    "VALUES " +
                    "( @CustomerID, @Line1, @Line2, @AddressType, @City, @PostalCode, @State, @Country )",
                    connection);
                var addressCustomerIDParam = new SqlParameter("@CustomerID", System.Data.SqlDbType.Int)
                {
                    Value = customerIdx
                };

                var addressLine1Param = new SqlParameter("@Line1", System.Data.SqlDbType.VarChar, 100)
                {
                    Value = address.Line1
                };

                var addressLine2Param = new SqlParameter("@Line2", System.Data.SqlDbType.VarChar, 100)
                {
                    Value = address.Line2
                };

                var addressAddressTypeParam = new SqlParameter("@AddressType", System.Data.SqlDbType.VarChar, 10)
                {
                    Value = address.AddressType == 0 ? "Shipping" : "Billing" 
                };

                var addressCityParam = new SqlParameter("@City", System.Data.SqlDbType.VarChar, 50)
                {
                    Value = address.City
                };

                var addressPostalCodeParam = new SqlParameter("@PostalCode", System.Data.SqlDbType.VarChar, 6)
                {
                    Value = address.PostalCode
                };

                var addressStateParam = new SqlParameter("@State", System.Data.SqlDbType.VarChar, 20)
                {
                    Value = address.State
                };

                var addressCountryParam = new SqlParameter("@Country", System.Data.SqlDbType.VarChar, 15)
                {
                    Value = address.Country
                };

                command.Parameters.Add(addressCustomerIDParam);
                command.Parameters.Add(addressLine1Param);
                command.Parameters.Add(addressLine2Param);
                command.Parameters.Add(addressAddressTypeParam);
                command.Parameters.Add(addressCityParam);
                command.Parameters.Add(addressPostalCodeParam);
                command.Parameters.Add(addressStateParam);
                command.Parameters.Add(addressCountryParam);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Address address, int customerIdx, int addressIdx)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "UPDATE [dbo].[Addresses] " +
                    "SET " +
                    "[dbo].[Addresses].[Line1]          = @Line1, " +
                    "[dbo].[Addresses].[Line2]          = @Line2, " +
                    "[dbo].[Addresses].[AddressType]    = @AddressType, " +
                    "[dbo].[Addresses].[City]           = @City, " +
                    "[dbo].[Addresses].[PostalCode]     = @PostalCode, " +
                    "[dbo].[Addresses].[State]          = @State, " +
                    "[dbo].[Addresses].[Country]        = @Country " +
                    "WHERE " +
                    "[dbo].[Addresses].[CustomerID] = @CustomerID AND " +
                    "[dbo].[Addresses].[AddressID]  = @AddressID ", 
                    connection);
                var addressCustomerIDParam = new SqlParameter("@CustomerID", System.Data.SqlDbType.Int)
                {
                    Value = customerIdx
                };

                var addressAddressIDParam = new SqlParameter("@AddressID", System.Data.SqlDbType.Int)
                {
                    Value = addressIdx
                };

                var addressLine1Param = new SqlParameter("@Line1", System.Data.SqlDbType.VarChar, 100)
                {
                    Value = address.Line1
                };

                var addressLine2Param = new SqlParameter("@Line2", System.Data.SqlDbType.VarChar, 100)
                {
                    Value = address.Line2
                };

                var addressAddressTypeParam = new SqlParameter("@AddressType", System.Data.SqlDbType.VarChar, 10)
                {
                    //Value = address.GetAddressTypeAsString()
                    Value = address.AddressType == 0 ? "Shipping" : "Billing"
                };

                var addressCityParam = new SqlParameter("@City", System.Data.SqlDbType.VarChar, 50)
                {
                    Value = address.City
                };

                var addressPostalCodeParam = new SqlParameter("@PostalCode", System.Data.SqlDbType.VarChar, 6)
                {
                    Value = address.PostalCode
                };

                var addressStateParam = new SqlParameter("@State", System.Data.SqlDbType.VarChar, 20)
                {
                    Value = address.State
                };

                var addressCountryParam = new SqlParameter("@Country", System.Data.SqlDbType.VarChar, 15)
                {
                    Value = address.Country
                };

                command.Parameters.Add(addressCustomerIDParam);
                command.Parameters.Add(addressAddressIDParam);
                command.Parameters.Add(addressLine1Param);
                command.Parameters.Add(addressLine2Param);
                command.Parameters.Add(addressAddressTypeParam);
                command.Parameters.Add(addressCityParam);
                command.Parameters.Add(addressPostalCodeParam);
                command.Parameters.Add(addressStateParam);
                command.Parameters.Add(addressCountryParam);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int customerId, int addressId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "DELETE " +
                    "FROM [Addresses] " +
                    "WHERE " +
                    "[dbo].[Addresses].[CustomerID] = @CustomerID AND " +
                    "[dbo].[Addresses].[AddressID]  = @AddressID", 
                    connection);

                var addressCustomerIDParam = new SqlParameter("@CustomerID", System.Data.SqlDbType.Int)
                {
                    Value = customerId
                };
                var addressIDParam = new SqlParameter("@AddressID", System.Data.SqlDbType.Int)
                {
                    Value = addressId
                };

                command.Parameters.Add(addressCustomerIDParam);
                command.Parameters.Add(addressIDParam);


                command.ExecuteNonQuery();
            }
        }

        public Address Read(int customerId, int addressId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT * " +
                    "FROM [Addresses] " +
                    "WHERE " +
                    "[dbo].[Addresses].[CustomerID] = @CustomerId AND " +
                    "[dbo].[Addresses].[AddressID]  = @AddressID", 
                    connection);

                var addressCustomerIDParam = new SqlParameter("@CustomerID", System.Data.SqlDbType.Int)
                {
                    Value = customerId
                };
                var addressIDParam = new SqlParameter("@AddressID", System.Data.SqlDbType.Int)
                {
                    Value = addressId
                };

                command.Parameters.Add(addressCustomerIDParam);
                command.Parameters.Add(addressIDParam);

                using (var reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        return new Address()
                        {
                            Line1 = reader["Line1"]?.ToString(),
                            Line2 = reader["Line2"]?.ToString(),
                            AddressType = (Address.EAddressType)(reader["AddressType"].ToString() == "Shipping" ? 0 : 1),
                            City = reader["City"]?.ToString(),
                            PostalCode = reader["PostalCode"]?.ToString(),
                            State = reader["State"]?.ToString(),
                            Country = reader["Country"]?.ToString(),
                        };
                    }
                }

                command.ExecuteNonQuery();
            }

            return null;
        }

        public List<Address> ReadAllAddresses(int customerId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT * " +
                    "FROM [Addresses] " +
                    "WHERE " +
                    "[dbo].[Addresses].[CustomerID] = @customerId " +
                    "ORDER BY " +
                    "[dbo].[Addresses].[CustomerID]", 
                    connection);

                var addressCustomerIDParam = new SqlParameter("@customerID", System.Data.SqlDbType.Int)
                {
                    Value = customerId
                };

                command.Parameters.Add(addressCustomerIDParam);

                List<Address> readedAddresses = new List<Address>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        readedAddresses.Add(new Address()
                        {
                            Line1 = reader["Line1"]?.ToString(),
                            Line2 = reader["Line2"]?.ToString(),
                            AddressType = (Address.EAddressType)(reader["AddressType"].ToString() == "Shipping" ? 0 : 1),
                            City = reader["City"]?.ToString(),
                            PostalCode = reader["PostalCode"]?.ToString(),
                            State = reader["State"]?.ToString(),
                            Country = reader["Country"]?.ToString(),
                        });
                    }
                }

                command.ExecuteNonQuery();
                return readedAddresses;
            }
        }

        public void DeleteAll()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "DELETE " +
                    "FROM [Addresses];" +
                    "DBCC CHECKIDENT (Addresses, RESEED, 0);", 
                    connection);

                command.ExecuteNonQuery();
            }
        }
    }
}
