public interface IClinic
{
    string Name { get; }

    Room[] Rooms { get; }

    bool AddPet(IPet pet);

    bool Release();

    bool HasEmptyRooms();
}
