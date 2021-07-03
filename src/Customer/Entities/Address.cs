using StringExtension;
using System.Collections.Generic;

namespace CustomerLib
{
	public class Address
	{
		private string _line1;
		private string _line2;
		private EAddressType _addressType;
		private string _city;
		private string _postalCode;
		private string _state;
		private string _country;

		public Address()
		{
		}


		public Address(string line1, int addressType, string city, string postalCode, string state, string country, string line2 = "")
		{
			Line1 = line1;
			Line2 = line2;
			AddressType = (EAddressType)addressType;
			City = city;
			PostalCode = postalCode;
			State = state;
			Country = country;
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
		public EAddressType AddressType
		{
			get => _addressType;
			set
			{
				switch ((int)value)
				{
					case 0:
						_addressType = EAddressType.Shipping;
						break;
					case 1:
						_addressType = EAddressType.Biling;
						break;
					default:
						AddressType = EAddressType.Shipping;
						break;
				}
			}
		}
		public string City 
		{
			get => _city;
			set
			{
				if (value != null && value.Length <= 50 && !value.IsEmpty() && !value.ContainsNumbers())
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
				if (value != null && value.Length <= 6 && value.ContainsNumbers())
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
				if (value != null && value.Length <= 20 && !value.IsEmpty() && !value.ContainsNumbers())
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

		public string GetAddressTypeAsString() =>
			AddressType == 0 ? "Shipping" : "Billing";
 

		/*
		public List<string> AddressValidator()
		{
			//try something to use cycles
			List<string> errors = new List<string>();


			if (Line1 == null)		errors.Add("Line1");
			if (City == null)		errors.Add("City");
			if (PostalCode == null) errors.Add("PostalCode");
			if (State == null)		errors.Add("State");
			if (Country == null)	errors.Add("Country");
			
			if(errors.Count==0)	return null;
			return errors;
		}
		*/
		public enum EAddressType
		{
			Shipping,
			Biling
		}

	}
}
