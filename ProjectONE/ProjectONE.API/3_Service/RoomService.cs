using AutoMapper;
using ProjectONE.API.Model;
//using ProjectONE.API.Model;
using ProjectONE.API.Repository;

namespace ProjectONE.API.Service;

public class RoomService : IRoomService
{
    private readonly IRoomService _roomService;
    private readonly IMapper _mapper;

    public RoomService(IRoomService roomRepository, IMapper mapper)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
    } 

    public async Task<Room> CreateNewRoom(Room newRoom)
    {
        return await _roomRepository.CreateNewRoom(newRoom);
    }

    public Room? getAllRoom()
    {
        return _roomRepository.getAllRoom();
    }

    public Room? pickupItemByName(string name){
        if (name == null) return null;
        return _roomRepository.pickupItemByName(name);

    }

}

