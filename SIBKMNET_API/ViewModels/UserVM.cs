using SIBKMNET_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_API.ViewModels
{
    public class UserVM
    {
        public int Id { get; set; }
        public string Password { get;  set; }
        public Employee Employee { get; set; }
    }
}
