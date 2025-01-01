using AutoMapper;
using ProjectONE.API.Model;
using ProjectONE.API.DTO;
using ProjectONE.API.Data;
using ProjectONE.API.Repository;

namespace ProjectONE.API.Service;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;
    
    public PlayerService(IPlayerRepository playerRepository, IMapper mapper) 
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    public String ResetEverything()
    {
        return _playerRepository.ResetEverything();
    }
    public IEnumerable<Player> GetAllPlayers()
    {
        return _playerRepository.GetAllPlayers();
    }

    public String LookAtItems( int playerId)
    {
        return _playerRepository.LookAtItems(playerId);
    }

    public String LookAtInventory(int playerId)
    {
        return _playerRepository.LookAtInventory(playerId);
    }

    
    public Item? PickupItemById(int playerid, int id){
        if (id == null) return null;
        //TODO: if playerid or item id doesn't exist return null
        return _playerRepository.PickupItemById(playerid, id);

    }
    
    public Item? EquipItemById(int playerid, int id){
        if (id == null) return null;
        return _playerRepository.EquipItemById(playerid, id);

    }

    public string? AttackEnemyById(int playerid, int id){
        return _playerRepository.AttackEnemyById(playerid, id);
    }
}