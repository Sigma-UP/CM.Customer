using CustomerLib.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace CustomerLib.Entities
{
	[Serializable]
    public class Note
    {
		[Key, Column(Order = 1)]
		private int _customerID;
		[Key, Column(Order = 0)]
		private int _noteID;
		private string _note;

		public int CustomerID
		{
			get => _customerID;
			set => _customerID = value;
		}
		public int NoteID
		{
			get => _noteID;
			set => _noteID = value;
		}
		public string Line
		{
			get => _note;
			set
			{
				if (!value.IsEmpty())
					_note = value;
			}
		}
	}
}
