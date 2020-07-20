using Likhachev.Pgas.Core.Abstractions;

namespace Likhachev.Pgas.Core
{
    public partial class PgasActivityLink : Entity
    {
        public int PgasClaimId { get; set; }
        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual PgasClaim PgasClaim { get; set; }
    }
}
