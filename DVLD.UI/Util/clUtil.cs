using System.Text.RegularExpressions;

namespace DVLD.UI.Util
{
    public static class clUtil
    {
       public static bool IsValidEmail(string Email)
        {
            return Regex.IsMatch(Email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        }
    }
}
