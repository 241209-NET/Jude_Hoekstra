using ProjectONE.API.DTO;
using ProjectONE.API.Model;

namespace ProjectONE.API.Service;

public interface IPlayerService
{
    IEnumerable<Player> GetAllPlayers();
    string LookAtItems(int playerId);
    string LookAtInventory(int playerId);
    Item? PickupItemById(int playerid, int id);  
    Item? EquipItemById(int playerid, int id);  
    string ResetEverything();

    string? AttackEnemyById(int playerid, int id);
}