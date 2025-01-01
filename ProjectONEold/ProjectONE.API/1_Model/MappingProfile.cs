using AutoMapper;
using ProjectONE.API.DTO;

namespace ProjectONE.API.Model;

public class MappingProfile : Profile {
    public MappingProfile() {
        // Add as many of these lines as you need to map your objects
        CreateMap<Player, PlayerInDTO>();
        CreateMap<Player, PlayerOutDTO>();
        
        CreateMap<Enemy, EnemyInDTO>();
        CreateMap<Enemy, EnemyOutDTO>();
        
        CreateMap<Item, ItemInDTO>();
        CreateMap<Item, ItemOutDTO>();
        
    }
}