using StringExtension;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Entity
{

	public class Address
	{
		private string _line1;
		private string _line2;
		private string _city;
		private string _postalCode;
		private string _state;
		private string _country;

		public Address()
		{

		}


		public Address(string line1, int addressType, string city, string postalCode, string state, string country, string line2 = null)
		{
			Line1 = line1;
			Line2 = line2;
			AddressType = (EAddressType)addressType;
			City = city;
			PostalCode = postalCode;
			State = state;
			Country = country;
		}

		public string Line1 { get => _line1; set => _line1 = value; }
		public string Line2 { get => _line2; set => _line2 = value; }
		public EAddressType AddressType
		{
			get => AddressType;
			set
			{
				switch (value)
				{
					case EAddressType.Shipping:
						AddressType = EAddressType.Shipping;
						break;
					case EAddressType.Biling:
						AddressType = EAddressType.Biling;
						break;
					default:
						AddressType = EAddressType.Shipping;
						break;
				}
			}
		}
		public string City { get => _city; set => _city = value; }
		public string PostalCode { get => _postalCode; set => _postalCode = value; }
		public string State { get => _state; set => _state = value; }
		public string Country { get => _country; set => _country = value; } // r, (USA or Canada)

		public List<string> AddressValidator()
		{
			List<string> errors = null;
			if (Line1 == null)
				errors.Add(AddressErrors.Line1IsNull.ToString());
			else if (Line1.isEmpty())
				errors.Add(AddressErrors.Line1IsEmpty.ToString());

			if (City == null)
				errors.Add(AddressErrors.CityIsNull.ToString());
			else if (City.isEmpty())
				errors.Add(AddressErrors.CityIsEmpty.ToString());
			else if (!City.isLetter())
				errors.Add(AddressErrors.CityContainNum.ToString());

			if (PostalCode == null)
				errors.Add(AddressErrors.PostalCodeIsNull.ToString());
			else if (PostalCode.isEmpty())
				errors.Add(AddressErrors.PostalCodeIsEmpty.ToString());
			else if (!PostalCode.isNumber())
				errors.Add(AddressErrors.PostalCodeContainLetter.ToString());

			if (State == null)
				errors.Add(AddressErrors.StateIsNull.ToString());
			if (State.isEmpty())
				errors.Add(AddressErrors.StateIsEmpty.ToString());
			if (!State.isLetter())
				errors.Add(AddressErrors.StateContainNum.ToString());

			if (Country == null)
				errors.Add(AddressErrors.CountryIsNull.ToString());
			if (Country.isEmpty())
				errors.Add(AddressErrors.CountryIsEmpty.ToString());
			else if (Country != "United States" && State != "Canada")
				errors.Add(AddressErrors.CountryUnexpectedVal.ToString());


			return errors;
		}
		public enum EAddressType
		{
			Shipping,
			Biling
		}
	}
}
