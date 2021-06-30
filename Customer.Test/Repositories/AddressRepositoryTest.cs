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

            var address = new Address("Line1 from Repo", 0, "Denver", "213223", "Gloria", "United States", "Line2 from Repo");
            addressRepository.Create(address, 1);

            var createdAddress = addressRepository.Read(1, 1);
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

            var address = new Address("Line1 from Repo", 0, "Denver", "213223", "Gloria", "United States", "Line2 from Repo");
            var createdAddress = addressRepository.Read(1, 1);
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
            var address = new Address("UPDATED LINE1", 0, "Denver", "213223", "Gloria", "United States", "Line2 from Repo");
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
            int addressId = 1, customerId = 1;

            var address = new Address("Line1 from Repo", 0, "Denver", "213223", "Gloria", "United States", "Line2 from Repo");
            addressRepository.Create(address, customerId);

            addressRepository.Delete(customerId, addressId);
            Assert.Null(addressRepository.Read(customerId, addressId));
        }
    
        [Fact]
        public void ShouldBeAbleToReadAllAddresses()
        {
            AddressRepository addressRepo = new AddressRepository();
            List<Address> readedAddresses = addressRepo.ReadAllAddresses(1);
            
            Assert.Equal(readedAddresses[1].Line1, "UPDATED LINE1");
            Assert.Equal(readedAddresses[1].State, "Gloria");
            Assert.Equal(readedAddresses[15].Line1, "d");
            Assert.Equal(readedAddresses[15].State, "St");
        }
    }
}
