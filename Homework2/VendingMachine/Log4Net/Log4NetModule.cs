using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Autofac.Core.Resolving.Pipeline;

namespace VendingMachine.Log4Net;

// https://github.com/eran-gil/autofac.log4net/blob/master/src/Autofac.log4net/Log4NetModule.cs
public class Log4NetModule : Module
{
    private readonly IResolveMiddleware _middleware;

    public Log4NetModule()
    {
        _middleware = new Log4NetMiddleware();
    }

    protected override void AttachToComponentRegistration(
        IComponentRegistryBuilder componentRegistry,
        IComponentRegistration registration
    )
    {
        registration.PipelineBuilding += (_, pipeline) =>
        {
            pipeline.Use(_middleware);
        };
        base.AttachToComponentRegistration(componentRegistry, registration);
    }
}
