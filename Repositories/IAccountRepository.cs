using MockPrj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockPrj.Repositories
{
    public interface IAccountRepository:IRepository<Account>
    {
        Account Get(string email, string password);
    }
}
