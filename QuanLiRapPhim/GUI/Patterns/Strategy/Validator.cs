using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLiRapPhim.Patterns.Strategy
{
    public interface Validator
    {
        bool Validate(string content);
    }

    public class PhoneValidator : Validator
    {
        public bool Validate(string content)
        {
            //return Regex.Match(content, @"^(\+[0-9]{9})$").Success;
            return int.TryParse(content, out int value) 
                && content.Length >=10 
                && content.Length <= 11 
                && content[0] == '0';
        }
    }
    public class StringValidator : Validator
    {
        public bool Validate(string content)
        {
            return content.Length > 0;
        }
    }

    public class IDValidator : Validator
    {
        public bool Validate(string content)
        {
            return int.TryParse(content, out int value) && content.Length == 9;
        }
    }
    public class YearValidator : Validator
    {
        public bool Validate(string content)
        {
            return int.TryParse(content, out int value) && content.Length == 4 && value > 0;
        }
    }
    public class TimeValidator : Validator
    {
        public bool Validate(string content)
        {
            return int.TryParse(content, out int value) && value > 0;
        }
    }
    public class EmailValidator : Validator
    {
        public bool Validate(string content)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = emailRegex.Match(content);
            if (match.Success)
                return true;
            else
                return false;
        }
    }
    public class DateValidator : Validator
    {
        public bool Validate(string content)
        {
            DateTime temp;
            if (DateTime.TryParse(content, out temp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
