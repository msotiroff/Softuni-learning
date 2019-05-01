public interface IClinicManager
{
    void Create(string[] args);

    bool Add(string[] args);

    bool Release(string[] args);

    bool HasEmptyRooms(string[] args);

    string Print(string[] args);
}
