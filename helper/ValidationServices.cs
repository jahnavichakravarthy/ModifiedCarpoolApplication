using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CarpoolApplication.helper
{
    class ValidationServices
    {
       
        public bool Datetime(string Date)
        {
            string strRegex = @"([0-9])([0-9])?(/)([0-9])([0-9])?(/)(\d{4})?(\s)?([0-9])([0-9])?(:)([0-9])([0-9])";
            // string strRegex = @"(^[0-9]{3}" + "(\/)" + "[0-9]{2}" + "(\/)" + "[0-9]{4}$)";
            Regex re = new Regex(strRegex);

            if (re.IsMatch(Date))
            {
                return (true);
            }
            else
            {
                return (false);
            }

        }
        public bool Id(string name)
        {
            string strRegex = @"(^[a-z]{3}" + "[0-9]{2}$)|(^[a-z]{2}" + "[0-9]{3}$)|(^[a-z]{1}" + "[0-9]{4}$)";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(name))
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
        public bool Time(string time)
        {

            string strRegex = @"([0-9])([0-9])?(:)([0-9])([0-9])";
            Regex re = new Regex(strRegex);

            if (re.IsMatch(time))
            {
                return (true);
            }
            else
            {
                return (false);
            }

        }
        public bool Phone(string time)
        {

            string strRegex = @"(^[0-9]{10}$)";
            Regex re = new Regex(strRegex);

            if (re.IsMatch(time))
            {
                return (true);
            }
            else
            {
                return (false);
            }

        }
    }
}
