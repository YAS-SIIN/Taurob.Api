
using FluentValidation;

using Taurob.Api.Core.Commands.Robot;

using MediatR;

using System.ComponentModel;

using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Mission;

namespace Taurob.Api.Core.Commands.Mission;

public class UpdateMissionCommand : IRequest<ResultDto<MissionResponse>>
{
    /// <summary>
    /// Mission Id
    /// </summary> 
    public int Id { get; set; }

    /// <summary>
    /// Name of mission
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Robot foreign key
    /// </summary>
    [DisplayName("Robot")]
    public int RobotId { get; set; }

    /// <summary>
    /// Description
    /// </summary> 
    [DisplayName("description")]
    public string? Description { get; set; }
}


/// <summary>
/// Check mission input data validation in update
/// </summary>
public class UpdateMissionCommandValidator : AbstractValidator<UpdateMissionCommand>
{
    public UpdateMissionCommandValidator()
    {

        RuleFor(v => v.Id).NotEqual(0).WithMessage("Enter {PropertyName}.");

        RuleFor(v => v.Name)
      .NotEmpty().WithMessage("Enter {PropertyName}.")
      .MaximumLength(100).WithMessage("Maximum size of {PropertyName} is {MaxLength}.")
      .MinimumLength(3).WithMessage("Minimum size of {PropertyName} is {MinLength}.");

        RuleFor(v => v.RobotId).NotEqual(0).WithMessage("Enter {PropertyName}.");
    }

}