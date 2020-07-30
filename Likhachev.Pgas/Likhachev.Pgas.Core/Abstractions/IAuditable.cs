using System.Collections.Generic;

namespace Likhachev.Pgas.Core.Interfaces
{
    using SharedKernel;
    interface IAuditable
    {
        public IEnumerable<DomainEvent> Events { get; protected set; }
    }
}
