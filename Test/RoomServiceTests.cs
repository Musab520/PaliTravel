using Moq;
using Domain.IRepository;
using Domain.SieveModel;
using Domain.Service;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace Test;

public class RoomServiceTests
{
    private readonly Mock<IRoomRepository> _roomRepositoryMock;
    private readonly RoomService _roomService;

    public RoomServiceTests()
    {        
        var sieveOptions = Options.Create(new SieveOptions
            {
                DefaultPageSize = 10,
                MaxPageSize = 50,
        });
        var sieveProcessor = new SieveProcessor(sieveOptions);
        
        _roomRepositoryMock = new Mock<IRoomRepository>();
        _roomService = new RoomService(_roomRepositoryMock.Object, sieveProcessor);
    }

    [Fact]
    public async Task GetAvailableRoomsAsync_ShouldReturnAvailableRooms_WhenRoomsExist()
    {
        var sieveModel = new AvailableRoomSieveModel
        {
            
        };

        Guid guidRoom1 = Guid.NewGuid();
        Guid guidRoom2 = Guid.NewGuid();
        var availableRooms = new List<AvailableRoomModel?>
        {
            new AvailableRoomModel { RoomId = guidRoom1, RoomNumber = 1, Availability = "Free"},
            new AvailableRoomModel { RoomId = guidRoom2, RoomNumber = 2, Availability = "Free"}
        };

        _roomRepositoryMock
            .Setup(repo => repo.GetAvailableRoomsAsync())
            .ReturnsAsync(availableRooms);

        // Act
        var result = await _roomService.GetAvailableRoomsAsync(sieveModel);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal(1, result[0]?.RoomNumber);
        Assert.Equal(2, result[1]?.RoomNumber);


        _roomRepositoryMock.Verify(repo => repo.GetAvailableRoomsAsync(), Times.Once);
    }
    
    [Fact]
    public async Task GetAvailableRoomsAsync_ShouldReturnOneAvailableRoom_WhenRoomNumberSpecified()
    {
        var sieveModel = new AvailableRoomSieveModel
        {
            RoomNumber = 1,
            Availability = "Free",
            HotelName = "Bob"
        };

        Guid guidRoom1 = Guid.NewGuid();
        Guid guidRoom2 = Guid.NewGuid();
        var availableRooms = new List<AvailableRoomModel?>
        {
            new AvailableRoomModel { RoomId = guidRoom1, RoomNumber = 1, Availability = "Free", HotelName = "Bob"},
            new AvailableRoomModel { RoomId = guidRoom2, RoomNumber = 2, Availability = "Free" }
        };

        _roomRepositoryMock
            .Setup(repo => repo.GetAvailableRoomsAsync())
            .ReturnsAsync(availableRooms);
        
        // Act
        var result = await _roomService.GetAvailableRoomsAsync(sieveModel);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(1, result[0]?.RoomNumber);

        _roomRepositoryMock.Verify(repo => repo.GetAvailableRoomsAsync(), Times.Once);
    }

    [Fact]
    public async Task GetAvailableRoomsAsync_ShouldReturnEmptyList_WhenNoRoomsAvailable()
    {
        // Arrange
        var sieveModel = new AvailableRoomSieveModel
        {
            // Populate properties as needed
        };

        _roomRepositoryMock
            .Setup(repo => repo.GetAvailableRoomsAsync())
            .ReturnsAsync(new List<AvailableRoomModel?>());

        // Act
        var result = await _roomService.GetAvailableRoomsAsync(sieveModel);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);

        _roomRepositoryMock.Verify(repo => repo.GetAvailableRoomsAsync(), Times.Once);
    }
}
