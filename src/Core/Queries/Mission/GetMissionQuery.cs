

using MediatR;

using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Mission;

namespace Taurob.Api.Core.Queries.Mission;

public class GetMissionQuery : IRequest<ResultDto<MissionResponse>>
{
    /// <summary>
    /// Mission Id
    /// </summary> 
    public int Id { get; set; }
}
