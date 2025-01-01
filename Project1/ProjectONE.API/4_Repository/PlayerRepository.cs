using Microsoft.EntityFrameworkCore;
using ProjectONE.API.Model;
using ProjectONE.API.Data;
using ProjectONE.API.DTO;

namespace ProjectONE.API.Repository;

public class PlayerRepository : IPlayerRepository
{
    private readonly DataContext _dataContext;

    public PlayerRepository(DataContext dataContext) => _dataContext = dataContext;


    // this function resets the player, adds three items to the room
    // for testing purposes, mainly
    public string ResetEverything()
    {
        
        foreach (var enemy in _dataContext.Enemies)
        {
            _dataContext.Enemies.Remove(enemy);
        }
        foreach (var player in _dataContext.Players)
        {
            _dataContext.Players.Remove(player);
        }
        
        foreach (var item in _dataContext.Items)
        {
            _dataContext.Items.Remove(item);
        }
        _dataContext.SaveChanges(); 
        
        Player newPlayer = new Player {Room = 0, Health = 10 };
        Item newItem1 = new Item {Name = "Rune", Room = 0 , damage = 0, description = "a mysterious rune"};
        Item newItem2 = new Item {Name = "Apple", Room = 1 , damage = 0, description = "an ordinary apple"};
        Item newItem3 = new Item {Name = "Sword", Room = 0, damage = 10, description = "an old sword"};
        Enemy newEnemy = new Enemy {Name = "Slime", Health = 20, Damage = 0, Room = 0, Description = "a harmless peaceful creature"};
        Enemy newEnemy2 = new Enemy {Name = "The most dangerous dragon ever born", Health = 9999, Damage = 9999, Room = 1, Description = "Will probably kill you instantly"};
        _dataContext.Players.Add(newPlayer); 
        _dataContext.Items.Add(newItem1); 
        _dataContext.Items.Add(newItem2); 
        _dataContext.Items.Add(newItem3); 
        _dataContext.Enemies.Add(newEnemy);
        _dataContext.Enemies.Add(newEnemy2);
        _dataContext.SaveChanges(); 
        return "Reset Everything";
    }
    
    
    
    public IEnumerable<Player> GetAllPlayers()
    {
        return _dataContext.Players!;
    }

    
// actually looks at whole room and not items
    public string LookAtItems(int playerId)
    {
        int roomNumber = GetPlayerById(playerId).Room;
        var itemList = _dataContext.Items
            .Where(item => item.Room.Equals(roomNumber))
            .ToList();
        string output = "The items you see are: " + System.Environment.NewLine;
        string vowelList = "aeiouAEIOU";
        string article = "a ";
        string article2 = "an ";
        foreach (var item in itemList)
        {
            if (vowelList.Contains(item.Name[0]))
            {
                output += article2 + item.Name + " (" + item.Id + ")" + System.Environment.NewLine;
            }
            else
            {
                output += article + item.Name + " (" + item.Id + ")" + System.Environment.NewLine;
            }
        }

        var enemyList = _dataContext.Enemies
            .Where(enemy => enemy.Room.Equals(roomNumber))
            .ToList();
        output += "The enemies you see are: " + System.Environment.NewLine;
        foreach (var enemy in enemyList)
        {
            if (vowelList.Contains(enemy.Name[0]))
            {
                output += article2 + enemy.Name + " (" + enemy.Id + ")" + System.Environment.NewLine;
            }
            else
            {
                output += article + enemy.Name + " (" + enemy.Id + ")" + System.Environment.NewLine;
            }
        }

        return output;
    }

    public string LookAtInventory(int playerId)
    {
        //only if player exists
        var newPlayer = GetPlayerById(playerId);
        string output = "The items you are holding are: " + System.Environment.NewLine;

        if (newPlayer != null)
        {
            foreach (var itemid in newPlayer.Items)
            {
                var newItem = GetItemById(itemid);
                if (newItem.description != null)
                {
                    output += newItem.Name + " (" + itemid + ") - " + newItem.description + System.Environment.NewLine;

                }
                else
                {
                    output += newItem.Name + " (" + itemid + ")" + System.Environment.NewLine;
                }
            }
        }

        return output;
    }

    public Item? GetItemById(int id)
    {
        return _dataContext.Items.Find(id);
    }

    public Player? GetPlayerById(int id)
    {
        return _dataContext.Players.Find(id);
    }

    // a function devised for testing
    public int? GetPlayerId()
    {
        int output = 0;
        var playerList = _dataContext.Players!;
        foreach (var item in playerList)
        {
            output += item.Id;
        }
        return output;
    }
    
    //also need to limit it to items in same room
    public Item? PickupItemById(int playerid, int id)
    {
        var newItem = GetItemById(id);
        var newPlayer = GetPlayerById(playerid);
        if (newItem != null & newPlayer != null)
        {
            if (newItem.Room.Equals(newPlayer.Room))
            {
                // changes room to -1 to show in inventory
                newItem.Room = -1;
                // this should put the item in inventory
                newPlayer.Items.Add(newItem.Id);
                _dataContext.SaveChanges();
                Console.WriteLine("Picked up " + newItem.Name + " (" + newItem.Id + ")");
                return newItem;
            }

            return null;
        }
        return null;

    }
    
    public Item? EquipItemById(int playerId, int id)
    
    {
        var newItem = GetItemById(id);
        var newPlayer = GetPlayerById(playerId);
        if ((newItem.Room == -1) & (newPlayer != null)) // only if item in inventory
        // instead of having an item slot: adjust stats, change name to equipped
        // maybe only one items equipped at once?
        // so here's what im thinking
        // 1: make all items in inventory room -1
        // 2: set room of equipped item to -2, change name to include [EQUIPPED]
        // 3: when i make the attack function, use item in inventory with room of -2
        {
            
            foreach (var item in newPlayer.Items)
            {
                var item2 = GetItemById(item);
                item2.Room = -1;
                if (item2.Name.Contains(" [EQUIPPED]"))
                {
                    item2.Name = item2.Name.Replace("[EQUIPPED]", "");
                }
                _dataContext.SaveChanges();
            }
           // _dataContext.Items.Remove(newItem);
            // changes room to -2 to show in equipment
            newItem.Room = -2;
            newItem.Name = newItem.Name + " [EQUIPPED]";
            // this should put the item in equipment
           // _dataContext.Items.Add(newItem);
            _dataContext.SaveChanges();
            return newItem;
        }

        return null;

    }
    
    public string? AttackEnemyById(int playerId, int id)
    {
        var newPlayer = GetPlayerById(playerId);
        if (newPlayer != null){
        var newEnemy = _dataContext.Enemies.Find(id);
        if (newEnemy != null){
            if (newEnemy.Room == newPlayer.Room)
            {
                int damage = 0;
                Item newItem = new Item {Name = "Fists", Room = -2 , damage = 1, description = "the weapon you were born with"};
                foreach (var item in newPlayer.Items)
                {
                    var newItem2 = GetItemById(item);

                    //if item is equipped, it's player health
                    if (newItem2.Room == -2){
                        newItem = newItem2;
                        if (newItem2.damage.HasValue){
                            damage += newItem2.damage.Value;
                        }
                    }

                }

                    newEnemy.Health -= damage;
                    _dataContext.SaveChanges();
                    bool killed = false;
                    if (newEnemy.Health < 0)
                    {
                        _dataContext.Enemies.Remove(newEnemy);
                        killed = true;
                        _dataContext.SaveChanges();
                    }
                    string output = "You did " + damage + " damage to " + newEnemy.Name + " with your " + newItem.Name;  

                    if (killed){
                        output += ", killing it!";
                    }
                    return output;
                
                
            }
            return "That enemy is not available to attack!";
        }
        return "That enemy does not exist!";
        }
        return null;
    }
}