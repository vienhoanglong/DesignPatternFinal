using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiRapPhim.Patterns.Proxy
{
    public interface UserService
    {
        void loadBanVe();
        void loadBanQuanLy();
    }
    public class UserServiceImpl : UserService
    {
        private String name;

        public UserServiceImpl(String name)
        {
            this.name = name;
        }

        public void loadBanVe()
        {
            Console.WriteLine("Quan ly ban ve loaded");
        }
        public void loadBanQuanLy()
        {
            Console.WriteLine("Ban quan ly loaded");
        }
    }
    
}
