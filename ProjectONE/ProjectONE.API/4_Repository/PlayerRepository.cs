using Microsoft.EntityFrameworkCore;
using ProjectONE.API.Model;
using ProjectONE.API.Data;

namespace ProjectONE.API.Repository;

public class PlayerRepository : IPlayerRepository
{
    private readonly DataContext _dataContext;

    public PlayerRepository(DataContext dataContext) => _dataContext = dataContext;
    
    public Player CreateNewPlayer(Player newPlayer)
    {
        //Insert into Players Values (newPlayer)
        _dataContext.Players.Add(newPlayer);
        _dataContext.SaveChanges();
        return newPlayer;
    }
    
    public IEnumerable<Player> GetAllPlayers()
    {
        return _dataContext.Players!;
    }
    
    public Player? GetPlayerById(int id)
    {
        return _dataContext.Players.Find(id);
    }

    public Item? GetItemById(int id)
    {
        return _dataContext.Items.Find(id);
    }

    public Item? equipItemById(int id)
    {
        var newItem = GetItemById(id);
        // deletes equippedItem
        _dataContext.Items.Remove(newItem);
        // actually change equipped item later
       // _dataContext.EquippedItem.Update(newItem);
        return newItem;

    }
   
}