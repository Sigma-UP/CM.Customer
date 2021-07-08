using CustomerLib.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace CustomerLib.Entities
{
	[Serializable]
	public class Address
	{
		[Key, Column(Order = 0)]
		private int _addressID;
		[Key, Column(Order = 1)]
		private int _customerID;
		private string _line1;
		private string _line2;
		private string _addressType;
		private string _city;
		private string _postalCode;
		private string _state;
		private string _country;

		public Address()
		{
		}
		#region Getters and Setters.
		public int CustomerID
		{
			get => _customerID; 
			set => _customerID = value; 
		}
		public int AddressID 
		{ 
			get => _addressID; 
			set => _addressID = value; 
		}
		public string Line1 { 
			get => _line1;
			set 
			{
				if (value != null && value.Length <= 100 && !value.IsEmpty())
					_line1 = value;
				else
					_line1 = null;
			} 
		}
		public string Line2 {
			get => _line2;
			set
			{
				if (value != null && value.Length <= 100 && !value.IsEmpty())
					_line2 = value;
				else
					_line2 = null;
			}
		}
		public string AddressType
		{
			get => _addressType;
			set
			{
				if (value == "Billing" || value == "Shipping")
					_addressType = value;
				else
					_addressType = "Billing";
			}
		}
		public string City 
		{
			get => _city;
			set
			{
				if (value != null && value.Length <= 50 && !value.IsEmpty() && !value.ContainsNumber())
					_city = value;
				else
					_city = null;
			}
		}
		public string PostalCode 
		{
			get => _postalCode;
			set
			{
				if (value != null && value.Length <= 6 && value.ContainsNumber())
					_postalCode = value;
				else
					_postalCode = null;
			}
		}
		public string State 
		{
			get => _state;
			set
			{
				if (value != null && value.Length <= 20 && !value.IsEmpty() && !value.ContainsNumber())
					_state = value;
				else
					_state = null;
			}
		}
		public string Country
		{
			get => _country;

			set
			{
				if (value == "United States" || value == "Canada")
					_country = value;
				else
					_country = null;
			}
		}
        #endregion
		public enum EAddressType
		{
			Shipping,
			Biling
		}
	}
}
