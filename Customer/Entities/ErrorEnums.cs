using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerLib
{

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
