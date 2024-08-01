using FluentValidation;
using MediatR;
using System.ComponentModel;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Robot;

namespace Taurob.Api.Core.Commands.Robot;

public class CreateRobotCommand : IRequest<ResultDto<RobotResponse>>
{
    /// <summary>
    /// Name of robot
    /// </summary>
    [DisplayName("Robt name")]
    public string Name { get; set; }

    /// <summary>
    /// Model name of robot
    /// </summary>
    [DisplayName("Robt model name")]
    public string Modelname { get; set; }

    /// <summary>
    /// Description
    /// </summary> 
    [DisplayName("description")]
    public string? Description { get; set; }
}


/// <summary>
/// Check robot input data validation in create
/// </summary>
public class CreateRobotCommandValidator : AbstractValidator<CreateRobotCommand>
{
    public CreateRobotCommandValidator()
    {
        RuleFor(v => v.Name)
      .NotEmpty().WithMessage("Enter {PropertyName}.")
      .MaximumLength(100).WithMessage("Maximum size of {PropertyName} is {MaxLength}.")
      .MinimumLength(3).WithMessage("Minimum size of {PropertyName} is {MinLength}.");

        RuleFor(v => v.Modelname)
      .NotEmpty().WithMessage("Enter {PropertyName}.")
      .MaximumLength(100).WithMessage("Maximum size of {PropertyName} is {MaxLength}.")
      .MinimumLength(3).WithMessage("Minimum size of {PropertyName} is {MinLength}.");

         
    }

}