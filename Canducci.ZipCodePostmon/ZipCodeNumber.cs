using System;
using System.Text.RegularExpressions;
namespace Canducci.ZipCodePostmon
{
    public struct ZipCodeNumber
    {
        public string Value { get; }

        public ZipCodeNumber(string value)
            :this(value, true) { }

        internal ZipCodeNumber(string value, bool valid)
        {            
            if (valid)
            {
                if (!Valid(ref value))
                {
                    throw new FormatException("Format invalid. Example correct: 01.414-000 or 01.414000 or 01414000");
                }
            }
            Value = value;
        }

        public static explicit operator string(ZipCodeNumber number) => number.Value;
        public static explicit operator ZipCodeNumber(string number) => new ZipCodeNumber(number);

        internal static string ClearPointAndTrace(string number) => number.Replace(".", "").Replace("-", "");
        internal static bool IsMatch(string number) => (new Regex(@"^\d{8}$")).IsMatch(number);

        internal static bool Valid(ref string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (value.Length == 8 || value.Length == 9 || value.Length == 10)
            {
                value = ClearPointAndTrace(value);
                return IsMatch(value);
            }
            return false;
        }

        public static bool TryParse(string value, out ZipCodeNumber zipCodeNumber)
        {
            if (Valid(ref value))
            {
                zipCodeNumber = new ZipCodeNumber(value, false);
                return true;
            }
            zipCodeNumber = default(ZipCodeNumber);            
            return false;
        }
    }
}
