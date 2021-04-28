using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            var response = await Mediator.Send(new List.Query());
            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet("{id}")] //Activities/Id
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            var response = await Mediator.Send(new Details.Query(id));
            return response == null ? NotFound() : Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command(activity)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            return Ok(await Mediator.Send(new Edit.Command(activity)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command(id)));
        }
    }
}
