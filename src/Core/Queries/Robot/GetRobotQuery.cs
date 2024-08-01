

using MediatR;

using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Robot;

namespace Taurob.Api.Core.Queries.Robot;

public class GetRobotQuery : IRequest<ResultDto<RobotResponse>>
{
    /// <summary>
    /// Robot Id
    /// </summary> 
    public int Id { get; set; }
}
