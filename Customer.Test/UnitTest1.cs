using System;
using Xunit;
using System.Collections.Generic;

namespace Customer.Test
{
    public class UnitTest1
    {
        [Fact]
        public void FirstNameValid()
        {
            Customer c = new Customer();
            Assert.Null(c.FirstName);

            c.FirstName = "Stewie";
            Assert.Equal("Stewie", c.FirstName);
            c.FirstName = null;
            Assert.Equal("Stewie", c.FirstName);
            c.FirstName = new string('A', 51);
            Assert.Equal("Stewie", c.FirstName);
            c.FirstName = new string('A', 50);
            Assert.Equal(new string('A', 50), c.FirstName);
        }

        [Fact]
        public void LastNameValid()
        {
            Customer c = new Customer();
            Assert.Null(c.LastName);

            c.LastName = "Griffin";
            Assert.Equal("Griffin", c.LastName);
            c.LastName = null;
            Assert.Equal("Griffin", c.LastName);
            c.LastName = new string('A', 51);
            Assert.Equal("Griffin", c.LastName);
            c.LastName = new string('A', 50);
            Assert.Equal(new string('A', 50), c.LastName);
        }

        //[Fact]
        //public void TotalPurchasesAmountShouldSaveNullAndDecimal()
        //{
        //    Customer c = new Customer() ;
        //    c.TotalPurchasesAmount = 1.2;
        //    Assert.Equal((decimal)1.2, c.TotalPurchasesAmount);
        //    c.TotalPurchasesAmount = null;
        //    Assert.Null(c.TotalPurchasesAmount);
        //}

        //public void ConstructorsWork()
        //{
        //    Customer c1 = new Customer();
        //    Customer c_expected = new Customer(null, null, null, null, null, null, //null);
        //    Assert.Equal(c_expected, c1);
        //
        //    Customer c2 = new Customer("August")
        //}
    }
}
