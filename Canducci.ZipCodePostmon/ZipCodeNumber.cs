namespace Canducci.ZipCodePostmon
{
    public struct ZipCodeNumber
    {
        public string Number { get; set; }

        public ZipCodeNumber(string number)
            :this(number, true) { }

        internal ZipCodeNumber(string number, bool valid)
        {            
            if (valid)
            {
                if (!Valid(ref number))
                {
                    throw new System.FormatException("Format invalid. Example correct: 01.414-000 or 01.414000 or 01414000");
                }
            }
            Number = number;
        }

        public static explicit operator string(ZipCodeNumber zipCodeNumber) => zipCodeNumber.Number;
        public static explicit operator ZipCodeNumber(string number) => new ZipCodeNumber(number);

        internal static bool Valid(ref string zip)
        {
            if (zip.Length == 8 || zip.Length == 9 || zip.Length == 10)
            {
                zip = zip.Replace(".", "").Replace("-", "");
                System.Text.RegularExpressions.Regex RegexZip =
                    new System.Text.RegularExpressions.Regex(@"^\d{8}$");
                if (RegexZip.IsMatch(zip))
                {
                    RegexZip = null;
                    return true;
                }
                RegexZip = null;
            }
            return false;
        }

        public static bool TryParse(string number, out ZipCodeNumber zipCodeNumber)
        {
            if (Valid(ref number))
            {
                zipCodeNumber = new ZipCodeNumber(number, false);
                return true;
            }
            zipCodeNumber = default(ZipCodeNumber);            
            return false;
        }
    }
}
