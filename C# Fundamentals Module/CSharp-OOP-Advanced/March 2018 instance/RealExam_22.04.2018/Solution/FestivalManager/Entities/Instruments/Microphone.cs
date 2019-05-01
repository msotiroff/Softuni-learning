namespace FestivalManager.Entities.Instruments
{
    public class Microphone : Instrument
    {
	    private const int DefaultRepairAmount = 80;

        protected override int RepairAmount => DefaultRepairAmount;
    }
}
