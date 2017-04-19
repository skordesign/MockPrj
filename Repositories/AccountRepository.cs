using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockPrj.Models;
using MockPrj.Data;

namespace MockPrj.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SIMSDbContext _context;
        public AccountRepository(SIMSDbContext context)
        {
            _context = context;
        }
        public bool Add(Account o)
        {
            try
            {
                o.PasswordHashed = Protector.HashPassword(o.PasswordHashed);
                _context.Accounts.Add(o);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Account> All()
        {
            return _context.Accounts.ToList();
        }

        public Account Get(int Id)
        {
            return _context.Accounts.Find(Id);
        }

        public Account Get(string email, string password)
        {
            return _context.Accounts
                .FirstOrDefault(o=>o.Email.Equals(email)&&
                o.PasswordHashed.Equals(Protector.HashPassword(password)));
        }

        public bool Remove(int Id)
        {
            try
            {
                _context.Accounts.Remove(_context.Accounts.Find(Id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Account o)
        {
            try
            {
                _context.Accounts.Update(o);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
