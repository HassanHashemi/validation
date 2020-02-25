using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace System
{
    public static class Guard
    {
        public static void MinLength(string source, int minLength, string paramName)
        {
            if (source.Length < minLength)
            {
                throw new ArgumentException($"Input {paramName} can not have a length less than {minLength}.");
            }
        }

        public static void MaxLength(string source, int maxLength, string paramName)
        {
            if (source.Length > maxLength)
            {
                throw new ArgumentException($"Input {paramName} can not have a length more than {maxLength}.");
            }
        }

        public static void Positive(int source, string name)
        {
            Positive((long)source, name);
        }

        public static void Positive(long source, string name)
        {
            if (source <= 0)
            {
                throw new ArgumentException($"{name} must be greater than 0");
            }
        }

        public static void Positive(double source, string name)
        {
            if (source <= 0)
            {
                throw new ArgumentException($"{name} must be greater than 0");
            }
        }

        public static void ContainsElement<T>(this IEnumerable<T> source, string name)
        {
            if (source == null || !source.Any())
            {
                throw new ArgumentException($"{ name } dose not contains any element.");
            }
        }

        public static void NotNullOrEmpty(string source, string name)
        {
            NotNull(source, name);
            NotEmpty(source, name);
        }

        public static void NotNullOrDefault(int? source, string name)
        {
            if (source == null || source == 0)
            {
                throw new ArgumentNullException(name);
            }
        }

        public static void NotNullOrDefault(long? source, string name)
        {
            if (source == null || source == 0)
            {
                throw new ArgumentNullException(name);
            }
        }

        public static void NotNullOrDefault(Guid? source, string name)
        {
            if (source == null || source == Guid.Empty)
            {
                throw new ArgumentNullException(name);
            }
        }

        public static void NotNullOrDefault(DateTime? source, string name)
        {
            if (source == null || source == default(DateTime))
            {
                throw new ArgumentNullException(name);
            }
        }

        public static void NotNull(object source, string name)
        {
            if (source == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        public static void NotEmpty(string source, string name)
        {
            if (source == string.Empty)
            {
                throw new ArgumentNullException(name);
            }
        }
        public static void NotEmpty(Guid source, string name)
        {
            if (source == Guid.Empty)
            {
                throw new ArgumentNullException(name);
            }
        }

        public static void ValidPersian(string source, string name)
        {
            NotNullOrEmpty(source, name);

            var isValid = Match(source, @"^([\u0600-\u06FF]+\s?)+$");
            if (!isValid)
            {
                throw new ArgumentException(name);
            }
        }

        public static void ValidMobile(string source, string name)
        {
            NotNullOrEmpty(source, name);

            var isValid = Match(source, "09[0-9]{9}");
            if (!isValid)
            {
                throw new ArgumentException(name);
            }
        }

        public static void ValidNumber(string source, string name)
        {
            NotNullOrEmpty(source, name);

            var isValid = Match(source, @"^[0-9]+$");
            if (!isValid)
            {
                throw new ArgumentException(name);
            }
        }

        public static void ValidPhone(string source, string name)
        {

        }

        public static void ValidEmail(string source, string name)
        {
            NotNullOrEmpty(source, name);

            var isValid = Match(source, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (!isValid)
            {
                throw new ArgumentException(name);
            }
        }

        public static void ValidDomain(string source, string name)
        {
            NotNullOrEmpty(source, name);

            var isValid = Match(source, @"(localhost)|(http[s]?:\/\/|[a-z]*\.[a-z]{3}\.[a-z]{2})([a-z]*\.[a-z]{3})|([a-z]*\.[a-z]*\.[a-z]{3}\.[a-z]{2})|([a-z]+\.[a-z]{3})");
            if (!isValid)
            {
                throw new ArgumentException(name);
            }
        }

        public static void IsLargerThan(DateTime source, DateTime second, string name)
        {
            if (source < second)
            {
                throw new ArgumentException(name);
            }
        }

        public static void ValidDate(string source, string name)
        {
            NotNullOrEmpty(source, name);

            var isValid = Match(source, @"^(\d{4})\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$");
            if (!isValid)
            {
                throw new ArgumentException(name);
            }
        }

        public static void ValidNationalCode(string source, string name)
        {
            ValidNumber(source, name);

            var isValid = Match(source, "[0-9]{10}"); //lenght==10
            if (!isValid)
            {
                throw new ArgumentException(name);
            }

            var allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
            isValid = allDigitEqual.Contains(source);
            if (isValid)
            {
                throw new ArgumentException(name);
            }

            var chArray = source.ToCharArray();
            var num1 = Convert.ToInt32(chArray[0].ToString()) * 10;
            var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
            var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
            var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
            var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
            var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
            var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
            var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
            var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
            var lastNumber = Convert.ToInt32(chArray[9].ToString());

            var sum = num1 + num2 + num3 + num4 + num5 + num6 + num7 + num8 + num9;
            var result = sum % 11;

            isValid = (((result < 2) && (lastNumber == result)) || ((result >= 2) && ((11 - result) == lastNumber)));
            if (!isValid)
            {
                throw new ArgumentException(name);
            }
        }

        public static void OnlyAlphaNumeric(string source, string name)
        {
            NotNullOrEmpty(source, name);
            var isValid = Match(source.Trim(), @"^([a-zA-Z0-9\u0600-\u06FF]+\s*)*$", TimeSpan.FromSeconds(1.5));
            if (!isValid)
            {
                throw new ArgumentException(name);
            }
        }

        internal static bool Match(string text, string pattern)
        {
            return Match(text, pattern, TimeSpan.FromSeconds(1.5));
        }

        internal static bool Match(string text, string pattern, TimeSpan timeout)
        {
            try
            {
                return Regex.Match(text, pattern, RegexOptions.None, timeout).Success;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
