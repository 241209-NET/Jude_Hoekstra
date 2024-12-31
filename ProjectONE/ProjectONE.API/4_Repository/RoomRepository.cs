using Microsoft.EntityFrameworkCore;
using ProjectONE.API.Model;
using ProjectONE.API.Data;

namespace ProjectONE.API.Repository;

public class RoomRepository : IRoomRepository
{
    private readonly RoomContext roomContext;

    public RoomRepository(RoomContext roomContext) => _roomContext = roomContext;
    
    public async Task<Room> CreateNewRoom(Room newRoom)
    {
        //Insert into Room Values (newRoom)
        await _roomContext.Rooms.AddAsync(newRoom);
        await _roomContext.SaveChangesAsync();
        return newRoom;
    }
    
    public IEnumerable<Room> getAllRoom()
    {
        return _roomContext.Rooms!;
    }
    
    public Room? GetRoomById(int id)
    {
        return _roomContext.Rooms.Find(id);
    }

    public Item? GetItemByName(string name)
    {
        return _itemContext.Items.FindByName(name);
    }

    public Room? pickupItemByName(string name)
    {
        var newItem = GetItemByName(name);
        _roomContext.Items.Remove(newItem);
        _playerContext.Items.Add(newItem);
        return newItem;

    }
   
}