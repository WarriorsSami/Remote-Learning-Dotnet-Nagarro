using System;
using System.Collections.Generic;

namespace iQuest.TheUniverse.Infrastructure
{
    public class RequestBus
    {
        private readonly Dictionary<Type, Type> _handlers = new Dictionary<Type, Type>();

        public void RegisterHandler<T, TRequest, THandler>() 
            where TRequest: IRequest
            where THandler: IRequestHandler<T>
        {
            if (_handlers.ContainsKey(typeof(THandler)))
                throw new ArgumentException("requestType is already registered.", nameof(TRequest));

            _handlers.Add(typeof(TRequest), typeof(THandler));
        }

        public Either<Boolean, List<T>> Send<T>(IRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            Type requestType = request.GetType();

            if (!_handlers.ContainsKey(requestType))
                throw new Exception("Request handler not registered for the specified request.");

            Type requestHandlerType = _handlers[requestType];

            var requestHandler = (IRequestHandler<T>)Activator
                .CreateInstance(requestHandlerType);

            return requestHandler.Execute(request);
        }
    }
}