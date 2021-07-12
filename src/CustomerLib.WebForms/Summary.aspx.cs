using System;
using CustomerLib.Entities;
using CustomerLib.Data.EF;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerLib.WebForms
{
    public partial class CustomerList : System.Web.UI.Page
    {
        public List<Customer> Customers { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Customers = new EFCustomerRepository().ReadAllCustomers();
        }
    } 
}