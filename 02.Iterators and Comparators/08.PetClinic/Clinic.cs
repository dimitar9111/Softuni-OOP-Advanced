using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Clinic
{
    private string name;
    private RoomRegister roomRegister;
    private int emptyRooms;
    private int roomsNumber;

    public Clinic(string name, int roomsNumber)
    {
        this.Name = name;
        this.roomRegister = new RoomRegister(roomsNumber);
        this.EmptyRooms = roomsNumber;
        this.RoomsNumber = roomsNumber;
    }

    public string Name { get { return this.name; } private set { this.name = value; } }

    public int EmptyRooms { get { return this.emptyRooms; } private set { this.emptyRooms = value; } }

    public int RoomsNumber
    {
        get
        {
            return this.roomsNumber;
        }
        private set
        {
            if (value % 2 == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            this.roomsNumber = value;
        }
    }

    public bool HasEmptyRooms()
    {
        return this.EmptyRooms > 0;
    }

    public bool AddPet(Pet pet)
    {
        foreach (var index in this.roomRegister)
        {
            if (this.roomRegister[index] == null)
            {
                this.roomRegister[index] = pet;
                this.EmptyRooms--;
                return true;
            }
        }
        return false;
    }

    public bool ReleasePet()
    {
        var centralRoomIndex = this.RoomsNumber / 2;
        for (int i = 0; i < this.RoomsNumber; i++)
        {
            var currentIndex = (centralRoomIndex + i) % this.RoomsNumber;
            if (this.roomRegister[currentIndex] != null)
            {
                this.roomRegister[currentIndex] = null;
                this.EmptyRooms++;
                return true;
            }
        }

        return false;
    }

    public string Print()
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < this.RoomsNumber; i++)
        {
            sb.AppendLine(this.Print(i));
        }

        return sb.ToString().TrimEnd();
    }

    public string Print(int roomIndex)
    {
        return this.roomRegister[roomIndex]?.ToString() ?? "Room empty";
    }
}
