
using Taurob.Api.Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Taurob.Api.Core;
using Taurob.Api.Application;

namespace Taurob.Api.Presentation.Ioc;

public static class WebApiConfiguration
{
    /// <summary>
    /// Register services in core
    /// </summary>
    /// <param name="services"></param>
    public static void Register(this IServiceCollection services)
    {
        //Register in memory database
        services.AddDbContext<TaurobDBContext>(options => options.UseInMemoryDatabase("TaurobDBContext"));
         
        //Register core layer 
        services.AddValidatorsFromAssembly(typeof(InjectCore).GetType().Assembly);

        //Register application layer
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(InjectApplication).GetType().Assembly));

    }

}
