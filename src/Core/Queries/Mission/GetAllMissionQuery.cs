
using MediatR;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Mission;

namespace Taurob.Api.Core.Queries.Mission;

public class GetAllMissionQuery : IRequest<ResultDto<IList<MissionResponse>>>
{
}
