namespace SecuritySystem.Web.Features.Guards
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SecuritySystem.Application.Guards.GuardTasks.Queries.Search;

    public class GuardTasksController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<SearchGuardTaskOutputModel>> Search(
            [FromQuery] SearchGuardTaskQuery query)
            => await this.Send(query);


    }
}
