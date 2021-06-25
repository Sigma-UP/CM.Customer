using Xunit;
using CustomerLib.Main;
using System.Collections.Generic;
using CustomerLib.Entities.Validators;
using FluentValidation.TestHelper;

namespace CustomerLib.Test
{
    public class FluentValidatorsTest
    {
        [Fact]
        public void CustomerValidatorShouldNotHaveAnyValidationErrors()
        {
            Address address1 = new Address()
            {
                Line1 = "Spec Line",
                AddressType = (Address.EAddressType)1,
                City = "Kirkland",
                PostalCode = "282828",
                State = "MP",
                Country = "Canada"
            };
            Address address2 = new Address()
            {
                Line1 = "Spec Line v2",
                AddressType = 0,
                City = "Kirkland Vein",
                PostalCode = "282828",
                State = "MP Vein",
                Country = "United States" //incorrect value
            };

            Customer customer = new Customer()
            {
                FirstName = "Vlad",
                LastName = "Gray",
                Addresses = new List<Address>() { address1, address2 },
                Notes = new List<string>() { new string('a', 20) },
                Phone = "+343434",
                Email = "rpvv@ankocorp.com",
                TotalPurchasesAmount = 0.456m
            };
            
            CustomerValidator validator = new CustomerValidator();

            var result = validator.TestValidate(customer);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void CustomerValidatorShouldHaveAddressValidationError()
        {
            Customer customer = new Customer()
            {
                FirstName = "Vlad",
                LastName = "Gray",
                Addresses = new List<Address>(),
                Notes = new List<string>() { new string('a', 20) },
                Phone = "+343434",
                Email = "rpvv@ankocorp.com",
                TotalPurchasesAmount = 0.456m
            };

            CustomerValidator validator = new CustomerValidator();

            var result = validator.TestValidate(customer);
            result.ShouldHaveValidationErrorFor(customer => customer.Addresses).WithErrorCode("PredicateValidator");
        }
    }
}

