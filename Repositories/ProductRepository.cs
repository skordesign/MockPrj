using System.Collections.Generic;
using System.Linq;
using MockPrj.Models;
using MockPrj.Data;
using System;

namespace MockPrj.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SIMSDbContext _context;
        public ProductRepository(SIMSDbContext context)
        {
            _context = context;
        }
        public bool Add(Product o)
        {
            try
            {
                o.AddTime = DateTime.Now;
                o.ModifiedTime = DateTime.Now;
                _context.Products.Add(o);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Product> All()
        {
            return _context.Products.ToList();
        }

        public Product Get(int Id)
        {
            return _context.Products.Find(Id);
        }
        public bool Remove(int Id)
        {
            try
            {
                _context.Products.Remove(_context.Products.Find(Id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Product o)
        {
            try
            {
                o.ModifiedTime = DateTime.Now;
                _context.Products.Update(o);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AddList(List<Product> products)
        {
            try
            {
                foreach (var item in products)
                {
                    item.AddTime = DateTime.Now;
                    item.ModifiedTime = DateTime.Now;
                }
                _context.Products.AddRange(products);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Product> GetByCategory(int id)
        {
            return _context.Products.Where(o => o.CategoryId.Equals(id)).ToList();
        }
    }
}
