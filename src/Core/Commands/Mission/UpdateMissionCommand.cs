
using FluentValidation;

using MediatR;

using System.ComponentModel;

using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Mission;

namespace Taurob.Api.Core.Commands.Mission;

public class UpdateMissionCommand : IRequest<ResultDto<GetMissionResponse>>
{
    /// <summary>
    /// Mission Id
    /// </summary> 
    public int Id { get; set; }

}


public class UpdateMissionCommandValidator : AbstractValidator<UpdateMissionCommand>
{
    public UpdateMissionCommandValidator()
    {

        RuleFor(v => v.Id).NotNull().WithMessage("Enter {PropertyName}.");


    }

}