using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiRapPhim.Patterns.Proxy
{
    class UserServiceProxy : UserService
    {
        private String role;
        private UserService userService;

        public UserServiceProxy(String name, String role)
        {
            this.role = role;
            userService = new UserServiceImpl(name);
        }
        public void loadBanVe()
        {
            userService.loadBanVe();
        }
        public void loadBanQuanLy()
        {
            if (isAdmin())
            {
                userService.loadBanQuanLy();
            }
            else
            {
                throw new Exception("Access denied");
            }
        }
        private bool isAdmin()
        {
            return this.role == "admin";
        }
    }
}
