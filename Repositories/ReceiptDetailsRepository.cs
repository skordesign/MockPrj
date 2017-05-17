using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MockPrj.Data;
using MockPrj.Models;

namespace MockPrj.Repositories
{
    public class ReceiptDetailsRepository : IReceiptDetailsRepository
    {
        private readonly SIMSDbContext _context;
        public ReceiptDetailsRepository(SIMSDbContext context)
        {
            _context = context;
        }
        public bool Add(ReceiptNoteDetails o)
        {
            try
            {
                _context.ReceiptNoteDetailses.Add(o);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<ReceiptNoteDetails> All()
        {
            return _context.ReceiptNoteDetailses.Include(o => o.Product).ToList();
        }

        public ReceiptNoteDetails Get(int Id)
        {
            return _context.ReceiptNoteDetailses.Include(o => o.Product).SingleOrDefault(k => k.ReceiptNoteId.Equals(Id));
        }

        public bool Remove(int Id)
        {
            try
            {
                _context.ReceiptNoteDetailses.Remove(_context.ReceiptNoteDetailses.Find(Id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
         public bool Update(ReceiptNoteDetails o)
        {
            try
            {
                _context.ReceiptNoteDetailses.Update(o);
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
