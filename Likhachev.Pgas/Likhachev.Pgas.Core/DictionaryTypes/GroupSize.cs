using Likhachev.Pgas.Core.Abstractions;
using System.Collections.Generic;

namespace Likhachev.Pgas.Core.DictionaryTypes
{
    public partial class GroupSize : Entity
    {
        public string GroupSizeName { get; set; }

        public GroupSize()
        {
            Achievements = new HashSet<Achievement>();
        }

        public virtual ICollection<Achievement> Achievements { get; set; }
    }
}
