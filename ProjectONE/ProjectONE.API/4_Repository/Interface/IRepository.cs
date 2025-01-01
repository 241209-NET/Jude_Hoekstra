using ProjectONE.API.Model;

namespace ProjectONE.API.Repository;

public interface IPlayerRepository
{
    //CRUD
    IEnumerable<Player> GetAllPlayers();
    string LookAtItems(int playerId);
    Item? PickupItemById(int playerid, int id);  
    Item? EquipItemById(int playerid, int id);
    string ResetEverything();
    string LookAtInventory(int playerId);

    string AttackEnemyById(int playerid, int id);
}
