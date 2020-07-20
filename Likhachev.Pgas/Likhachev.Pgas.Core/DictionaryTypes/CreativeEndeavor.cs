using Likhachev.Pgas.Core.Abstractions;
using System.Collections.Generic;

namespace Likhachev.Pgas.Core.DictionaryTypes
{
    public partial class CreativeEndeavor : Entity
    {
        public string CreativeEndeavorName { get; set; }
        public CreativeEndeavor()
        {
            AuthorWorks = new HashSet<AuthorWork>();
        }

        public virtual ICollection<AuthorWork> AuthorWorks { get; set; }
    }
}
