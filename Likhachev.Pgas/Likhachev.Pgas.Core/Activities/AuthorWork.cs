namespace Likhachev.Pgas.Core.Activities
{
    using Abstractions;
    using DictionaryTypes;
    public partial class AuthorWork : Entity
    {
        public int ActivityId { get; set; }
        public int CreativeEndeavorId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual CreativeEndeavor CreativeEndeavor { get; set; }
    }
}
