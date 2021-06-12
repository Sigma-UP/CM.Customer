using Xunit;
using CustomerLib.Main;
using System.Collections.Generic;
using CustomerLib.Entities.Validators;
using FluentValidation.TestHelper;

namespace CustomerLib.Test
{
    public class CustomerTest
    {

        private Customer _c = new Customer();

        [Fact]
        public void FirstNameShouldSaveNullOrCorrectString()
        {
            Assert.Null(_c.FirstName);

            _c.FirstName = "21341";
            Assert.Null(_c.FirstName);

            _c.FirstName = "Stew22";
            Assert.Null(_c.FirstName);
            _c.FirstName = "     ";
            Assert.Null(_c.FirstName);

            _c.FirstName = null;
            Assert.Null(_c.FirstName);

            _c.FirstName = new string('A', 51);
            Assert.Null(_c.FirstName);

            _c.FirstName = "Stewie  ";
            Assert.Equal("Stewie  ", _c.FirstName);

            //it should save string without spaces: check
            //for the first char as space and repeated double
            //etc spaces. Latest char must be !space
            //Parameter:
            //"Stewie   "
            //Result:
            //Assert.Equal("Stewie", c.FirstName);

            _c.FirstName = "Stewie";
            Assert.Equal("Stewie", _c.FirstName);

            _c.FirstName = new string('A', 50);
            Assert.Equal(new string('A', 50), _c.FirstName);

        }

        [Fact]
        public void LastNameShouldSaveNullOrCorrectString()
        {
            Assert.Null(_c.LastName);

            _c.FirstName = "21341";
            Assert.Null(_c.LastName);

            _c.FirstName = "Griffin2007";
            Assert.Null(_c.LastName);

            _c.FirstName = "     ";
            Assert.Null(_c.LastName);

            _c.LastName = new string('A', 51);
            Assert.Null(_c.LastName);

            _c.LastName = "Griffin";
            Assert.Equal("Griffin", _c.LastName);

            _c.LastName = new string('A', 50);
            Assert.Equal(new string('A', 50), _c.LastName);

            _c.LastName = null;
            Assert.Null(_c.LastName);
        }

        [Fact]
        public void PhoneShouldSaveOnlyE164FormatOrNull()
        {
            Assert.Null(_c.Phone);

            _c.Phone = "111222333444555";
            Assert.Null(_c.Phone);

            _c.Phone = "+111-222";
            Assert.Null(_c.Phone);

            _c.Phone = null;
            Assert.Null(_c.Phone);

            _c.Phone = "";
            Assert.Null(_c.Phone);

            _c.Phone = "+345";
            Assert.Equal("+345", _c.Phone);

            _c.Phone = "+111222333444555";
            Assert.Equal("+111222333444555", _c.Phone);
        }

        [Fact]
        public void EmailShouldSaveNullOrCorrectString()
        {
            _c.Email = null;
            Assert.Null(_c.Email);

            _c.Email = "invalidEmail";
            Assert.Null(_c.Email);

            _c.Email = "sdwdeeesf@.com";
            Assert.Null(_c.Email);

            _c.Email = "@gmail.com";
            Assert.Null(_c.Email);

            _c.Email = "sdwdeeesf@gmail";
            Assert.Null(_c.Email);

            _c.Email = "sdwdeeesf@@gmail";
            Assert.Null(_c.Email);

            _c.Email = "mynametrump@gmail.com";
            Assert.Equal("mynametrump@gmail.com", _c.Email);

            _c.Email = null;
            Assert.Null(_c.Email);
        }

        [Fact]
        public void TotalPurchasesAmountShouldSaveNullOrDecimal()
        {
            _c.TotalPurchasesAmount = -24.4m;
            Assert.Null(_c.TotalPurchasesAmount);

            _c.TotalPurchasesAmount = 0.0m;
            Assert.Equal(0.0m, _c.TotalPurchasesAmount);

            _c.TotalPurchasesAmount = 1.2m;
            Assert.Equal(1.2m, _c.TotalPurchasesAmount);

            _c.TotalPurchasesAmount = null;
            Assert.Null(_c.TotalPurchasesAmount);
        }
        [Fact]
        public void NewAddressShouldSaveCorrectData()
        {
            Address address = new Address("B.Herrington str.", 1, "Zhma", "121782", "Juna", "United States");
            _c.Addresses = new List<Address>();
            _c.Addresses.Add(address);
            Assert.Equal("B.Herrington str.", _c.Addresses[0].Line1);
            Assert.Equal("Zhma", _c.Addresses[0].City);

            address.Line1 = "";
            _c.Addresses.Add(address);
            Assert.Null(_c.Addresses[1].Line1);
        }

        [Fact]
        public void NotesShouldSaveCorrectStringOrNull()
        {
            List<string> notes = new List<string>();

            notes.Add("Note1");
            notes.Add("Note2");
            Customer LocalNew = new Customer();
            LocalNew.Notes = notes;
            Assert.Equal(notes, LocalNew.Notes);
        }
    }

    public class AddressTest
    {
        private Address _address = new Address();

        [Fact]
        public void LinesShouldSaveNullOrCorrectString()
        {
            Assert.Null(_address.Line1);
            Assert.Null(_address.Line2);

            _address.Line1 = "Gold Lion str., h.2";
            _address.Line2 = "Gold Lion str., h.4";
            Assert.Equal("Gold Lion str., h.2", _address.Line1);
            Assert.Equal("Gold Lion str., h.4", _address.Line2);

            _address.Line1 = "";
            Assert.Null(_address.Line1);

            _address.Line1 = new string('#', 101);
            _address.Line2 = new string('A', 100);
            Assert.Null(_address.Line1);
            Assert.Equal(new string('A', 100), _address.Line2);

            _address.Line1 = null;
            _address.Line2 = null;
            Assert.Null(_address.Line1);
            Assert.Null(_address.Line2);

        }

        [Fact]
        public void AddressTypeShouldSave0Or1()
        {
            Assert.Equal(0, (int)_address.AddressType);

            Assert.Equal(Address.EAddressType.Shipping, _address.AddressType);

            _address.AddressType = (Address.EAddressType)1;
            Assert.Equal(Address.EAddressType.Biling, _address.AddressType);

            _address.AddressType = (Address.EAddressType)3;
            Assert.Equal(Address.EAddressType.Shipping, _address.AddressType);

            _address.AddressType = (Address.EAddressType)2;
            Assert.Equal(Address.EAddressType.Shipping, _address.AddressType);
        }

        [Fact]
        public void CityShouldSaveNullOrCorrectString()
        {
            Assert.Null(_address.City);

            _address.City = "21341";
            Assert.Null(_address.City);

            _address.City = "City-17";
            Assert.Null(_address.City);

            _address.City = "     ";
            Assert.Null(_address.City);

            _address.City = new string('A', 51);
            Assert.Null(_address.City);

            _address.City = "Gran-Soren";
            Assert.Equal("Gran-Soren", _address.City);

            _address.City = "Gran Soren";
            Assert.Equal("Gran Soren", _address.City);

            _address.City = new string('A', 50);
            Assert.Equal(new string('A', 50), _address.City);

            _address.City = null;
            Assert.Null(_address.City);

        }

        [Fact]
        public void PostalCodeShouldSaveNullOrCorrectString()
        {
            Assert.Null(_address.PostalCode);

            _address.PostalCode = "";
            Assert.Null(_address.PostalCode);

            _address.PostalCode = " ";
            Assert.Null(_address.PostalCode);

            _address.PostalCode = "dsdfdf";
            Assert.Null(_address.PostalCode);

            _address.PostalCode = "1231231";
            Assert.Null(_address.PostalCode);

            _address.PostalCode = "123123";
            Assert.Equal("123123", _address.PostalCode);

            _address.PostalCode = null;
            Assert.Null(_address.PostalCode);
        }

        [Fact]
        public void StateShouldSaveNullOrCorrectString()
        {
            Assert.Null(_address.State);

            _address.State = "";
            Assert.Null(_address.State);

            _address.State = " ";
            Assert.Null(_address.State);

            _address.State = "1231231";
            Assert.Null(_address.State);

            _address.State = "Alabama1";
            Assert.Null(_address.State);

            _address.State = "Alabama";
            Assert.Equal("Alabama", _address.State);

            _address.State = new string('A', 21);
            Assert.Null(_address.State);

            _address.State = new string('A', 20);
            Assert.Equal(new string('A', 20), _address.State);

            _address.State = null;
            Assert.Null(_address.State);
        }

        [Fact]
        public void CountryShouldSaveNullOrCorrectString()
        {
            Assert.Null(_address.Country);

            _address.Country = "Nigeria";
            Assert.Null(_address.Country);

            _address.Country = " ";
            Assert.Null(_address.Country);

            _address.Country = "12";
            Assert.Null(_address.Country);

            _address.Country = "United States";
            Assert.Equal("United States", _address.Country);

            _address.Country = null;
            Assert.Null(_address.Country);

            _address.Country = "Canada";
            Assert.Equal("Canada", _address.Country);
        }

        [Fact]
        public void AddressConstructorShouldSaveCorrectly()
        {
            Address a = new Address("LINE1", 1, "CITY", "212121", "STATE", "Canada");
            Assert.Equal("LINE1", a.Line1);
            Assert.Equal(Address.EAddressType.Biling, a.AddressType);
            Assert.Equal("CITY", a.City);
            Assert.Equal("212121", a.PostalCode);
            Assert.Equal("STATE", a.State);
            Assert.Equal("Canada", a.Country);
        }
    }

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

    public class WrappedConsoleTest
    {
        [Fact]
        public void ShouldOutputCorrectString()
        {
            IConsoleWrapper consoleWrapper = new MockConsoleWrapper();
            consoleWrapper.WriteLine("Customer 1:");
            consoleWrapper.Write("Name: ");
            string FirstName = consoleWrapper.ReadLine();
            consoleWrapper.Write("Surname: ");
            string LastName = consoleWrapper.ReadLine();

            Assert.Equal("Till", ((MockConsoleWrapper)consoleWrapper).inputLog[0]);
            Assert.Equal("Lindemann", ((MockConsoleWrapper)consoleWrapper).inputLog[1]);

            Assert.Equal("Customer 1:", ((MockConsoleWrapper)consoleWrapper).outputLog[0]);
            Assert.Equal("Name: ", ((MockConsoleWrapper)consoleWrapper).outputLog[1]);
            Assert.Equal("Surname: ", ((MockConsoleWrapper)consoleWrapper).outputLog[2]);

        }
    }

    public class ProgramMainTest
    {
        [Fact]
        public void ShouldReceiveCorrectValuesFromUserAndCreateAnInstanceOfCustomer()
        {
            Program.ConsoleWrapper = new MockConsoleWrapper();
            Program.Main(new string [0]);
            int lastOutputItemIdx = ((MockConsoleWrapper)(Program.ConsoleWrapper)).outputLog.Count - 1;
            Assert.Equal("Success", ((MockConsoleWrapper)(Program.ConsoleWrapper)).outputLog[lastOutputItemIdx]);

        }
        
    }
    public class MockConsoleWrapper : IConsoleWrapper
    {
        public List<string> outputLog = new List<string>();
        public List<string> inputLog = new List<string>();
        int inCount = -1;

        public string ReadLine()
        {
            inCount++;
            if (inCount == 0)
            {
                inputLog.Add("Till");
                return "Till";
            }
            else if (inCount == 1)
            {
                inputLog.Add("Lindemann");
                return "Lindemann";
            }
            else if (inCount == 2)
            {
                inputLog.Add("+38090");
                return "+38090";
            }
            else if (inCount == 3)
            {
                inputLog.Add("d@mail.com");
                return "d@mail.com";
            }
            else if (inCount == 4)
            {
                inputLog.Add("13,9");
                return "13,9";
            }
            else if (inCount == 5)
            {
                inputLog.Add("Some note");
                return "Some note";
            }
            else
            {
                inputLog.Add("2");
                return "2";
            }
        }
        public void WriteLine(string str)
        {
            outputLog.Add(str);
        }
        public void Write(string str)
        {
            outputLog.Add(str);
        }
    }
}

