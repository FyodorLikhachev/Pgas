using Likhachev.Pgas.Core.Abstractions;
using System;
using System.Collections.Generic;

namespace Likhachev.Pgas.Core
{
    public partial class Activity : Entity
    {
        public Activity()
        {
            Achievements = new HashSet<Achievement>();
            AuthorWorks = new HashSet<AuthorWork>();
            PgasActivityLinks = new HashSet<PgasActivityLink>();
        }

        public int AccountId { get; set; }
        public string ActivityName { get; set; }
        public DateTime Date { get; set; }
        public int PinnedFileId { get; set; }

        public virtual Account Account { get; set; }
        public virtual File PinnedFile { get; set; }
        public virtual ICollection<Achievement> Achievements { get; set; }
        public virtual ICollection<AuthorWork> AuthorWorks { get; set; }
        public virtual ICollection<PgasActivityLink> PgasActivityLinks { get; set; }
    }
}
