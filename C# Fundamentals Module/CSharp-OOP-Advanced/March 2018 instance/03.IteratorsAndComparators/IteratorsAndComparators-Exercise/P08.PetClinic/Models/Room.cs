public class Room
{
    private const string RoomEmpty = "Room empty";

    public IPet Pet { get; set; }

    public override string ToString()
    {
        return this.Pet?.ToString() ?? RoomEmpty;
    }
}