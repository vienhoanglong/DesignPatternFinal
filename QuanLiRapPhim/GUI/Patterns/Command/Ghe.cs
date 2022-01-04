using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiRapPhim.Patterns.Command
{
    class Seat
    {
        
        Button button;
        public Seat(Button button)
        {
            this.button = button;
        }
        public void on()
        {
            {
                button.BackColor = Color.Black;
                button.ForeColor = Color.White;
                Console.WriteLine(button.Text+" is on !!");
            }
        }
        public void off()
        {
            {
                button.BackColor = Color.White;
                button.ForeColor = Color.Black;
                Console.WriteLine(button.Text + " is off !!");
            }
        }
    }
}
