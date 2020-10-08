namespace SecuritySystem.Application.Guards.GuardUnits.Commands.Create
{
    public class CreateGuardUnitOutputModel
    {
        public CreateGuardUnitOutputModel(int guardUnitId)
        {
            this.GuardUnitId = guardUnitId;
        }

        public int GuardUnitId { get; }
    }
}
