

using FluentValidation;

using MediatR;

using Taurob.Api.Core.Commands.Robot;
using Taurob.Api.Domain.DTOs.Exceptions;

namespace Taurob.Api.Core.Commands.Robot;

public class DeleteRobotCommand : IRequest<ResultDto<int>>
{
    /// <summary>
    /// Robot Id
    /// </summary> 
    public int Id { get; set; }

}



/// <summary>
/// Check robot input data validation in delete
/// </summary>
public class DeleteRobotCommandValidator : AbstractValidator<DeleteRobotCommand>
{
    public DeleteRobotCommandValidator()
    {

        RuleFor(v => v.Id).NotNull().WithMessage("Enter {PropertyName}.");

    }

}