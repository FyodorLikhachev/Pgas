using System;
using System.Linq.Expressions;

namespace Likhachev.Pgas.Core.Abstractions
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
    }
}
