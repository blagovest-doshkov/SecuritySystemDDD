namespace SecuritySystem.Web.Features.Guards
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SecuritySystem.Application.Common;
    using SecuritySystem.Application.Guards.GuardPatrols.Commands.ChangeAvailability;
    using SecuritySystem.Application.Guards.GuardPatrols.Commands.Create;
    using SecuritySystem.Application.Guards.GuardPatrols.Commands.Delete;
    using SecuritySystem.Application.Guards.GuardPatrols.Commands.Location;
    using SecuritySystem.Application.Guards.GuardPatrols.Queries.Search;

    public class GuardPatrolsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<SearchGuardPatrolsOutputModel>> Search(
            [FromQuery] SearchGuardPatrolsQuery query)
            => await this.Send(query);


        [HttpPost]
        public async Task<ActionResult<CreateGuardPatrolOutputModel>> Create(
           CreateGuardPatrolCommand command)
           => await this.Send(command);


        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete(
            [FromRoute] DeleteGuardPatrolCommand command)
            => await this.Send(command);


        [HttpPut]
        [Route(Id + PathSeparator + nameof(UpdateLocation))]
        public async Task<ActionResult> UpdateLocation(
            int id, UpdateLocationCommand commmand)
            => await this.Send(commmand.SetId(id));

        [HttpPut]
        [Route(Id + PathSeparator + nameof(ChangeAvailability))]
        public async Task<ActionResult> ChangeAvailability(
            int id, ChangeAvailabilityCommand commmand)
            => await this.Send(commmand.SetId(id));
    }
}
