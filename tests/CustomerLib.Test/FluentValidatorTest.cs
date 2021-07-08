using Xunit;
using System.Collections.Generic;
using CustomerLib.Entities;
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
                CustomerID = 1,
                AddressID = 1,
                Line1 = "Spec Line",
                AddressType = "Shipping",
                City = "Kirkland",
                PostalCode = "282828",
                State = "MP",
                Country = "Canada"
            };
            Address address2 = new Address()
            {
                CustomerID = 1,
                AddressID = 2,
                Line1 = "Spec Line v2",
                AddressType = "Biling",
                City = "Kirkland Vein",
                PostalCode = "282828",
                State = "MP Vein",
                Country = "United States" //incorrect value
            };

            Customer customer = new Customer()
            {
                CustomerID = 1,
                FirstName = "Vlad",
                LastName = "Gray",
                Addresses = new List<Address>() { address1, address2 },
                Notes = new List<Note>() { 
                    new Note{
                        CustomerID = 1,
                        NoteID = 1,
                        Line = "CustomerLine" 
                    }
                },
                PhoneNumber = "+343434",
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
                CustomerID = 1,
                FirstName = "Vlad",
                LastName = "Gray",
                Addresses = new List<Address>(),
                Notes = new List<Note>() { 
                    new Note{
                        CustomerID = 1,
                        NoteID = 1,
                        Line = "Customer Note"    
                        }
                },
                PhoneNumber = "+343434",
                Email = "rpvv@ankocorp.com",
                TotalPurchasesAmount = 0.456m
            };

            CustomerValidator validator = new CustomerValidator();

            var result = validator.TestValidate(customer);
            result.ShouldHaveValidationErrorFor(customer => customer.Addresses).WithErrorCode("PredicateValidator");
        }
    }
}

