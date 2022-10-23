using Microsoft.EntityFrameworkCore;
using NETSIBKM2_WebApp.Context;
using NETSIBKM2_WebApp.Handler;
using NETSIBKM2_WebApp.Models;
using NETSIBKM2_WebApp.ViewModels;
using System;
using System.Linq;

namespace NETSIBKM2_WebApp.Repositories.Data
{
    public class AccountRepository
    {
        MyContext myContext;
        //Hashing hashing;

        public AccountRepository(MyContext myContext /* Hashing hashing*/)
        {
            this.myContext = myContext;
            //this.hashing = hashing;
        }

        public Responselogin Login(Login login)
        {

            var data = myContext.UserRoles
                .Include(x => x.Role)
                .Include(x => x.User)
                .Include(x => x.User.Employee)
                .FirstOrDefault(x => x.User.Employee.Email.Equals(login.Email));
            var verify = Hashing.ValidatePassword(login.Password, data.User.Password);
            if (verify)
            {
                var response = new Responselogin()
                {
                    Id = data.User.Employee.Id,
                    Fullname = data.User.Employee.FullName,
                    Email = data.User.Employee.Email,
                    Role = data.Role.Name
                };
                return response;
            }
            return null;
        }

        //Register
        public int Register(Register register)
        {
            Employee employee = new Employee()
            {
                FullName = register.FullName,
                Email = register.Email
            };
            myContext.Employees.Add(employee);
            var resultEmployee = myContext.SaveChanges();
            if (resultEmployee > 0)
            {
                int id = myContext.Employees.SingleOrDefault(x => x.Email.Equals(register.Email)).Id;
                User user = new User()
                {
                    Id = id,
                    Password = Hashing.HashPassword(register.Password)
                };
                myContext.Users.Add(user);
                var resulUser = myContext.SaveChanges();
                if (resulUser > 0)
                {
                    UserRole userRole = new UserRole()
                    {
                        UserId = id,
                        RoleId = register.RoleId
                    };
                    myContext.UserRoles.Add(userRole);
                    var resulUserRole = myContext.SaveChanges();
                    if (resulUserRole > 0)
                        return resulUserRole;
                    return 0;
                }
                myContext.Users.Remove(user);
                myContext.SaveChanges();
                myContext.Employees.Remove(employee);
                myContext.SaveChanges();
                return 0;
            }
            return 0;
        }

        // Forgot Password
        // Change Password


    }
}


