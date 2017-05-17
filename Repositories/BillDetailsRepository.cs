using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MockPrj.Data;
using MockPrj.Models;

namespace MockPrj.Repositories
{
    public class BillDetailsRepository : IBillDetailsRepository
    {
        private readonly SIMSDbContext _context;
        public BillDetailsRepository(SIMSDbContext context)
        {
            _context = context;
        }
        public bool Add(BillDetails o)
        {
            try
            {
                _context.BillDetailses.Add(o);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddList(List<BillDetails> billDetailses)
        {
            try
            {
                _context.BillDetailses.AddRange(billDetailses);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<BillDetails> All()
        {
            return _context.BillDetailses.ToList();
        }

        public BillDetails Get(int Id)
        {
            return _context.BillDetailses.Include(k => k.Product).FirstOrDefault(o => o.BillId.Equals(Id));
        }

        public bool Remove(int Id)
        {
            try
            {
                _context.BillDetailses.Remove(_context.BillDetailses.Find(Id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(BillDetails o)
        {
            try
            {
                _context.BillDetailses.Update(o);
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
