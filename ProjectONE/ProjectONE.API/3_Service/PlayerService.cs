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
    public IEnumerable<Player> GetAllPlayers()
    {
        return _playerRepository.GetAllPlayers();
    }

    public Item? equipItemById(int id){
        if (id == null) return null;
        return _playerRepository.equipItemById(id);

    }
}