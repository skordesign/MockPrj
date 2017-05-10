using System.Collections.Generic;
using MockPrj.Models;

namespace MockPrj.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        bool AddList(List<Product> products);
        IEnumerable<Product> GetByCategory(int id);
    }
}
