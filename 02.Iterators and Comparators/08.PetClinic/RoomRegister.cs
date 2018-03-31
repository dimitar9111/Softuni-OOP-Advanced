using System.Collections;
using System.Collections.Generic;

public class RoomRegister : IEnumerable<int>
{
    private readonly List<Pet> rooms;
    private int firstRoomIndex;

    public RoomRegister(int roomsNumber)
    {
        this.rooms = new List<Pet>(new Pet[roomsNumber]);
        this.firstRoomIndex = roomsNumber / 2;
    }

    public Pet this[int index]
    {
        get { return this.rooms[index]; }
        set { this.rooms[index] = value; }
    }

    public IEnumerator<int> GetEnumerator()
    {
       yield return firstRoomIndex;

       for (int i = 1; i <= firstRoomIndex; i++)
       {
           yield return firstRoomIndex - i;
           yield return firstRoomIndex + i;
       }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new System.NotImplementedException();
    }
}