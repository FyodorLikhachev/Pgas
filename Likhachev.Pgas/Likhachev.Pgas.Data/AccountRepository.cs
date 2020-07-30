using System.Linq;

namespace Likhachev.Pgas.Data
{
    using Core.Accounts;

    public class AccountRepository : EFRepository<Account>
    {
        public Account GetLoginAccount(LoginData login) => _db.Accounts
            .FirstOrDefault(a => a.Password == login.Password && a.Login == login.Password);

        public bool IsLoginBusy(string login) => _db.Accounts.Any(x => x.Login == login);
    }
}
