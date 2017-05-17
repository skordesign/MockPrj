using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MockPrj.Data;
using MockPrj.Models;

namespace MockPrj.Repositories
{
    public class BillRepository : IBillRepository
    {
        private readonly SIMSDbContext _context;
        public BillRepository(SIMSDbContext context)
        {
            _context = context;
        }
        public bool Add(Bill o)
        {
            try
            {
                o.AddTime = DateTime.Now;
                o.ModifiedTime = DateTime.Now;
                _context.Bills.Add(o);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Bill> All()
        {
            return _context.Bills.Include(o => o.BillDetailses).ToList();
        }

        public Bill Get(int Id)
        {
            return _context.Bills.Include(o => o.BillDetailses).ThenInclude(k => k.Product).ToList().Find(k => k.Id.Equals(Id));
        }

        public bool Remove(int Id)
        {
            try
            {
                _context.Bills.Remove(_context.Bills.Find(Id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Bill o)
        {
            try
            {
                o.ModifiedTime = DateTime.Now;
                _context.Bills.Update(o);
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