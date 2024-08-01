 
using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Taurob.Api.Core.Commands.Robot;
using Taurob.Api.Core.Queries.Robot;

namespace Taurob.Api.Presentation.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RobotController : BaseApiController
{

    /// <summary>
    /// Get all robot row.
    /// </summary>
    /// <returns>Result</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllRobotQuery();
        return OkData(await Mediator.Send(query));
    }

   /// <summary>
   /// Return list of robot
   /// </summary>
   /// <param name="query"></param>
   /// <param name="cancellation"></param>
   /// <returns></returns>
    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute] GetRobotQuery query, CancellationToken cancellation)
    { 
        return OkData(await Mediator.Send(query, cancellation));
    }

    /// <summary>
    /// Creates a new robot.
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Result</returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateRobotCommand command, CancellationToken cancellation)
    {
        return OkData(await Mediator.Send(command, cancellation));
    }

    /// <summary>
    /// Update a robot.
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Result</returns>
    [HttpPut]
    public async Task<IActionResult> Update(UpdateRobotCommand command, CancellationToken cancellation)
    {
        return OkData(await Mediator.Send(command, cancellation));
    }

    /// <summary>
    /// Delete a robot.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteRobotCommand command, CancellationToken cancellation)
    { 
        return OkData(await Mediator.Send(command, cancellation));
    }

}
