using Likhachev.Pgas.Core.Abstractions;
using System.Collections.Generic;

namespace Likhachev.Pgas.Core.DictionaryTypes
{
    public partial class AchievementLevel : Entity
    {
        public string AchieveLvlName { get; set; }
        public AchievementLevel()
        {
            Achievements = new HashSet<Achievement>();
        }

        public virtual ICollection<Achievement> Achievements { get; set; }
    }
}
