using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Inflow.Shared.Infrastructure.Queries.Decorators;
using Microsoft.Extensions.DependencyInjection;
using Inflow.Shared.Abstractions.Queries;
using Pipelines;

namespace Inflow.Shared.Infrastructure.Queries;

public static class Extensions
{
    public static IServiceCollection AddQueries(this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        services.AddPipeline()
            .AddInput(typeof(IQuery<>))
            .AddHandler(typeof(IQueryHandler<,>), assemblies.ToArray())
            .AddDispatcher<IQueryDispatcher>(typeof(Extensions).Assembly)
            .WithClosedTypeDecorators(x =>
            {
                x.WithAttribute<DecoratorAttribute>();
            }, typeof(Extensions).Assembly)
            .Build();
        
        return services;
    }
        
    public static IServiceCollection AddPagedQueryDecorator(this IServiceCollection services)
    {
        services.TryDecorate(typeof(IQueryHandler<,>), typeof(PagedQueryHandlerDecorator<,>));
            
        return services;
    }
}