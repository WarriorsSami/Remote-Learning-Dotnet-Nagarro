using System;
using System.Collections.Generic;

namespace iQuest.TheUniverse.Infrastructure
{
    public interface IRequestHandler<T>
    {
        Either<Boolean, List<T>> Execute(IRequest request);
    }
}