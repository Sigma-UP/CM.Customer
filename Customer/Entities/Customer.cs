using System.Collections.Generic;
using StringExtension;
using System.Text.RegularExpressions;

namespace CustomerLib
{
	public class Customer : Person
	{
		private string _name;
		private string _lastName;
		private string _phone;
		private string _email;
		private decimal? _total;
		
		private List<string>  _notes = new List<string>();
		private List<Address> _addresses = new List<Address>();

        #region Constructors.
        //public Customer(string firstName, string lastName, List<Address> /addresses,/ string phone, string email, List<string> notes, object //totalPurchasesAmount)
        //{
		//	FirstName = firstName;
		//	LastName = lastName;
		//	Addresses = addresses;
		//	Phone = phone;
		//	Email = email;
		//	Notes = notes;
		//	TotalPurchasesAmount = totalPurchasesAmount;
		//}
        public Customer()
        {
		}
		#endregion
        #region Getters and setters.
        public override string FirstName 
		{ 
			get { return _name; }
			set 
			{
				if (value != null && value.Length <= 50 && !value.ContainsNumbers() && !value.IsEmpty())
					_name = value;
				else
					_name = null;
			} 
		}
		public override string LastName 
		{ 
			get { return _lastName; } 
			set 
			{
				if (value != null && value.Length <= 50 && !value.ContainsNumbers() && !value.IsEmpty())
					_lastName = value;
				else
					_lastName = null;
			} 
		}
		public string Phone { 
			get => _phone;
			set 
			{
				if (value.IsE164())
					_phone = value;
				else
					_phone = null;
			}
		}
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
						_email = value;
					}
					else
					{
						_email = null;
					}
				}
				else
					_email = null;
			}
		}
		public decimal? TotalPurchasesAmount
		{
			get
			{
				if (_total.HasValue)
					return _total;
				else
					return null;
			}
			set
			{
				if (value != null && value >= 0)
					_total = value;
				else
					_total = null;
			}
		}

		public List<Address> Addresses 
		{ 
			get => _addresses;
			set => _addresses = value;
		}

		public List<string> Notes 
		{ 
			get => _notes;
			set 
			{
				_notes = value;
			} 
		} 
        #endregion
	}
}
