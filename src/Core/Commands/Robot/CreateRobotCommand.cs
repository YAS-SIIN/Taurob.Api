
using FluentValidation;

using MediatR;

using System.ComponentModel;

using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Robot;

namespace Mc2.CrudTest.Core.Commands.Robot;

public class CreateRobotCommand : IRequest<ResultDto<GetRobotResponse>>
{
 
}


public class CreateRobotCommandValidator : AbstractValidator<CreateRobotCommand>
{
    public CreateRobotCommandValidator()
    {

    }

}