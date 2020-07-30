using System.Collections.Generic;

namespace Likhachev.Pgas.Core.DictionaryTypes
{
    using Abstractions;
    using PgasClaims;
    public partial class Status : Entity
    {
        public string StatusName { get; set; }
        public Status()
        {
            PgasClaim = new HashSet<PgasClaim>();
        }

        public virtual ICollection<PgasClaim> PgasClaim { get; set; }
    }
}
