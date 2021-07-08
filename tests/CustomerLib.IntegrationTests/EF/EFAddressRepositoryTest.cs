using CustomerLib.IntegrationTests.Fixtures;
using CustomerLib.Data.Repositories;
using CustomerLib.Data.EF;
using CustomerLib.Entities;
using Xunit;

namespace CustomerLib.IntegrationTests.EF
{
    public class EFAddressRepositoryTest
    {
        [Fact]
        public void ShouldBeAbleToCreateEFAddressRepository()
        {
            var addressRepository = new EFAddressRepository();
            Assert.NotNull(addressRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            var cc = new CustomerRepository();
            cc.DeleteAll(); //method contains refresh ID`s

            var addressRepository = new EFAddressRepository();
            var customerRepository = new EFCustomerRepository();
            var fixture = new EFRepositoriesFixture();
            var customer = fixture.CreateMockCustomer();
            addressRepository.Create(new Entities.Address
            {
                CustomerID = 1,
                Line1 = "2",
                Line2 = "2",
                PostalCode = "214321",
                AddressType= "Biling",
                City = "Denver",
                State = "Ilinois",
                Country = "United States"
            }
            );

            var createdAddress = addressRepository.Read(1);

            fixture.EqualAddresses(customer.Addresses[0], createdAddress);
        }

        [Fact]
        public void ShouldBeAbleToReadAddress()
        {
            var cc = new CustomerRepository();
            cc.DeleteAll(); //method contains refresh ID`s

            var addressRepository = new EFAddressRepository();
            var fixture = new EFRepositoriesFixture();

            var customer = fixture.CreateMockCustomer();

            var createdAddress = addressRepository.Read(1);
            fixture.EqualAddresses(customer.Addresses[0], createdAddress);
        }

        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            var cc = new CustomerRepository();
            cc.DeleteAll(); //method contains refresh ID`s
            var addressRepository = new EFAddressRepository();
            var fixture = new EFRepositoriesFixture();

            var customer = fixture.CreateMockCustomer();

            var createdAddress = addressRepository.Read(1);
            fixture.EqualAddresses(customer.Addresses[0], createdAddress);

            var newAddress = new Address
            {
                CustomerID = 1,
                AddressID = 1,
                Line1 = "Updated L1",
                Line2 = "Updated L2",
                AddressType = "Billing",
                City = "UPD",
                State = "Ilinois",
                PostalCode = "122332",
                Country = "United States"
            };
            addressRepository.Update(newAddress);

            var updatedAddress = addressRepository.Read(1);
            Assert.NotNull(updatedAddress);

            fixture.EqualAddresses(newAddress, updatedAddress);
        }

        [Fact]
        public void ShouldBeAbleToDeleteAddress()
        {
            var cc = new CustomerRepository();
            cc.DeleteAll(); //method contains refresh ID`s

            var addressRepository = new EFAddressRepository();
            var fixture = new EFRepositoriesFixture();

            var customer = fixture.CreateMockCustomer();
            Assert.NotNull(addressRepository.Read(1));

            addressRepository.Delete(1);
            Assert.Null(addressRepository.Read(1));
        }

        [Fact]
        public void ShouldBeAbleToReadAllAddresses()
        {
            var cc = new CustomerRepository();
            cc.DeleteAll(); //method contains refresh ID`s
            var addressRepository = new EFAddressRepository();
            var fixture = new EFRepositoriesFixture();

            var customer = fixture.CreateMockCustomer();
            var manualCreatedAddress = new Address
            {
                CustomerID = 1,
                Line1 = "Line1, second Address",
                Line2 = "Line1, second Address",
                City = "Denver",
                State = "Ilinois",
                PostalCode = "123212",
                Country = "United States",
                AddressType = "Billing"
            };

            var readedAddress = addressRepository.Read(1);
            fixture.CreateMockAddress();
            addressRepository.Create(manualCreatedAddress);

            Assert.NotNull(addressRepository.Read(1));
            Assert.NotNull(addressRepository.Read(2));
            Assert.NotNull(addressRepository.Read(3));

            customer.Addresses = addressRepository.ReadAllAddresses(1);
            fixture.EqualAddresses(customer.Addresses[0], readedAddress);
            fixture.EqualAddresses(customer.Addresses[1], readedAddress);
            fixture.EqualAddresses(customer.Addresses[2], manualCreatedAddress);
        }
    }
}
