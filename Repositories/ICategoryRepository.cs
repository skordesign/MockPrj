using System.Collections.Generic;
using MockPrj.Models;

namespace MockPrj.Repositories
{
    public interface ICategoryRepository:IRepository<Category>
    {
        bool AddList(List<Category> categories);
    }
}
