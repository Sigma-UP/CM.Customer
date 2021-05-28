using System;
using System.Collections.Generic;
using StringExtension;
using System.Text.RegularExpressions;
/// <summary>
/// Comment:
/// *r [size] - required field
/// *o [size] - optional field
/// </summary>

namespace Customer.Entity
{
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
			Addresses.Add(new Address());
			Notes.Add(new string("empty")) ;
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
	}
}
