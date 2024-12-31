using Microsoft.EntityFrameworkCore;
using ProjectONE.API.Model;
using ProjectONE.API.Data;

namespace ProjectONE.API.Repository;

public class PlayerRepository : IPlayerRepository
{
    private readonly DataContext _dataContext;

    public PlayerRepository(DataContext dataContext) => _dataContext = dataContext;
    
    public IEnumerable<Player> GetAllPlayers()
    {
        return _dataContext.Players!;
    }
    

    public IEnumerable<Item> LookAtItems()
    {
        return _dataContext.Items
            // placeholder for now, need to update 0 to player room
            .Where(item => item.Room.Equals(0))
            .ToList();
    }

    public Item? GetItemById(int id)
    {
        return _dataContext.Items.Find(id);
    }
    
    //also need to limit it to items in same room
    public Item? PickupItemById(int id)
    {
        var newItem = GetItemById(id);
        // changes room to -1 to show in inventory
        newItem.Room = -1;
        // this should put the item in inventory
        _dataContext.Items.Add(newItem);
        _dataContext.SaveChanges(); 
        
        return newItem;

    }
    
    public Item? EquipItemById(int id)
    {
        var newItem = GetItemById(id);
        _dataContext.Items.Remove(newItem);
        // changes room to -2 to show in equipment
        newItem.Room = -2;
        // this should put the item in inventory
        _dataContext.Items.Add(newItem);
        _dataContext.SaveChanges(); 
        
        return newItem;

    }
   
}