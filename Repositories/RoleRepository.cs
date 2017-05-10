using System.Collections.Generic;
using System.Linq;
using MockPrj.Models;
using MockPrj.Data;
using System;

namespace MockPrj.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SIMSDbContext _context;
        public RoleRepository(SIMSDbContext context)
        {
            _context = context;
        }
        public bool Add(Role o)
        {
            try
            {
                o.AddTime = DateTime.Now;
                o.ModifiedTime = DateTime.Now;
                _context.Roles.Add(o);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Role> All()
        {
            return _context.Roles.ToList();
        }

        public Role Get(int Id)
        {
            return _context.Roles.Find(Id);
        }

        public bool Remove(int Id)
        {
            try
            {
                _context.Roles.Remove(_context.Roles.Find(Id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Role o)
        {
            try
            {
                o.ModifiedTime = DateTime.Now;
                _context.Roles.Update(o);
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
