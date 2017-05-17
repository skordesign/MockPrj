using System.Collections.Generic;
using MockPrj.Models;

namespace MockPrj.Repositories
{
    public interface IBillDetailsRepository:IRepository<BillDetails>
    {
        bool AddList(List<BillDetails> billDetailses);
    }
}
