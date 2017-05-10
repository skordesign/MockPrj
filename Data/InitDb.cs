using MockPrj.Models;
using System;
using System.Linq;

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
                    Name = "SalePerson",
                    AddTime = DateTime.Now,
                    ModifiedTime = DateTime.Now,
                });
                _context.Roles.Add(new Role
                {
                    Name = "InventoryMngr",
                    AddTime = DateTime.Now,
                    ModifiedTime = DateTime.Now,
                });
                _context.Roles.Add(new Role
                {
                    Name = "SaleMngr",
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
                    RoleId = 4,
                    Firstname = "Phat",
                    Lastname = "Huynh",
                    AddTime = DateTime.Now,
                    ModifiedTime = DateTime.Now
                });
                _context.Accounts.Add(new Account
                {
                    Email = "no28.a1@gmail.com",
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
