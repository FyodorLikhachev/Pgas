using Likhachev.Pgas.Core.Abstractions;

namespace Likhachev.Pgas.Core
{
    public partial class ReviewerRemark : Entity
    {
        public int? PgasClaimId { get; set; }
        public string Comment { get; set; }
        public decimal? NewMark { get; set; }

        public virtual PgasClaim PgasClaim { get; set; }
    }
}
