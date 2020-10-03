namespace SecuritySystem.Application.Systems.Commands.Create
{
    public class CreateAlarmSystemOutputModel
    {
        public CreateAlarmSystemOutputModel(int alarmSystemId)
        {
            this.AlarmSystemId = alarmSystemId;
        }

        public int AlarmSystemId { get; }
    }
}
