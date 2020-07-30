using System.Collections.Generic;

namespace Likhachev.Pgas.Core.DictionaryTypes
{
    using Activities;
    using Abstractions;
    public partial class EventLevel : Entity
    {
        public string EvLvlName { get; set; }

        public EventLevel()
        {
            Achievements = new HashSet<Achievement>();
        }

        public virtual ICollection<Achievement> Achievements { get; set; }
    }
}
