
using MediatR;

using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Robot;

namespace Taurob.Api.Core.Queries.Robot;

public class GetAllCRobotQuery : IRequest<ResultDto<IList<RobotResponse>>>
{
}
