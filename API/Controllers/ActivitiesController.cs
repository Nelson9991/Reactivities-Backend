using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
  [HttpGet]
  public async Task<ActionResult<List<Activity>>> GetActivities()
  {
    return HandleResult(await Mediator.Send(new Application.Activities.List.Query()));
  }

  [HttpGet("{id:guid}")]
  public async Task<ActionResult<Activity>> GetActivity(Guid id)
  {
    return HandleResult(await Mediator.Send(new Application.Activities.Details.Query { Id = id }));
  }

  [HttpPost]
  public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
  {
    return HandleResult(
      await Mediator.Send(new Application.Activities.Create.Command { Activity = activity })
    );
  }

  [HttpPut("{id:guid}")]
  public async Task<IActionResult> EditActivity(Guid id, Activity activity)
  {
    activity.Id = id;
    return HandleResult(
      await Mediator.Send(new Application.Activities.Edit.Command { Activity = activity })
    );
  }

  [HttpDelete("{id:guid}")]
  public async Task<IActionResult> DeleteActivity(Guid id)
  {
    return HandleResult(await Mediator.Send(new Application.Activities.Delete.Command { Id = id }));
  }
}
