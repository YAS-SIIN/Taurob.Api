
using Taurob.Api.Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Taurob.Api.Core;
using Taurob.Api.Application;
using MediatR;
using Taurob.Api.Application.Behaviours;
using Taurob.Api.CrudTest.WebApi.Behaviours;
using Taurob.Api.Domain.DTOs.Exceptions;
using System.ComponentModel.DataAnnotations;
using Taurob.Api.Core.Commands.Mission;

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
        services.AddValidatorsFromAssembly(typeof(InjectCore).Assembly);

        //Register application layer
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(InjectApplication).Assembly));

        //Register pipeline
        #region Register Pipelines
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        #endregion


        #region Register validation pipeline
        services.AddScoped(typeof(IPipelineBehavior<CreateMissionCommand, ResultDto<ValidationResult>>), typeof(ValidationBehaviour<CreateMissionCommand, ResultDto<ValidationResult>>));

        services.AddScoped(typeof(IPipelineBehavior<CreateMissionCommand, ResultDto<ValidationResult>>), typeof(ValidationBehaviour<CreateMissionCommand, ResultDto<ValidationResult>>)); 
        #endregion

    }

}
