using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockPrj.Repositories
{
    public interface IRepository<T>
    {
        bool Add(T o);
        T Get(int Id);
        bool Update(T o);
        bool Remove(int Id);
        IEnumerable<T> All();
    }
}
