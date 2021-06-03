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
        [Fact]
        public void NewAddressShouldSaveCorrectData()
        {
            Address address = new Address("B.Herrington str.", 1, "Zhma", "121782", "Juna", "United States");
            c.Addresses = new List<Address>();
            c.Addresses.Add(address);
            Assert.Equal("B.Herrington str.", c.Addresses[0].Line1);
            Assert.Equal("Zhma", c.Addresses[0].City);

            address.Line1 = "";
            c.Addresses.Add(address);
            Assert.Null(c.Addresses[1].Line1);
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

        [Fact]
        public void CustomerValidatorShouldReturnCorrectListOfErrors()
        {
                List<string> err  = new List<string>();
                Customer c2 = new Customer();

            c2.Addresses.Add(new Address("11", 1, "City", "232322", "State", "United States", "Line2_optional"));
            c2.Addresses.Add(new Address(null, 1, "City", "232322", "State", "United States", null));
            c2.Addresses.Add(new Address("dfr", 1, "", "232322", "State", "United States", null));
            c2.Notes = null;
            err.Add("LastName");
            err.Add("Address_1");
            err.Add("Address_2");
            err.Add("Notes");
            Assert.Equal(err, c2.CustomerValidator());
            
            c2 = new Customer();
            err = new List<string>();
            c2.LastName = "LastName";
            c2.Addresses = null;
            c2.Notes.Add("Note0");
            c2.Notes.Add("   ");
            c2.Notes.Add(null);
            err.Add("Addresses");
            err.Add("Note_1");
            err.Add("Note_2");
            Assert.Equal(err, c2.CustomerValidator());

            c2 = new Customer();
            err = null;
            c2.LastName = "LastName";
            c2.Addresses.Add(new Address("11", 1, "City", "232322", "State", "United States", "Line2_optional"));
            c2.Notes.Add("Note0");
            Assert.Equal(err, c2.CustomerValidator());
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

            Assert.Equal(Address.EAddressType.Shipping, address.AddressType);

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
            List<Address> addresses = new List<Address>();
            addresses.Add(new Address("11", 1, "City", "232322", "State", "United States", "Line2_optional"));
            addresses.Add(new Address(null, 1, "City", "232322", "State", "United States", null));
            addresses.Add(new Address("11", 1, null, "232322", "State", "United States", "Line2_optional"));
            addresses.Add(new Address("12", 2, "City", null, "State", "United States", null));
            addresses.Add(new Address("12", 2, "City", "232322", null, "United States", null));
            addresses.Add(new Address("12", 2, "City", "232322", "State", null, null));

            List<string> errors1 = null;
            Assert.Equal(errors1, addresses[0].AddressValidator());

            errors1 = new List<string>(); 
            errors1.Add("Line1");
            Assert.Equal(errors1, addresses[1].AddressValidator());

            errors1[0] = "City";
            Assert.Equal(errors1, addresses[2].AddressValidator());

            errors1[0] = "PostalCode";
            Assert.Equal(errors1, addresses[3].AddressValidator());

            errors1[0] = "State";
            Assert.Equal(errors1, addresses[4].AddressValidator());

            errors1[0] = "Country";
            Assert.Equal(errors1, addresses[5].AddressValidator());
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
