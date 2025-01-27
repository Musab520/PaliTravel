
using Domain.IRepository;
using Domain.Service;
using Domain.SieveModel;
using Moq;

namespace Test;

public class RoomServiceTests
{
    private readonly Mock<IRoomRepository> _roomRepositoryMock;
    private readonly RoomService _roomService;

    public RoomServiceTests()
    {
        _roomRepositoryMock = new Mock<IRoomRepository>();
        _roomService = new RoomService(_roomRepositoryMock.Object);
    }

    [Fact]
    public async Task GetAvailableRoomsAsync_ShouldReturnAvailableRooms()
    {
        // Arrange
        var sieveModel = new Sieve.Models.SieveModel
        {
            Page = 1,
            PageSize = 10
        };

        var availableRooms = new List<AvailableRoomModel?>
        {
            new AvailableRoomModel { RoomNumber = 1},
            new AvailableRoomModel { RoomNumber = 2}
        };

        _roomRepositoryMock
            .Setup(repo => repo.GetAvailableRoomsAsync(sieveModel))
            .ReturnsAsync(availableRooms);

        // Act
        var result = await _roomService.GetAvailableRoomsAsync(sieveModel);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal(1, result[0]?.RoomNumber);
        Assert.Equal(2, result[1]?.RoomNumber);

        _roomRepositoryMock.Verify(repo => repo.GetAvailableRoomsAsync(sieveModel), Times.Once);
    }
}