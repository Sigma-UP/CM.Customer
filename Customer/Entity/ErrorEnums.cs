using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Entity
{
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

	public enum CustomerErrors
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
