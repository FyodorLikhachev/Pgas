using Likhachev.Pgas.Core.Abstractions;
using System.Collections.Generic;

namespace Likhachev.Pgas.Core.DictionaryTypes
{
    public partial class AccountType : Entity
    {
        public string AccountTypeName { get; set; }
        public AccountType()
        {
            Accounts = new HashSet<Account>();
        }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
