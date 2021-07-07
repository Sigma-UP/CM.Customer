using CustomerLib.Data.Repositories;
using Xunit;

using CustomerLib.IntegrationTests.Fixtures;

namespace CustomerLib.IntegrationTests.Repositories
{
    public class CustomerRepositoryTest
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomerRepository()
        {
            var customerRepository = new CustomerRepository();
            Assert.NotNull(customerRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var customerRepository = new CustomerRepository();
            var fixture = new RepositoriesFixture();
            var customer = fixture.CreateMockCustomer();

            var createdCustomer = customerRepository.Read(1);
            fixture.EqualCustomers(customer, createdCustomer);
        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            var customerRepository = new CustomerRepository();
            var fixture = new RepositoriesFixture();
            var customer = fixture.CreateMockCustomer();
            var readedCustomer = customerRepository.Read(1);
            fixture.EqualCustomers(customer, readedCustomer);
        }

        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            var customerRepository = new CustomerRepository();
            var fixture = new RepositoriesFixture();
            var customer = fixture.CreateMockCustomer();

            customer.FirstName = "Mikhail";
            customerRepository.Update(customer);
            
            var readedCustomer = customerRepository.Read(1);
            fixture.EqualCustomers(customer, readedCustomer);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var customerRepository = new CustomerRepository();
            var fixture = new RepositoriesFixture();
            var customer = fixture.CreateMockCustomer();

            Assert.NotNull(customerRepository.Read(1));

            customerRepository.Delete(1);

            Assert.Null(customerRepository.Read(1));
        }
    }
}
