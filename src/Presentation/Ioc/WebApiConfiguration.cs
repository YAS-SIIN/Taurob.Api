
using Mc2.CrudTest.Infra.Data.Context;
using Mc2.CrudTest.Infra.Data.UnitofWork;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

using Taurob.Api.Domain.Interfaces.UnitOfWork;
using FluentValidation;
using Taurob.Api.Core;

namespace Taurob.Api.Presentation.Ioc;

public static class WebApiConfiguration
{
    public static void Register(this IServiceCollection services)
    {
        //Register in memory database
        services.AddDbContext<TaurobDBContext>(options => options.UseInMemoryDatabase("TaurobDBContext"));

        //Register unit of work service
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddValidatorsFromAssembly(typeof(InjectCore).GetType().Assembly);

    }

}
