using System.Collections.Generic;

namespace Likhachev.Pgas.Core.Accounts
{
    using Activities;
    using Abstractions;
    using PgasClaims;
    using DictionaryTypes;
    public partial class Account : Entity
    {
        public Account()
        {
            Activities = new HashSet<Activity>();
            PgasClaimAccount = new HashSet<PgasClaim>();
            PgasClaimReviewer = new HashSet<PgasClaim>();
        }

        public int AccountTypeId { get; set; }
        //public FullName Name { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FatherName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? FacultyId { get; set; }
        public string StudyGroup { get; set; }
        public string Position { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<PgasClaim> PgasClaimAccount { get; set; }
        public virtual ICollection<PgasClaim> PgasClaimReviewer { get; set; }
    }
}
