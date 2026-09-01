using System.Text.RegularExpressions;

namespace DVLD.UI.Util
{
    public static class clUtil
    {
       public static bool IsValidEmail(string Email)
        {
            return Regex.IsMatch(Email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        }

        public static bool IsValidMoney(string Money)
        {
            return Regex.IsMatch(Money, @"^[0-9]+(\.[0-9]{1,2})?$");
        }
    }
}
