using MockPrj.Models;

namespace MockPrj.Repositories
{
    public interface IAccountRepository:IRepository<Account>
    {
        Account Get(string email, string password);
        bool UpdateWithoutPassword(Account o);
    }
}
