using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace iQuest.TheUniverse.Infrastructure
{
    public class RequestBus
    {
        private readonly Dictionary<Type, Type> _handlers = new Dictionary<Type, Type>();

        public void RegisterHandler<TReturnedType, TRequest, THandler>() 
            where TRequest: IRequest
            where THandler: IRequestHandler<TReturnedType>
        {
            if (_handlers.ContainsKey(typeof(THandler)))
                throw new ArgumentException("requestType is already registered.", nameof(TRequest));

            _handlers.Add(typeof(TRequest), typeof(THandler));
        }

        public TReturnedType Send<TReturnedType>(IRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var requestType = request.GetType();

            if (!_handlers.ContainsKey(requestType))
                throw new Exception("Request handler not registered for the specified request.");

            var requestHandlerType = _handlers[requestType];

            var requestHandler = (IRequestHandler<TReturnedType>)Activator
                .CreateInstance(requestHandlerType);

            Debug.Assert(requestHandler != null, nameof(requestHandler) + " != null");
            return requestHandler.Execute(request);
        }
    }
}