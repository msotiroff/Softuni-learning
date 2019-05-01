public class ClinicFactory
{
    public Clinic CreateInstance(string name, int numberOfRooms)
    {
        var clinic = new Clinic(name, numberOfRooms);

        return clinic;
    }
}
