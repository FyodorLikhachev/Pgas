using System;
using System.Collections.Generic;

namespace Likhachev.Pgas.Core.Activities
{
    using Abstractions;
    using Accounts;
    public partial class Activity : Entity
    {
        public Activity()
        {
            PgasActivityLinks = new HashSet<PgasActivityLink>();
        }

        public int AccountId { get; set; }
        public string ActivityName { get; set; }
        public DateTime Date { get; set; }
        public int PinnedFileId { get; set; }

        public virtual Account Account { get; set; }
        public virtual File PinnedFile { get; set; }
        public virtual Achievement Achievement { get; set; }
        public virtual AuthorWork AuthorWork { get; set; }
        public virtual ICollection<PgasActivityLink> PgasActivityLinks { get; set; }
    }
}
