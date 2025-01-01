using Moq;
using System.Data.Common;
using AutoMapper;
using ProjectONE.API.Model;
using ProjectONE.API.DTO;
using ProjectONE.API.Repository;
using ProjectONE.API.Service;


namespace ProjectONE.TEST;

public class UnitTest1
{

    //Test 1
    [Fact]
    public void LookAtItemsTestRightPlayer()
    {
        //Arrange
        
        Mock<IPlayerRepository> mockRepo = new();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        PlayerService playerService = new(mockRepo.Object, mapper);

        Player newPlayer = new Player{Id = 1, Health = 10, Room = 1};

        string expectedString = "The items you are holding are: ";
        
        mockRepo.Setup(repo => repo.LookAtInventory(newPlayer.Id)).Returns(expectedString);

        // Act
        var result = playerService.LookAtInventory(1);
      //  System.Diagnostics.Debug.WriteLine("hello");
        // Assert
       
        Assert.NotNull(result);
        Assert.Equal(expectedString, result);
       // Assert.Fail("Fail on purpose" + result + expectedString);
        mockRepo.Verify(x => x.LookAtInventory(It.IsAny<int>()), Times.Once());

       
    }
    [Fact]
     public void LookAtItemsTestWrongPlayer()
    {
        //Arrange
        
        Mock<IPlayerRepository> mockRepo = new();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        PlayerService playerService = new(mockRepo.Object, mapper);

        Item newItem = new Item {Id = 2, Name = "Rock", Room = -1};
        Item newItem2 = new Item {Id = 3, Name = "Bat", Room = 0};
        Player newPlayer = new Player{Id = 1, Health = 10, Room = 1, Items = [newItem.Id]};
    

        string expectedString = "The items you are holding are: Rock";
        
        mockRepo.Setup(repo => repo.LookAtInventory(newPlayer.Id)).Returns(expectedString);

        // Act
        var result = playerService.LookAtInventory(0);
      //  System.Diagnostics.Debug.WriteLine("hello");
        // Assert
       // Assert.NotNull(result);
       
        Assert.Null(result);


       
    }
    [Fact]
     public void pickupItemsTestSameRoom()
    {
        //Arrange
        
        Mock<IPlayerRepository> mockRepo = new();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        PlayerService playerService = new(mockRepo.Object, mapper);

        Item newItem = new Item{Id = 2, Name = "Rock", Room = 1};
        Player newPlayer = new Player{Id = 1, Health = 10, Room = 1};
        
        mockRepo.Setup(repo => repo.PickupItemById(1, 2)).Returns(newItem);

        // Act
        var result = playerService.PickupItemById(1, 2);
      //  System.Diagnostics.Debug.WriteLine("hello");
        // Assert
       
        Assert.NotNull(result);
        Assert.Equal(newItem, result);
        mockRepo.Verify(x => x.PickupItemById(It.IsAny<int>(), It.IsAny<int>()), Times.Once());

       
    }

    [Fact]
    public void pickupItemsTestWrongItem()
    {
        //Arrange
        
        Mock<IPlayerRepository> mockRepo = new();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        PlayerService playerService = new(mockRepo.Object, mapper);

        Item newItem = new Item{Id = 2, Name = "Rock", Room = 3};
        Player newPlayer = new Player{Id = 1, Health = 10, Room = 1};
        
        mockRepo.Setup(repo => repo.PickupItemById(1, 2)).Returns(newItem);

        // Act
        var result = playerService.PickupItemById(1, 1);
      //  System.Diagnostics.Debug.WriteLine("hello");
        // Assert
       
        Assert.Null(result);
        mockRepo.Verify(x => x.PickupItemById(It.IsAny<int>(), It.IsAny<int>()), Times.Once());



    }

    [Fact]
    public void GetAllPlayersTest()
    {
         Mock<IPlayerRepository> mockRepo = new();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        PlayerService playerService = new(mockRepo.Object, mapper);
         List<Player> playerList = [
            new Player{Id = 1, Health = 10, Room = 1}
         ];

        mockRepo.Setup(repo => repo.GetAllPlayers()).Returns(playerList);

        // Act
        var result = playerService.GetAllPlayers();
      //  System.Diagnostics.Debug.WriteLine("hello");
        // Assert
       
        Assert.NotNull(result);
        Assert.Equal(playerList, result);
        mockRepo.Verify(x => x.GetAllPlayers(), Times.Once());

    }
    
}