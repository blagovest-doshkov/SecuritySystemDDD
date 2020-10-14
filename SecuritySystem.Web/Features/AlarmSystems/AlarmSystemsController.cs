namespace SecuritySystem.Web.Features
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SecuritySystem.Application.Common;
    using SecuritySystem.Application.Systems.Commands.Create;
    using SecuritySystem.Application.Systems.Commands.Delete;
    using SecuritySystem.Application.Systems.Commands.Edit;
    using SecuritySystem.Application.Systems.Commands.Installation;
    using SecuritySystem.Application.Systems.Queries.Details;
    using SecuritySystem.Application.Systems.Queries.Search;
    using SecuritySystem.Domain.Systems.Models;

    public class AlarmSystemsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<SearchAlarmSystemsOutputModel>> Search(
            [FromQuery] SearchAlarmSystemsQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<AlarmSystem>> Details(
            [FromRoute] DetailsAlarmSystemQuery query)
            => await this.Send(query);

        [HttpPost]
        public async Task<ActionResult<CreateAlarmSystemOutputModel>> Create(
           [FromBody] CreateAlarmSystemCommand command)
           => await this.Send(command);

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id, EditAlarmSystemCommand command)
            => await this.Send(command.SetId(id));

        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete(
            [FromRoute] DeleteAlarmSystemCommand command)
            => await this.Send(command);

        [HttpPut]
        [Route(Id + PathSeparator + nameof(CompleteInstallation))]
        public async Task<ActionResult> CompleteInstallation(
            [FromRoute] CompleteInstallationCommand commmand)
            => await this.Send(commmand);

        [HttpPut]
        [Route(Id + PathSeparator + nameof(EnterConfiguration))]
        public async Task<ActionResult> EnterConfiguration(
            [FromRoute] EnterConfigurationModeCommand commmand)
            => await this.Send(commmand);

        [HttpPut]
        [Route(Id + PathSeparator + nameof(ExitConfiguration))]
        public async Task<ActionResult> ExitConfiguration(
            [FromRoute] ExitConfigurationModeCommand commmand)
            => await this.Send(commmand);

        [HttpPut]
        [Route(Id + PathSeparator + nameof(AssignControlUnit))]
        public async Task<ActionResult> AssignControlUnit(
            int id, AssignControlUnitCommand commmand)
            => await this.Send(commmand.SetId(id));
    }
}
