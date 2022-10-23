using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETSIBKM2_WebApp.Repositories.Data;
using NETSIBKM2_WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETSIBKM2_WebApp.Controllers
{
    public class AccountController : Controller
    {
        AccountRepository accountRepository;

        public AccountController(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Login login)
        {
            //statement mengambil data dari database sesuai dengan email dan password {}
            // return -> Id Employee, FullName, Email, Role -> ViewModels {}
            var data = accountRepository.Login(login);

            if(data !=null)
            {
                //inisialilasi nilai pada session
                HttpContext.Session.SetString("Role", data.Role);
                return RedirectToAction("Index", "Province");
            }
            return View();
        }

        //Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            var data = accountRepository.Register(register);
            if(data > 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
            

        //Change Pasword
        //Forgot Pasword
    }
}
