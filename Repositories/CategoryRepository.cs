using System.Collections.Generic;
using System.Linq;
using MockPrj.Models;
using MockPrj.Data;
using System;

namespace MockPrj.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SIMSDbContext _context;
        public CategoryRepository(SIMSDbContext context)
        {
            _context = context;
        }
        public bool Add(Category o)
        {
            try
            {
                o.AddTime = DateTime.Now;
                o.ModifiedTime = DateTime.Now;
                _context.Categories.Add(o);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Category> All()
        {
            return _context.Categories.ToList();
        }

        public Category Get(int Id)
        {
            return _context.Categories.Find(Id);
        }
        public bool Remove(int Id)
        {
            try
            {
                _context.Categories.Remove(_context.Categories.Find(Id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Category o)
        {
            try
            {
                o.ModifiedTime = DateTime.Now;
                _context.Categories.Update(o);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AddList(List<Category> categories)
        {
            try
            {
                foreach (var item in categories)
                {
                    item.AddTime = DateTime.Now;
                    item.ModifiedTime = DateTime.Now;
                }
                _context.Categories.AddRange(categories);
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
