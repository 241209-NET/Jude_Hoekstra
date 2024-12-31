using Microsoft.EntityFrameworkCore;
using ProjectONE.API.Model;
using ProjectONE.API.Data;

namespace ProjectONE.API.Repository;

public class PlayerRepository : IPlayerRepository
{
    private readonly PlayerContext playerContext;

    public PlayerRepository(PlayerContext playerContext) => _playerContext = playerContext;
    
    
    public IEnumerable<Room> getAllPlayersm()
    {
        return _playerContext.Rooms!;
    }
    
    public Player? GetPlayerById(int id)
    {
        return _playerContext.Player.Find(id);
    }

    public Item? GetItemByName(string name)
    {
        return _itemContext.Items.FindByName(name);
    }

    public Room? equipItemByName(string name)
    {
        var newItem = GetItemByName(name);
        // deletes equippedItem
        _playerContext.Items.Remove(newItem);
        _playerContext.EquippedItem.Add(newItem);
        return newItem;

    }
   
}