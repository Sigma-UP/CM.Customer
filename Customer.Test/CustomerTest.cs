using System;
using Xunit;
using System.Collections.Generic;
using CustomerLib;


namespace CustomerLib.Test
{
    public class CustomerTest
    {

        Customer c = new Customer();
        
        [Fact]
        public void FirstNameShouldSaveNullOrCorrectString()
        {
            Assert.Null(c.FirstName);

            c.FirstName = "21341";
            Assert.Null(c.FirstName);

            c.FirstName = "Stew22";
            Assert.Null(c.FirstName);
            c.FirstName = "     ";
            Assert.Null(c.FirstName);

            c.FirstName = null;
            Assert.Null(c.FirstName);

            c.FirstName = new string('A', 51);
            Assert.Null(c.FirstName);

            c.FirstName = "Stewie  ";
            Assert.Equal("Stewie  ", c.FirstName);

            //it should save string without spaces: check
            //for the first char as space and repeated double
            //etc spaces. Latest char must be !space
            //Parameter:
            //"Stewie   "
            //Result:
            //Assert.Equal("Stewie", c.FirstName);

            c.FirstName = "Stewie";
            Assert.Equal("Stewie", c.FirstName);

            c.FirstName = new string('A', 50);
            Assert.Equal(new string('A', 50), c.FirstName);

        }

        [Fact]
        public void LastNameShouldSaveNullOrCorrectString()
        {
            Assert.Null(c.LastName);

            c.FirstName = "21341";
            Assert.Null(c.LastName);

            c.FirstName = "Griffin2007";
            Assert.Null(c.LastName);

            c.FirstName = "     ";
            Assert.Null(c.LastName);

            c.LastName = new string('A', 51);
            Assert.Null(c.LastName);
            
            c.LastName = "Griffin";
            Assert.Equal("Griffin", c.LastName);
            
            c.LastName = new string('A', 50);
            Assert.Equal(new string('A', 50), c.LastName);

            c.LastName = null;
            Assert.Null(c.LastName);
        }

        [Fact]
        public void PhoneShouldSaveOnlyE164FormatOrNull()
        {
            Assert.Null(c.Phone);

            c.Phone = "111222333444555";
            Assert.Null(c.Phone);

            c.Phone = "+111-222";
            Assert.Null(c.Phone);

            c.Phone = null;
            Assert.Null(c.Phone);

            c.Phone = "";
            Assert.Null(c.Phone);

            c.Phone = "+345";
            Assert.Equal("+345", c.Phone);

            c.Phone = "+111222333444555";
            Assert.Equal("+111222333444555", c.Phone);
        }

        [Fact]
        public void EmailShouldSaveNullOrCorrectString()
        {
            c.Email = null;
            Assert.Null(c.Email);

            c.Email = "invalidEmail";
            Assert.Null(c.Email);
            
            c.Email = "sdwdeeesf@.com";
            Assert.Null(c.Email);
            
            c.Email = "@gmail.com";
            Assert.Null(c.Email);
            
            c.Email = "sdwdeeesf@gmail";
            Assert.Null(c.Email);
            
            c.Email = "sdwdeeesf@@gmail";
            Assert.Null(c.Email);
            
            c.Email = "mynametrump@gmail.com";
            Assert.Equal("mynametrump@gmail.com", c.Email);

            c.Email = null;
            Assert.Null(c.Email);
        }

        [Fact]
        public void TotalPurchasesAmountShouldSaveNullOrDecimal()
        {
            c.TotalPurchasesAmount = -24.4;
            Assert.Null(c.TotalPurchasesAmount);

            c.TotalPurchasesAmount = 0.0;
            Assert.Equal((decimal)0.0, c.TotalPurchasesAmount);

            c.TotalPurchasesAmount = 1.2;
            Assert.Equal((decimal)1.2 ,c.TotalPurchasesAmount);
        
            c.TotalPurchasesAmount = null;
            Assert.Null(c.TotalPurchasesAmount);
        }
        //[Fact]
        //public void NewAddressShouldSaveCorrectData()
        //{
        //    Address address = new Address("B.Herrington str.", 1, "Zhma", "121782", "Juna", "United States");
        //    c.Addresses.Add(address);
        //    Assert.Equal(address.City, c.Addresses[0].City);
        //}
        //
        //[Fact]
        //public void NotesShouldSaveCorrectStringOrNull()
        //{
        //    string a = "Note1";
        //    c.Notes.Add(a);
        //    Assert.Equal(a, c.Notes[0]);
        //
        //    a = " ";
        //    c.Notes.Add(a);
        //    Assert.Null(c.Notes[1]);
        //
        //}

        [Fact]
        public void CustomerValidatorShouldReturnCorrectListOfErrors()
        {
            Customer c2 = new Customer("Stewie", "Griffin", null, "+380989700213", "s.griffin2002@qmail.com", null, 123.4);
            Assert.Equal("Stewie", c2.FirstName);
            Assert.Equal("Griffin", c2.LastName);
            Assert.Null(c2.Addresses);
            Assert.Equal("+380989700213", c2.Phone);
            Assert.Equal("s.griffin2002@qmail.com", c2.Email);
            Assert.Null(c2.Notes);
            Assert.Equal((decimal)123.4, c2.TotalPurchasesAmount);
        }
    }

    public class AddressTest
    {
        Address address = new Address();

        [Fact]
        public void LineShouldSaveNullOrCorrectString()
        {
            Assert.Null(address.Line1);
            Assert.Null(address.Line2);
            
            address.Line1 = "Gold Lion str., h.2";
            address.Line2 = "Gold Lion str., h.4";
            Assert.Equal("Gold Lion str., h.2", address.Line1);
            Assert.Equal("Gold Lion str., h.4", address.Line2);

            address.Line1 = "";
            Assert.Null(address.Line1);

            address.Line1 = new string('#', 101);
            address.Line2 = new string('A', 100);
            Assert.Null(address.Line1);
            Assert.Equal(new string('A', 100), address.Line2);

            address.Line1 = null;
            address.Line2 = null;
            Assert.Null(address.Line1);
            Assert.Null(address.Line2);

        }
        
        [Fact]
        public void AddressTypeShouldSave0Or1()
        {
            Assert.Equal(0, (int)address.AddressType);

            Assert.Equal(CustomerLib.Address.EAddressType.Shipping, address.AddressType);

            address.AddressType = (Address.EAddressType)1;
            Assert.Equal(Address.EAddressType.Biling, address.AddressType);

            address.AddressType = (Address.EAddressType)3;
            Assert.Equal(Address.EAddressType.Shipping, address.AddressType);

            address.AddressType = (Address.EAddressType)2;
            Assert.Equal(Address.EAddressType.Shipping, address.AddressType);
        }

        [Fact]
        public void CityShouldSaveNullOrCorrectString()
        {
            Assert.Null(address.City);

            address.City = "21341";
            Assert.Null(address.City);

            address.City = "City-17";
            Assert.Null(address.City);

            address.City = "     ";
            Assert.Null(address.City);

            address.City = new string('A', 51);
            Assert.Null(address.City);

            address.City = "Gran-Soren";
            Assert.Equal("Gran-Soren", address.City);

            address.City = "Gran Soren";
            Assert.Equal("Gran Soren", address.City);

            address.City = new string('A', 50);
            Assert.Equal(new string('A', 50), address.City);

            address.City = null;
            Assert.Null(address.City);

        }

        [Fact]
        public void PostalCodeShouldSaveNullOrCorrectString()
        {
            Assert.Null(address.PostalCode);

            address.PostalCode = "";
            Assert.Null(address.PostalCode);

            address.PostalCode = " ";
            Assert.Null(address.PostalCode);

            address.PostalCode = "dsdfdf";
            Assert.Null(address.PostalCode);

            address.PostalCode = "1231231";
            Assert.Null(address.PostalCode);
            
            address.PostalCode = "123123";
            Assert.Equal("123123", address.PostalCode);

            address.PostalCode = null;
            Assert.Null(address.PostalCode);
        }

        [Fact]
        public void StateShouldSaveNullOrCorrectString()
        {
            Assert.Null(address.State);

            address.State = "";
            Assert.Null(address.State);

            address.State = " ";
            Assert.Null(address.State);

            address.State = "1231231";
            Assert.Null(address.State);

            address.State = "Alabama1";
            Assert.Null(address.State);

            address.State = "Alabama";
            Assert.Equal("Alabama", address.State);
            
            address.State = new string('A', 21);
            Assert.Null(address.State);

            address.State = new string('A', 20);
            Assert.Equal(new string('A', 20), address.State);

            address.State = null;
            Assert.Null(address.State);
        }

        [Fact]
        public void CountryShouldSaveNullOrCorrectString()
        {
            Assert.Null(address.Country);

            address.Country = "Nigeria";
            Assert.Null(address.Country);

            address.Country = " ";
            Assert.Null(address.Country);

            address.Country = "12";
            Assert.Null(address.Country);

            address.Country = "United States";
            Assert.Equal("United States", address.Country);

            address.Country = null;
            Assert.Null(address.Country);

            address.Country = "Canada";
            Assert.Equal("Canada", address.Country);
        }

        [Fact]
        public void AddressValidatorShouldReturnCorrectListOfErrors()
        {
            Address address1 = new Address("Line str.", 1, "Ahoya", "234432", "undefined", "United States");
            List<string> errors1 = new List<string>();

            Assert.Equal(errors1, address1.AddressValidator());

            address1.Line1 = "";
            errors1.Add("Line1");
            Assert.Equal(errors1, address1.AddressValidator());

            address1.City = "";
            errors1.Add("City");
            Assert.Equal(errors1, address1.AddressValidator());

            address1.PostalCode = "dfefed";
            errors1.Add("PostalCode");
            Assert.Equal(errors1, address1.AddressValidator());

            address1.State = "";
            errors1.Add("State");
            Assert.Equal(errors1, address1.AddressValidator());

            address1.Country = "";
            errors1.Add("Country");
            Assert.Equal(errors1, address1.AddressValidator());
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
}
