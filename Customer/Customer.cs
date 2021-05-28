using System;
using System.Collections.Generic;
using StringExtension;
using System.Text.RegularExpressions;
/// <summary>
/// Comment:
/// *r [size] - required field
/// *o [size] - optional field
/// </summary>

namespace Customer
{
	public abstract class Person
	{
		public abstract string FirstName { get; set; } //o, 50
		public abstract string LastName { get; set; }  //r, 50
	}

	public class Address
	{
		private string _line1 = "none";
		private string _line2 = "none";
		private string _city = "none";
		private string _postalCode = "none";
		private string _state = "none";
		private string _country = "none"; 

		public Address()
        {
		}
		Address(string line1, int addressType, string city, string postalCode, string state, string country, string line2 = null)
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
	}
	public enum AddressErrors
        {
			Line1IsNull = 11,
			Line1IsEmpty = 12,

			CityIsNull = 21,
			CityIsEmpty = 22,
			CityContainNum = 23,

			PostalCodeIsNull = 31,
			PostalCodeIsEmpty = 32,
			PostalCodeContainLetter = 33,

			StateIsNull = 41,
			StateIsEmpty = 42,
			StateContainNum = 43,

			CountryIsNull = 51,
			CountryIsEmpty = 52,
			CountryUnexpectedVal = 53
		}
	public enum EAddressType
		{
			Shipping,
			Biling
		}

	public class Customer : Person
	{
        public Customer(string firstName, string lastName, List<Address> addresses, string phone, string email, List<string> notes, object totalPurchasesAmount)
        {
			FirstName = firstName;
			LastName = lastName;
			Addresses = addresses;
			Phone = phone;
			Email = email;
			Notes = notes;
			TotalPurchasesAmount = totalPurchasesAmount;
		}
        public Customer()
        {
			//FirstName = "";
			//LastName =	"h";
			//Addresses.Add(new Address());
			//Notes.Add(new string("empty")) ;
			//Phone =		"";
			//Email =		"";
			//Notes =		null;
			//TotalPurchasesAmount = "";
		}
		string _name;
		string _lastName;
		List<Address> _addresses;
		string _phone;
		string _email;
		List<string> _notes;
		object _total;
		public override string FirstName 
		{ 
			get { return _name; }
			set 
			{
				if (value!=null && value.Length <= 50)
					 _name = value;
			} 
		}
		public override string LastName 
		{ 
			get { return _lastName; } 
			set 
			{
				if (value != null && value.Length <= 50)
					_lastName = value;
			} 
		}
		public List<Address> Addresses 
		{ 
			get => _addresses; 
			set => _addresses = value; 
		}//r, >=1 item
		public string Phone { 
			get => _phone; set => _phone = value; 
		} // o, E.164
		public string Email {
			get => _email;
			set
			{
				if (value != null)
				{
					string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
				  @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

					if (Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
					{
						Console.WriteLine("Email accepted.");
						_email = value;
					}
					else
					{
						Console.WriteLine("Email denied.");
						_email = null;
					}
				}
			}
		} //o, Regex
		public List<string> Notes 
		{ 
			get => _notes; 
			set => _notes = value; 
		} //r, >=1 item
		public object TotalPurchasesAmount {
			get
			{
				return (decimal?)_total;
			}
			set 
			{
				if (!(value == null))
					_total = value;
				else
					_total = null;
			} 
		}

		public List<string> CustomerValidator()
		{
			//(a1.SequenceEqual(a2))
			List<string> errors = null;
			if (LastName == null)
				errors.Add(CustomerErrors.LastNameIsNull.ToString());
			else if (LastName.isEmpty())
				errors.Add(CustomerErrors.LastNameIsEmpty.ToString());
			else if (!LastName.isLetter())
				errors.Add(CustomerErrors.LastNameContainNum.ToString());

			if (Addresses.Count == 0)
				errors.Add(CustomerErrors.AddressesListIsEmpty.ToString());
			else 
				for(int i = 0; i < Addresses.Count; i++)
					if (Addresses[i].AddressValidator() != null)
						errors.Add(CustomerErrors.AddressInvalid + $"-{i}");
				

			if(Notes.Count == 0)
				errors.Add(CustomerErrors.AddressesListIsEmpty.ToString());
			
			return errors;
		}
		private enum CustomerErrors
		{
			//Last Name Errors
			LastNameIsNull = 11,
			LastNameIsEmpty = 12,
			LastNameContainNum = 13,
			//Addresses Errors
			AddressesListIsEmpty = 21,
			AddressInvalid = 22,
			//Notes Errors
			NotesListIsEmpty = 31,
		}

	}
}
