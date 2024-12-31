using Microsoft.EntityFrameworkCore;
using ProjectONE.API.Model;
using ProjectONE.API.Data;

namespace ProjectONE.API.Repository;

public class RoomRepository : IRoomRepository
{
    private readonly DataContext _dataContext;

    public RoomRepository(DataContext dataContext) => _dataContext = dataContext;
    
    /*
    public async Task<Room> CreateNewRoom(Room newRoom)
    {
        //Insert into Room Values (newRoom)
        await _dataContext.Rooms.AddAsync(newRoom);
        await _dataContext.SaveChangesAsync();
        return newRoom;
    }
    
    */
    
    
    public IEnumerable<Room> GetAllRooms()
    {
        return _dataContext.Rooms!;
    }
    
    public Room? GetRoomById(int id)
    {
        return _dataContext.Rooms.Find(id);
    }

    public Item? GetItemById(int id)
    {
        return _dataContext.Items.Find(id);
    }

    public Item? pickupItemById(int id)
    {
        var newItem = GetItemById(id);
        _dataContext.Items.Remove(newItem);
        //put item in player inventory later
       // _dataContext.Players.Items.Add(newItem);
        return newItem;

    }
   
}