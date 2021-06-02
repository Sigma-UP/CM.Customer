using System;

namespace StringExtension
{
	public static class StringExtension
	{
		public static bool isNumber(this string str)
		{
			int varriable;
			return int.TryParse(str, out varriable);
		}

		public static bool isE164(this string str)
        {
			if (str == null || str == "" || str[0] != '+' || str.Length > 16)
				return false;
			
			for (int i = 1; i < str.Length; i++)
				if (!Char.IsDigit(str[i]))
					return false;
				return true;
		}

		public static bool isEmpty(this string str)
        {
			for(int i = 0; i < str.Length; i++)
				if (str[i] != ' ')
					return false;
			return true;
        }

		public static bool isLetter(this string str)
		{
			for (int i = 0; i < str.Length; i++)
				if (!Char.IsLetter(str[i]))
					return false;

			return true;
		}

		public static bool isUpper(this string str)
		{
			for (int i = 0; i < str.Length; i++)
				if (!Char.IsUpper(str[i]))
					return false;

			return true;
		}

		public static bool containsNumbers(this string str)
        {
			for (int i = 0; i < str.Length; i++)
				if (Char.IsNumber(str[i]))
					return true;

			return false;
		}
	}
}
