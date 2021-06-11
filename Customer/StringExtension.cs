using System;

namespace StringExtension
{
	public static class StringExtension
	{
		public static bool IsE164(this string str)
        {
			if (str == null || str == "" || str[0] != '+' || str.Length > 16)
				return false;
			
			for (int i = 1; i < str.Length; i++)
				if (!Char.IsDigit(str[i]))
					return false;
				return true;
		}
		public static bool IsEmpty(this string str)
        {
			for(int i = 0; i < str.Length; i++)
				if (str[i] != ' ')
					return false;
			return true;
        }
		public static bool ContainsNumbers(this string str)
        {
			for (int i = 0; i < str.Length; i++)
				if (Char.IsNumber(str[i]))
					return true;

			return false;
		}
	}
}
