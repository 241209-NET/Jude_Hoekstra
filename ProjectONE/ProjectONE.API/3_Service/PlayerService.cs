using AutoMapper;
using ProjectONE.API.Model;
using ProjectONE.API.Repository;

namespace ProjectONE.API.Service;

public class PlayerService
{
    public IEnumerable<Player> GetAllPlayers()
    {
        return _playerRepository.GetAllPlayers();
    }

    public Room? equipItemByName(string name){
        if (name == null) return null;
        return _playerRepository.equipItemByName(name);

    }
}