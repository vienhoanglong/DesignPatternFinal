using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiRapPhim.Patterns.Command
{
    abstract class ICommand
    {
        
        public abstract void executeOn();
        public abstract void executeOff();
        public void on()
        {
            
            executeOn();
        }
        public void off()
        {
            
            executeOff();
        }
        
    }
    class SeatCommand : ICommand
    {
        Seat seat;
        public SeatCommand(Seat seat) : base()
        {
            this.seat = seat;
        }
        public override void executeOn()
        {
            seat.on();
        }
        public override void executeOff()
        {
            seat.off();
        }
    }
}
