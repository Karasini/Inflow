using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Inflow.Shared.Abstractions.Commands;
using Pipelines;

namespace Inflow.Shared.Infrastructure.Commands;

public static class Extensions
{
    public static IServiceCollection AddCommands(this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        services.AddPipeline()
            .AddInput(typeof(ICommand))
            .AddHandler(typeof(ICommandHandler<>), assemblies.ToArray())
            .AddDispatcher<ICommandDispatcher>(typeof(Extensions).Assembly)
            .WithClosedTypeDecorators(x =>
            {
                x.WithAttribute<DecoratorAttribute>();
            }, typeof(Extensions).Assembly)
            .Build();

        return services;
    }
}