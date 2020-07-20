using Likhachev.Pgas.Core.Abstractions;
using System;

namespace Likhachev.Pgas.Core
{
    public partial class AllActivity : Entity
    {
        public int ActivityType { get; set; }
        public int AccountId { get; set; }
        public int? Mark { get; set; }
        public string ActivityName { get; set; }
        public DateTime Date { get; set; }
        public int PinnedFileId { get; set; }
        public int? EvLvlId { get; set; }
        public int? AchieveLvlId { get; set; }
        public int? GroupSizeId { get; set; }
        public string EventLink { get; set; }
        public int? CrEndeavorId { get; set; }
    }
}
