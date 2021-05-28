using System;
using Xunit;
using System.Collections.Generic;
namespace Customer.Test
{
    public class CustomerTest
    {

        Customer.Entity.Customer c = new Customer.Entity.Customer();
        
        [Fact]
        public void FirstNameValid()
        {
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
            //Customer.Entity.Customer c = new Customer.Entity.Customer();
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

        [Fact]
        public void TotalPurchasesAmountShouldSaveNullAndDecimal()
        {
            //Customer.Entity.Customer c = new Customer.Entity.Customer() ;
            c.TotalPurchasesAmount = null;
            Assert.Null(c.TotalPurchasesAmount);
            c.TotalPurchasesAmount = 1.2;
            Assert.Equal((decimal)1.2 ,c.TotalPurchasesAmount);
        }
    }
}
