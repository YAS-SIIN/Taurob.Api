
using MediatR;
using Taurob.Api.Core.Commands.Mission;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Mission;
using Taurob.Api.Infra.Data.Context;

namespace Taurob.Api.Application.UseCases.Mission.Commands;

public class DeleteMissionCommandHandler : IRequestHandler<DeleteMissionCommand, ResultDto<int>>
{
    private readonly TaurobDBContext _dbContext;
    public DeleteMissionCommandHandler(TaurobDBContext dbContext) => _dbContext = dbContext;

    public async Task<ResultDto<int>> Handle(DeleteMissionCommand request, CancellationToken cancellationToken)
    { 
        return ResultDto<int>.ReturnData(0, 0, 0, "");
    }
}
