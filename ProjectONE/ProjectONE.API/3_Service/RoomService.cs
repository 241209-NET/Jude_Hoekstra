using AutoMapper;
using ProjectONE.API.Model;
//using ProjectONE.API.Model;
using ProjectONE.API.Repository;

namespace ProjectONE.API.Service;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public RoomService(IRoomRepository roomRepository, IMapper mapper)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
    } 

   /*
    public async Task<Room> CreateNewRoom(Room newRoom)
    {
        return await _roomRepository.CreateNewRoom(newRoom);
    }

    */
    public IEnumerable<Room> GetAllRooms()
    {
        return _roomRepository.GetAllRooms();
    }

    public Item? pickupItemById(int id){
        if (id == null) return null;
        return _roomRepository.pickupItemById(id);

    }

}

