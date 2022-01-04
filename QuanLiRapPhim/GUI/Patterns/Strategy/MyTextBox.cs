using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiRapPhim.Patterns.Strategy
{
    public partial class MyTextBox : TextBox
    {
        public string ValidateType { get; set; }
        public Validator Validator;
        public MyTextBox()
        {
            InitializeComponent();
        }

        public void setValidator()
        {
            if (ValidateType.ToUpper() == "PHONE")
                Validator = new PhoneValidator();
            else if (ValidateType.ToUpper() == "ID")
                Validator = new IDValidator();
            else if (ValidateType.ToUpper() == "YEAR")
                Validator = new YearValidator();
            else if (ValidateType.ToUpper() == "STRING")
                Validator = new StringValidator();
            else if (ValidateType.ToUpper() == "TIME")
                Validator = new TimeValidator();
            else if (ValidateType.ToUpper() == "DATE")
                Validator = new DateValidator();
            else if (ValidateType.ToUpper() == "EMAIL")
                Validator = new EmailValidator();
        }

        public bool Validate(string content)
        {
            if (Validator.Validate(content))
                return true;
            else
                return false;
        }
    }
}
