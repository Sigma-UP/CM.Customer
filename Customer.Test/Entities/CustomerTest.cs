using Xunit;
using System.Collections.Generic;

namespace CustomerLib.Test.Entities
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
}
