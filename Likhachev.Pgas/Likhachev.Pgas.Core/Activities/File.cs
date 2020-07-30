using System.Collections.Generic;

namespace Likhachev.Pgas.Core.Activities
{
    using Abstractions;
    public partial class File : Entity
    {
        public string FileName { get; set; }
        public byte[] FileByte { get; set; }

        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
    }
}
