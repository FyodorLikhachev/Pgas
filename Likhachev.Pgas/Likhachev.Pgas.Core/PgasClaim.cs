using Likhachev.Pgas.Core.Abstractions;
using Likhachev.Pgas.Core.DictionaryTypes;
using System;
using System.Collections.Generic;

namespace Likhachev.Pgas.Core
{
    public partial class PgasClaim : Entity
    {
        public PgasClaim()
        {
            PgasActivityLinks = new HashSet<PgasActivityLink>();
            ReviewerRemarks = new HashSet<ReviewerRemark>();
        }

        public int AccountId { get; set; }
        public int? ReviewerId { get; set; }
        public int StatusId { get; set; }
        public decimal Mark { get; set; }
        public DateTime Date { get; set; }

        public virtual Account Account { get; set; }
        public virtual Account Reviewer { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<PgasActivityLink> PgasActivityLinks { get; set; }
        public virtual ICollection<ReviewerRemark> ReviewerRemarks { get; set; }
    }
}
