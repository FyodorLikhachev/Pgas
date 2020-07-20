using System;
using System.Collections.Generic;
using System.Text;

namespace Likhachev.Pgas.Core.SharedKernel
{
    public abstract class DomainEvent
    {
        public DateTime TimeOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
