using Likhachev.Pgas.Core.Abstractions;
using Likhachev.Pgas.Core.DictionaryTypes;

namespace Likhachev.Pgas.Core
{
    public partial class AuthorWork : Entity
    {
        public int ActivityId { get; set; }
        public int CreativeEndeavorId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual CreativeEndeavor CreativeEndeavor { get; set; }
    }
}
