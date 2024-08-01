 
using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Taurob.Api.Core.Commands.Mission;
using Taurob.Api.Core.Queries.Mission;

namespace Taurob.Api.Presentation.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MissionController : BaseApiController
{

    /// <summary>
    /// Get all mission row.
    /// </summary>
    /// <returns>Result</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllMissionQuery();
        return OkData(await Mediator.Send(query));
    }

   /// <summary>
   /// Return list of mission
   /// </summary>
   /// <param name="query"></param>
   /// <param name="cancellation"></param>
   /// <returns></returns>
    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute] GetMissionQuery query, CancellationToken cancellation)
    { 
        return OkData(await Mediator.Send(query, cancellation));
    }

    /// <summary>
    /// Creates a new mission.
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Result</returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateMissionCommand command, CancellationToken cancellation)
    {
        return OkData(await Mediator.Send(command, cancellation));
    }

    /// <summary>
    /// Update a mission.
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Result</returns>
    [HttpPut]
    public async Task<IActionResult> Update(UpdateMissionCommand command, CancellationToken cancellation)
    {
        return OkData(await Mediator.Send(command, cancellation));
    }

    /// <summary>
    /// Delete a mission.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteMissionCommand command, CancellationToken cancellation)
    { 
        return OkData(await Mediator.Send(command, cancellation));
    }

}
