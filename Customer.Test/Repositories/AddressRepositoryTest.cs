using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CustomerLib.Repositories;
namespace CustomerLib.Test.Repositories
{
    public class AddressRepositoryTest
    {
        [Fact]
        public void ShouldBeAbleToCreateAddressRepository()
        {
            var addressRepository = new AddressRepository();
            Assert.NotNull(addressRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            var addressRepository = new AddressRepository(); 
            var customerRepository = new CustomerRepository();
            
            customerRepository.DeleteAll();
            customerRepository.Create(new Customer()
                {
                    FirstName = "Alex",
                    LastName = "Xlea",
                    Addresses = new List<Address>() {
                        new Address(){
                        Line1 = "CustomerLine1",
                        Line2 = "CustomerLine2",
                        AddressType = Address.EAddressType.Shipping,
                        City = "Denver",
                        PostalCode = "121212",
                        State = "State",
                        Country = "Canada" } 
                    },
                    Notes = new List<string>() { 
                        "Customer Note" 
                    },
                    Phone = "+36098983443",
                    Email = "myname@gmail.com",
                    TotalPurchasesAmount = (decimal?)1234.3
                });


            var address = new Address("Line1 from Repo", 0, "Denver", "213223", "Gloria", "United States", "Line2 from Repo");
            addressRepository.Create(address, 1);

            var createdAddress = addressRepository.Read(1, 2);
            Assert.NotNull(createdAddress);

            Assert.Equal(address.Line1, createdAddress.Line1);
            Assert.Equal(address.Line2, createdAddress.Line2);
            Assert.Equal(address.AddressType, createdAddress.AddressType);
            Assert.Equal(address.City, createdAddress.City);
            Assert.Equal(address.PostalCode, createdAddress.PostalCode);
            Assert.Equal(address.State, createdAddress.State);
            Assert.Equal(address.Country, createdAddress.Country);

        }

        [Fact]
        public void ShouldBeAbleToReadAddress()
        {
            var addressRepository = new AddressRepository();
            var customerRepository = new CustomerRepository();

            customerRepository.DeleteAll();
            customerRepository.Create(new Customer()
            {
                FirstName = "Alex",
                LastName = "Xlea",
                Addresses = new List<Address>() {
                        new Address(){
                        Line1 = "CustomerLine1",
                        Line2 = "CustomerLine2",
                        AddressType = Address.EAddressType.Shipping,
                        City = "Denver",
                        PostalCode = "121212",
                        State = "State",
                        Country = "Canada" }
                    },
                Notes = new List<string>() {
                        "Customer Note"
                    },
                Phone = "+36098983443",
                Email = "myname@gmail.com",
                TotalPurchasesAmount = (decimal?)1234.3
            });


            var address = new Address("Line1 from Repo 2", 0, "Denver", "213223", "Gloria", "United States", "Line2 from Repo 2");
            addressRepository.Create(address, 1);

            var createdAddress = addressRepository.Read(1, 2);
            Assert.NotNull(createdAddress);
            
            Assert.Equal(address.Line1, createdAddress.Line1);
            Assert.Equal(address.Line2, createdAddress.Line2);
            Assert.Equal(address.AddressType, createdAddress.AddressType);
            Assert.Equal(address.City, createdAddress.City);
            Assert.Equal(address.PostalCode, createdAddress.PostalCode);
            Assert.Equal(address.State, createdAddress.State);
            Assert.Equal(address.Country, createdAddress.Country);
            
        }

        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            var addressRepository = new AddressRepository();
            var customerRepository = new CustomerRepository();
            var address = new Address("UPDATED LINE1", 0, "Denver", "213223", "Gloria", "United States", "Line2 from Repo");


            customerRepository.DeleteAll();
            customerRepository.Create(new Customer()
            {
                FirstName = "Alex",
                LastName = "Xlea",
                Addresses = new List<Address>() {
                    address
                    },
                Notes = new List<string>() {
                        "Customer Note"
                    },
                Phone = "+36098983443",
                Email = "myname@gmail.com",
                TotalPurchasesAmount = (decimal?)1234.3
            });
            

            addressRepository.Update(address, 1, 1);
            var updatedAddress = addressRepository.Read(1, 1);
            Assert.NotNull(updatedAddress);

            Assert.Equal(address.Line1, updatedAddress.Line1);
            Assert.Equal(address.Line2, updatedAddress.Line2);
            Assert.Equal(address.AddressType, updatedAddress.AddressType);
            Assert.Equal(address.City, updatedAddress.City);
            Assert.Equal(address.PostalCode, updatedAddress.PostalCode);
            Assert.Equal(address.State, updatedAddress.State);
            Assert.Equal(address.Country, updatedAddress.Country);
        }

        [Fact]
        public void ShouldBeAbleToDeleteAddress()
        {
            var addressRepository = new AddressRepository();
            var customerRepository = new CustomerRepository();
            int addressId = 1, customerId = 1;


            customerRepository.DeleteAll();
            customerRepository.Create(new Customer()
            {
                FirstName = "Alex",
                LastName = "Xlea",
                Addresses = new List<Address>() {
                    new Address(){
                        Line1 = "CustomerLine1",
                        Line2 = "CustomerLine2",
                        AddressType = Address.EAddressType.Shipping,
                        City = "Denver",
                        PostalCode = "121212",
                        State = "State",
                        Country = "Canada" }
                    },
                Notes = new List<string>() {
                        "Customer Note"
                    },
                Phone = "+36098983443",
                Email = "myname@gmail.com",
                TotalPurchasesAmount = (decimal?)1234.3
            });

            var address = new Address("Line1 from Repo", 0, "Denver", "213223", "Gloria", "United States", "Line2 from Repo");
            addressRepository.Create(address, customerId);

            addressRepository.Delete(customerId, addressId);
            Assert.Null(addressRepository.Read(customerId, addressId));
        }
    
        [Fact]
        public void ShouldBeAbleToReadAllAddresses()
        {
            var addressRepository = new AddressRepository();
            var customerRepository = new CustomerRepository();
            customerRepository.DeleteAll();
            customerRepository.Create(new Customer()
            {
                FirstName = "Alex",
                LastName = "Xlea",
                Addresses = new List<Address>() {
                    new Address(){
                        Line1 = "CustomerLine1",
                        Line2 = "CustomerLine2",
                        AddressType = Address.EAddressType.Shipping,
                        City = "Denver",
                        PostalCode = "121212",
                        State = "State",
                        Country = "Canada" },
                    new Address(){
                        Line1 = "CustomerLine12",
                        Line2 = "CustomerLine22",
                        AddressType = Address.EAddressType.Shipping,
                        City = "Denver",
                        PostalCode = "121212",
                        State = "SecondState",
                        Country = "Canada" }
                    },
                Notes = new List<string>() {
                        "Customer Note"
                    },
                Phone = "+36098983443",
                Email = "myname@gmail.com",
                TotalPurchasesAmount = (decimal?)1234.3
            });

            List<Address> readedAddresses = addressRepository.ReadAllAddresses(1);
            
            Assert.Equal("CustomerLine1", readedAddresses[0].Line1);
            Assert.Equal("State", readedAddresses[0].State);
            Assert.Equal("CustomerLine12", readedAddresses[1].Line1);
            Assert.Equal("SecondState", readedAddresses[1].State);
        }
    }
}
