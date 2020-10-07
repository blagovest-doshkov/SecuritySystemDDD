namespace SecuritySystem.Application.Guards.GuardPatrols.Commands.Create
{
    public class CreateGuardPatrolOutputModel
    {
        public CreateGuardPatrolOutputModel(int guardPatrolId)
        {
            this.GuardPatrolId = guardPatrolId;
        }

        public int GuardPatrolId { get; }
    }
}
