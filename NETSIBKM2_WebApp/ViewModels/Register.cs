using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETSIBKM2_WebApp.ViewModels
{
    public class Register
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; } = 2;
    }
}
