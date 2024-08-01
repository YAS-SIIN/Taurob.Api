

using FluentValidation;

using MediatR;

using System.ComponentModel;

using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Robot;

namespace Taurob.Api.Core.Commands.Robot;

public class UpdateRobotCommand : IRequest<ResultDto<GetRobotResponse>>
{
    /// <summary>
    /// Robot Id
    /// </summary> 
    public int Id { get; set; }

}


public class UpdateRobotCommandValidator : AbstractValidator<UpdateRobotCommand>
{
    public UpdateRobotCommandValidator()
    {
        RuleFor(v => v.Id).NotNull().WithMessage("Enter {PropertyName}.");
         

    }

}