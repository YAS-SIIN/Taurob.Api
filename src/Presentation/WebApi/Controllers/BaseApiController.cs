using MediatR;
using Microsoft.AspNetCore.Mvc;

using Taurob.Api.Domain.DTOs.Exceptions;

namespace Taurob.Api.Presentation.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    private IMediator _mediator;      
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    public IActionResult OkData<TData>(ResultDto<TData> response)
    {
        return new ObjectResult(response);
    }
}
