using System;
using System.Collections.Generic;
using System.Linq;

public class PetClinicController
{
    private List<Pet> allPets;
    private List<Clinic> clinics;

    public PetClinicController()
    {
        this.allPets = new List<Pet>();
        this.clinics = new List<Clinic>();
    }

    public void CreateEntity(List<string> commandTokens)
    {
        string entityType = commandTokens[0];
        if (entityType == "Pet")
        {
            var name = commandTokens[1];
            var age = int.Parse(commandTokens[2]);
            var kind = commandTokens[3];
            allPets.Add(new Pet(name, age, kind));
        }
        else if (entityType == "Clinic")
        {
            var name = commandTokens[1];
            var roomsNumber = int.Parse(commandTokens[2]);
            clinics.Add(new Clinic(name, roomsNumber));
        }
    }

    public bool AddPetToClinic(string petName, string clinicName)
    {
        var pet = this.allPets.FirstOrDefault(p => p.Name == petName);
        var clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);

        if (clinic.AddPet(pet))
        {
            this.allPets.Remove(pet);
            return true;
        }
        return false;
    }

    public bool ReleasePetFromClinic(string clinicName)
    {
        var clinic = this.clinics
            .FirstOrDefault(c => c.Name == clinicName);

        return clinic.ReleasePet();
    }

    public bool CheckForEmptyRooms(string clinicName)
    {
        var clinic = this.clinics
            .FirstOrDefault(c => c.Name == clinicName);
        return clinic.HasEmptyRooms();
    }

    public string PrintClinicInfo(List<string> commandTokens)
    {
        var currentClinic = this.clinics.FirstOrDefault(c => c.Name == commandTokens[0]);
        string result = null;

        if (commandTokens.Count == 1)
        {
            result = currentClinic.Print();
        }
        else
        {
            int roomIndex = int.Parse(commandTokens[1]) - 1;
            result = currentClinic.Print(roomIndex);
        }

        return result;
    }
}
