using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MockPrj.Data;
using MockPrj.Models;

namespace MockPrj.Repositories
{
    public class DeliveryDetailsRepository : IDeliveryDetailsRepository
    {
        private readonly SIMSDbContext _context;
        public DeliveryDetailsRepository(SIMSDbContext context)
        {
            _context = context;
        }
        public bool Add(DeliveryNoteDetails o)
        {
             try
            {
                _context.DeliveryNoteDetailses.Add(o);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<DeliveryNoteDetails> All()
        {
             return _context.DeliveryNoteDetailses.Include(o=>o.Product).ToList();
        }

        public DeliveryNoteDetails Get(int Id)
        {
            return _context.DeliveryNoteDetailses.Include(o => o.Product).SingleOrDefault(k=>k.DeliveryNoteId.Equals(Id));
        }

        public bool Remove(int Id)
        {
             try
            {
                _context.DeliveryNoteDetailses.Remove(_context.DeliveryNoteDetailses.Find(Id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(DeliveryNoteDetails o)
        {
            try
            {
                _context.DeliveryNoteDetailses.Update(o);
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
