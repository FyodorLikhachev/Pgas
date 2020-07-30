namespace Likhachev.Pgas.Core.Activities
{
    using Abstractions;
    using DictionaryTypes;
    public partial class Achievement : Entity 
    {
        public int ActivityId { get; set; }
        public int EvLvlId { get; set; }
        public int AchieveLvlId { get; set; }
        public int GroupSizeId { get; set; }
        public string EventLink { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual AchievementLevel AchieveLvl { get; set; }
        public virtual EventLevel EvLvl { get; set; }
        public virtual GroupSize GroupSize { get; set; }
    }
}
