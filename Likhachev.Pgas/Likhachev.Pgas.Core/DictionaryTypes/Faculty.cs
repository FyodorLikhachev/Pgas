using Likhachev.Pgas.Core.Abstractions;
using System.Collections.Generic;

namespace Likhachev.Pgas.Core.DictionaryTypes
{
    public partial class Faculty : Entity
    {
        public string FacultyName { get; set; }
        public Faculty()
        {
            Accounts = new HashSet<Account>();
        }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
