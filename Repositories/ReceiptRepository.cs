using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MockPrj.Data;
using MockPrj.Models;

namespace MockPrj.Repositories
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly SIMSDbContext _context;
        public ReceiptRepository(SIMSDbContext context)
        {
            _context = context;
        }
        public bool Add(ReceiptNote o)
        {
            try
            {
                o.AddTime = DateTime.Now;
                o.ModifiedTime = DateTime.Now;
                _context.ReceiptNotes.Add(o);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<ReceiptNote> All()
        {
            return _context.ReceiptNotes.Include(o=>o.ReceiptNoteDetailses).ToList();
        }

        public ReceiptNote Get(int Id)
        {
             return _context.ReceiptNotes.Include(o=>o.ReceiptNoteDetailses).ToList().Find(k=>k.Id.Equals(Id));
        }

        public bool Remove(int Id)
        {
            try
            {
                _context.ReceiptNotes.Remove(_context.ReceiptNotes.Find(Id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(ReceiptNote o)
        {
            try
            {
                o.ModifiedTime = DateTime.Now;
                _context.ReceiptNotes.Update(o);
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
