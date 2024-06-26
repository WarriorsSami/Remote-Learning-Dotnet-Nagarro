﻿using System;
using System.Linq;
using System.Reflection;
using Autofac.Core;
using Autofac.Core.Resolving.Pipeline;
using log4net;

namespace VendingMachine.Log4Net;

public class Log4NetMiddleware : IResolveMiddleware
{
    public PipelinePhase Phase => PipelinePhase.ParameterSelection;

    public void Execute(ResolveRequestContext context, Action<ResolveRequestContext> next)
    {
        // Add our parameters.
        context.ChangeParameters(
            context.Parameters.Union(
                new[]
                {
                    new ResolvedParameter(
                        (p, _) => p.ParameterType == typeof(ILog),
                        (p, _) => LogManager.GetLogger(p.Member.DeclaringType)
                    ),
                }
            )
        );

        // Continue the resolve.
        next(context);

        // Has an instance been activated?
        if (context.NewInstanceActivated)
        {
            var instanceType = context.Instance?.GetType();

            // Get all the injectable properties to set.
            // If you wanted to ensure the properties were only UNSET properties,
            // here's where you'd do it.
            var properties = instanceType?
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(
                    p =>
                        p.PropertyType == typeof(ILog)
                        && p.CanWrite
                        && p.GetIndexParameters().Length == 0
                );

            // Set the properties located.
            foreach (var propToSet in properties!)
            {
                propToSet.SetValue(context.Instance, LogManager.GetLogger(instanceType), null);
            }
        }
    }
}
