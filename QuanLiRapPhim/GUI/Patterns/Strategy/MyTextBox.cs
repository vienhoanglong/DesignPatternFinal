using QuanLiRapPhim.Patterns.Factory;
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
        public ValidatorType validateType { get; set; }
        public Validator Validator;
        public MyTextBox()
        {
            InitializeComponent();
        }

        public void setValidator(ValidatorType validateType)
        {
            Validator = ValidatorFactory.CreateValidator(validateType);
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
