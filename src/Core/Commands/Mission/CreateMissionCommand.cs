
using FluentValidation;

using MediatR;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Mission;

namespace Taurob.Api.Core.Commands.Mission;

public class CreateMissionCommand : IRequest<ResultDto<GetMissionResponse>>
{
   

}


public class CreateMissionCommandValidator : AbstractValidator<CreateMissionCommand>
{
    public CreateMissionCommandValidator()
    {

      
    }

}