using Xunit;
using CustomerLib.Repositories;
namespace CustomerLib.IntegrationTests.Repositories
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
            var fixture = new RepositoriesFixture();

            var customer = fixture.CreateMockCustomer();
            
            var createdAddress = addressRepository.Read(1, 1);
            
            fixture.EqualAddresses(customer.Addresses[0], createdAddress);
        }

        [Fact]
        public void ShouldBeAbleToReadAddress()
        {
            var addressRepository = new AddressRepository();
            var fixture = new RepositoriesFixture();

            var customer = fixture.CreateMockCustomer();

            var createdAddress = addressRepository.Read(1, 1);
            fixture.EqualAddresses(customer.Addresses[0], createdAddress);
        }

        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            var addressRepository = new AddressRepository();
            var fixture = new RepositoriesFixture();

            var customer = fixture.CreateMockCustomer();

            var createdAddress = addressRepository.Read(1, 1);
            fixture.EqualAddresses(customer.Addresses[0], createdAddress);
            
            var newAddress = new Address
            {
                Line1 = "Updated L1",
                Line2 = "Updated L2",
                AddressType = Address.EAddressType.Biling,
                City = "UPD",
                State = "Ilinois",
                PostalCode = "122332",
                Country = "United States"
            };
            addressRepository.Update(newAddress, 1, 1);

            var updatedAddress = addressRepository.Read(1, 1);
            Assert.NotNull(updatedAddress);

            fixture.EqualAddresses(newAddress, updatedAddress);
        }

        [Fact]
        public void ShouldBeAbleToDeleteAddress()
        {
            var addressRepository = new AddressRepository();
            var fixture = new RepositoriesFixture();

            var customer = fixture.CreateMockCustomer();

            addressRepository.Delete(1, 1);
            Assert.Null(addressRepository.Read(1, 1));
        }
    
        [Fact]
        public void ShouldBeAbleToReadAllAddresses()
        {
            var addressRepository = new AddressRepository();
            var fixture = new RepositoriesFixture();

            var customer = fixture.CreateMockCustomer();
            var manualCreatedAddress = new Address
            {
                Line1 = "Line1, second Address",
                Line2 = "Line1, second Address",
                City = "Denver",
                State = "Ilinois",
                PostalCode = "123212",
                Country = "United States",
                AddressType = Address.EAddressType.Biling
            };

            var readedAddress = addressRepository.Read(1, 1);
            fixture.CreateMockAddress();
            addressRepository.Create(manualCreatedAddress, 1);

            Assert.NotNull(addressRepository.Read(1, 1));
            Assert.NotNull(addressRepository.Read(1, 2));
            Assert.NotNull(addressRepository.Read(1, 3));

            customer.Addresses = addressRepository.ReadAllAddresses(1);
            fixture.EqualAddresses(customer.Addresses[0], readedAddress);
            fixture.EqualAddresses(customer.Addresses[1], readedAddress);
            fixture.EqualAddresses(customer.Addresses[2], manualCreatedAddress);
        }
    }
}
