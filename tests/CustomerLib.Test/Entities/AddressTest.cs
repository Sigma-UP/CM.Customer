using CustomerLib.Entities;
using Xunit;
namespace CustomerLib.Test.Entities
{
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
        public void GetAddressTypeAsStringShouldReturnStringShipping()
        {
            Assert.Equal(0, (int)_address.AddressType);

            Assert.Equal("Shipping", _address.GetAddressTypeAsString());

            _address.AddressType = (Address.EAddressType)1;
            Assert.Equal("Billing", _address.GetAddressTypeAsString());
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
            Address a = new Address(){
                Line1 = "LINE1", 
                AddressType = Address.EAddressType.Biling,
                City = "CITY",
                PostalCode = "212121",
                State = "STATE",
                Country = "Canada" 
            };
            Assert.Equal("LINE1", a.Line1);
            Assert.Equal(Address.EAddressType.Biling, a.AddressType);
            Assert.Equal("CITY", a.City);
            Assert.Equal("212121", a.PostalCode);
            Assert.Equal("STATE", a.State);
            Assert.Equal("Canada", a.Country);
        }
        [Fact]
        public void ShouldSaveAddressID()
        {
            _address.AddressID = 1;
            Assert.Equal(1, _address.AddressID);
        }
        [Fact]
        public void ShouldSaveCustomerID()
        {
            _address.CustomerID = 1;
            Assert.Equal(1, _address.CustomerID);
        }
    }
}
