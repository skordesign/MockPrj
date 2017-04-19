using MockPrj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockPrj.Data
{
    public class InitDb
    {
        public static void Init(SIMSDbContext _context)
        {
            _context.Database.EnsureCreated();
            if (!_context.Accounts.Any())
            {
                _context.Roles.Add(new Role
                {
                    Name = "User",
                    AddTime = DateTime.Now,
                    ModifiedTime = DateTime.Now,
                });
                _context.Roles.Add(new Role
                {
                    Name = "Administrator",
                    AddTime = DateTime.Now,
                    ModifiedTime = DateTime.Now
                });
                _context.SaveChanges();

                _context.Accounts.Add(new Account
                {
                    Email = "skordesign@outlook.com",
                    PasswordHashed = Protector.HashPassword("Phatlatao123"),
                    RoleId = 1,
                    Firstname = "Phat",
                    Lastname = "Huynh",
                    AddTime = DateTime.Now,
                    ModifiedTime = DateTime.Now
                });

                _context.SaveChanges();
            }
        }
    }
}
