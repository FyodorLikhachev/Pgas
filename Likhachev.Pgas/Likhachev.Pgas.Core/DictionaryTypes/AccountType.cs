using System.Collections.Generic;

namespace Likhachev.Pgas.Core.DictionaryTypes
{
    using Abstractions;
    using Accounts;
    public partial class AccountType : Entity
    {
        public string AccountTypeName { get; protected set; }
        public AccountType()
        {
            Accounts = new HashSet<Account>();
        }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
