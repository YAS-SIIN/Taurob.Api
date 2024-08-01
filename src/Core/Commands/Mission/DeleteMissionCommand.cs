using FluentValidation;
using MediatR;
using Taurob.Api.Domain.DTOs.Exceptions;

namespace Taurob.Api.Core.Commands.Mission;

public class DeleteMissionCommand : IRequest<ResultDto<int>>
{
    /// <summary>
    /// Mission Id
    /// </summary> 
    public int Id { get; set; }
     
}


/// <summary>
/// Check mission input data validation in delete
/// </summary>
public class DeleteMissionCommandValidator : AbstractValidator<DeleteMissionCommand>
{
    public DeleteMissionCommandValidator()
    {

        RuleFor(v => v.Id).NotEqual(0).WithMessage("Enter {PropertyName}.");

    }

}