namespace SecuritySystem.Web.Features.Guards
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SecuritySystem.Application.Guards.GuardUnits.Commands.Create;
    using SecuritySystem.Application.Guards.GuardUnits.Commands.Delete;

    public class GuardUnitsController : ApiController
    {
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateGuardUnitOutputModel>> Create(
           CreateGuardUnitCommand command)
           => await this.Send(command);


        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete(
            [FromRoute] DeleteGuardUnitCommand command)
            => await this.Send(command);

    }
}
