namespace SecuritySystem.Web.Features.ControlCenter
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SecuritySystem.Application.Common;
    using SecuritySystem.Application.ControlCenter.Commands.Installation;
    using SecuritySystem.Application.ControlCenter.Queries.Details;
    using SecuritySystem.Application.ControlCenter.Queries.Search;
    using SecuritySystem.Domain.ControlCenter.Models;

    public class AlarmEventsController: ApiController
    {
        [HttpPut]
        [Route(Id + PathSeparator + nameof(UpdateNotes))]
        public async Task<ActionResult> UpdateNotes(
            int id, UpdateNotesCommand command)
            => await this.Send(command.SetId(id));

        [HttpPut]
        [Route(Id + PathSeparator + nameof(UpdateState))]
        public async Task<ActionResult> UpdateState(
            int id, UpdateStateCommand command)
            => await this.Send(command.SetId(id));

        [HttpGet]
        public async Task<ActionResult<SearchAlarmEventsOutputModel>> Search(
            [FromQuery] SearchAlarmEventsQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<AlarmEvent>> Details(
            [FromRoute] DetailsAlarmEventQuery query)
            => await this.Send(query);
    }
}
