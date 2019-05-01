namespace FestivalManager.Entities.Instruments
{
	public class Drums : Instrument
	{
		private const int DefaultRepairAmount = 20;
        
        protected override int RepairAmount => DefaultRepairAmount;
    }
}
