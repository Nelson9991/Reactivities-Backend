using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : Controller
{
  private IMediator _mediator;

  protected IMediator Mediator =>
    _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

  protected ActionResult HandleResult<T>(Result<T> result)
  {
    if (result is null)
      return NotFound();

    return result.IsSuccess switch
    {
      true when result.Value != null => Ok(result.Value),
      true when result.Value == null => NotFound(),
      _ => BadRequest(result.Error)
    };
  }
}
