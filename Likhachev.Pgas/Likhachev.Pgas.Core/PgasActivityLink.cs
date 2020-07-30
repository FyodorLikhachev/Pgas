namespace Likhachev.Pgas.Core
{
    using Abstractions;
    using Activities;
    using PgasClaims;
    public partial class PgasActivityLink : Entity
    {
        public int PgasClaimId { get; set; }
        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual PgasClaim PgasClaim { get; set; }
    }
}
