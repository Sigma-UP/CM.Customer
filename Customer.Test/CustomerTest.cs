using Xunit;
using System.Collections.Generic;


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
            _c.TotalPurchasesAmount = -24.4;
            Assert.Null(_c.TotalPurchasesAmount);

            _c.TotalPurchasesAmount = 0.0;
            Assert.Equal((decimal)0.0, _c.TotalPurchasesAmount);

            _c.TotalPurchasesAmount = 1.2;
            Assert.Equal((decimal)1.2 ,_c.TotalPurchasesAmount);
        
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
