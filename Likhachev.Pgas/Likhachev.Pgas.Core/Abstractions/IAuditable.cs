using Likhachev.Pgas.Core.SharedKernel;
using System.Collections.Generic;
using System;

namespace Likhachev.Pgas.Core.Interfaces
{
    interface IAuditable
    {
        public IEnumerable<DomainEvent> Events { get; protected set; }
    }
}
