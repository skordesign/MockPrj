using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MockPrj.Data;
using MockPrj.Models;

namespace MockPrj.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly SIMSDbContext _context;
        public DeliveryRepository(SIMSDbContext context)
        {
            _context = context;
        }
        public bool Add(DeliveryNote o)
        {
            try
            {
                o.AddTime = DateTime.Now;
                o.ModifiedTime = DateTime.Now;
                _context.DeliveryNotes.Add(o);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<DeliveryNote> All()
        {
            return _context.DeliveryNotes.Include(o => o.DeliveryNoteDetailses).ToList();
        }

        public DeliveryNote Get(int Id)
        {
            return _context.DeliveryNotes.Include(o => o.DeliveryNoteDetailses).ToList().Find(k => k.Id.Equals(Id));
        }

        public bool Remove(int Id)
        {
            try
            {
                _context.DeliveryNotes.Remove(_context.DeliveryNotes.Find(Id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(DeliveryNote o)
        {
            try
            {
                o.ModifiedTime = DateTime.Now;
                _context.DeliveryNotes.Update(o);
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
