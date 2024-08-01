
using MediatR;

using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Mission;
using Taurob.Api.Domain.DTOs.Robot;

namespace Taurob.Api.Core.Queries.Mission;

public class GetAllMissionQuery : IRequest<ResultDto<IList<GetMissionResponse>>>
{
}
