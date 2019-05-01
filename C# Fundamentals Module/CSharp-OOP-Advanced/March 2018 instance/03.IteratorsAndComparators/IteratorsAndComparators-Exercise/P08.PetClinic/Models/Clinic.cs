using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Clinic : IClinic, IEnumerable<Room>
{
    private int middleIndex;
    private int currentIndex;
    private int step;

    public Clinic(string name, int numberOfRooms)
    {
        this.ValidateNumberOfRooms(numberOfRooms);
        this.Name = name;
        this.Rooms = this.InitializeRooms(numberOfRooms);
        this.middleIndex = numberOfRooms / 2;
        this.currentIndex = this.middleIndex;
        this.step = 1;
    }

    private Room[] InitializeRooms(int numberOfRooms)
    {
        var rooms = new Room[numberOfRooms];
        for (int i = 0; i < numberOfRooms; i++)
        {
            rooms[i] = new Room();
        }

        return rooms;
    }

    public string Name { get; private set; }

    public Room[] Rooms { get; private set; }

    public bool AddPet(IPet pet)
    {
        if (!this.HasEmptyRooms())
        {
            return false;
        }

        if (this.Rooms[currentIndex].Pet == null)
        {
            this.Rooms[currentIndex].Pet = pet;
            this.MoveCurrentIndex();
        }
        else
        {
            this.MoveCurrentIndex();
            return this.AddPet(pet);
        }
        
        return true;
    }

    private void MoveCurrentIndex()
    {
        var petsCount = this.Rooms.Count(r => r.Pet != null);

        if (petsCount % 2 != 0)
        {
            currentIndex = Math.Max(0, currentIndex - step);
            step++;
        }
        else
        {
            currentIndex = Math.Min(currentIndex + step, this.Rooms.Length - 1);
            step++;
        }
    }

    public bool Release()
    {
        for (int i = this.middleIndex; i < this.Rooms.Length; i++)
        {
            var currentRoom = this.Rooms[i];
            if (currentRoom.Pet != null)
            {
                currentRoom.Pet = null;
                this.ResetCurrentIndex();
                return true;
            }
        }

        for (int i = 0; i < this.middleIndex; i++)
        {
            var currentRoom = this.Rooms[i];

            if (currentRoom.Pet != null)
            {
                currentRoom.Pet = null;
                this.ResetCurrentIndex();
                return true;
            }
        }

        return false;
    }

    private void ResetCurrentIndex()
    {
        this.currentIndex = this.middleIndex;
        this.step = 1;
    }

    private void ValidateNumberOfRooms(int numberOfRooms)
    {
        if (numberOfRooms % 2 == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
    }

    public override string ToString()
    {
        var result = new StringBuilder();

        foreach (var room in this)
        {
            result.AppendLine(room.ToString());
        }

        return result.ToString().TrimEnd();
    }

    public bool HasEmptyRooms() => this.Rooms.Any(r => r.Pet == null);

    public IEnumerator<Room> GetEnumerator()
    {
        for (int i = 0; i < this.Rooms.Length; i++)
        {
            yield return this.Rooms[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}