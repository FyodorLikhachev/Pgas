using Likhachev.Pgas.Core.Abstractions;
using System.Collections.Generic;

namespace Likhachev.Pgas.Core
{
    public partial class File : Entity
    {
        public File()
        {
            Activities = new HashSet<Activity>();
        }

        public string FileName { get; set; }
        public byte[] FileByte { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}
