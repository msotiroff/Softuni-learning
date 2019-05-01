using System;
using System.Collections.Generic;
using System.Linq;

public class ClinicManager : IClinicManager
{
    private ClinicFactory clinicFactory;
    private PetFactory petFactory;
    private IList<IClinic> clinics;
    private IList<IPet> pets;

    public ClinicManager(ClinicFactory clinicFactory, PetFactory petFactory, IList<IClinic> clinics, IList<IPet> pets)
    {
        this.clinicFactory = clinicFactory;
        this.petFactory = petFactory;
        this.clinics = clinics;
        this.pets = pets;
    }

    public bool Add(string[] args)
    {
        var petName = args[0];
        var clinicName = args[1];

        var pet = this.pets.FirstOrDefault(p => p.Name == petName);
        var clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);

        if (pet == null)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        return clinic.AddPet(pet);
    }

    public void Create(string[] args)
    {
        var objectName = args[0];
        var name = args[1];

        switch (objectName)
        {
            case nameof(Clinic):
                var roomsCount = int.Parse(args[2]);
                var clinic = this.clinicFactory.CreateInstance(name, roomsCount);
                this.clinics.Add(clinic);
                break;
            case nameof(Pet):
                var age = int.Parse(args[2]);
                var kind = args[3];
                var pet = this.petFactory.CreateInstance(name, age, kind);
                this.pets.Add(pet);
                break;
            default:
                break;
        }
    }

    public bool HasEmptyRooms(string[] args)
    {
        var clinicName = args[0];

        var clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);

        if (clinic == null)
        {
            return false;
        }

        return clinic.HasEmptyRooms();
    }

    public string Print(string[] args)
    {
        var clinicName = args[0];

        var clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);

        if (args.Length == 1)
        {
            return clinic.ToString();
        }

        var roomIndex = int.Parse(args[1]) - 1;

        var room = clinic.Rooms[roomIndex];

        return room.ToString();
    }

    public bool Release(string[] args)
    {
        var clinicName = args[0];

        var clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);

        if (clinic == null)
        {
            return false;
        }

        return clinic.Release();
    }
}
