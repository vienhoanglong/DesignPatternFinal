using QuanLiRapPhim.Patterns.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiRapPhim.Patterns.Factory
{
    public enum ValidatorType
    {
        PHONE,
        ID,
        YEAR,
        STRING,
        TIME,
        DATE,
        EMAIL
    }
    class ValidatorFactory
    {
        public static Validator CreateValidator(ValidatorType type)
        {
            Validator validator = null;
            switch (type)
            {
                case ValidatorType.EMAIL:
                    validator = new EmailValidator();
                    break;
                case ValidatorType.PHONE:
                    validator = new PhoneValidator();
                    break;
                case ValidatorType.ID:
                    validator = new IDValidator();
                    break;
                case ValidatorType.YEAR:
                    validator = new YearValidator();
                    break;
                case ValidatorType.STRING:
                    validator = new StringValidator();
                    break;
                case ValidatorType.TIME:
                    validator = new TimeValidator();
                    break;
                case ValidatorType.DATE:
                    validator = new DateValidator();
                    break;
            }
            return validator;
        }

    }
}
