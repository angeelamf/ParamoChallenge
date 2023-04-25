using System;
using System.Net.Mail;

namespace Sat.Recruitment.Api.Utilities
{
    public static class StringExtensions
    {
        public static bool ValidateEmail(this string val)
        {
            if (val == null)
                return false;

            try
            {
                MailAddress m = new MailAddress(val);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }

        }
    }
}
