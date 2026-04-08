using Application.DTOs.Profile;
using Application.UseCase.Auth;
using Domain;
using Infrastructure;
using Moq;

namespace Application.UnitTests.UseCase.Auth;

public class GetProfileUseCaseTest
{
    private Mock<IUserEFService> _userEFServiceMock = null!;
    private GetProfileUseCase _sut = null!;
    
    [SetUp]
    public void Setup()
    {
        _userEFServiceMock = new Mock<IUserEFService>();
        _sut = new GetProfileUseCase(_userEFServiceMock.Object);
    }

    [Test]
    public async Task ExecuteShouldReturnUserProfileWhenUserExists()
    {
        Guid testUserId = Guid.NewGuid();
        
        _userEFServiceMock
            .Setup(x => x.GetUserById(testUserId))
            .Returns(new UserEntity(testUserId, "john.doe", "test@Test.com", "password")
         );
        
        GetUserResponse response = await _sut.Execute(testUserId);  
        
        Assert.IsNotNull(response);
        Assert.That(response.Username, Is.EqualTo("john.doe"));
        _userEFServiceMock.Verify(userEfService => userEfService.GetUserById(testUserId), Times.Once);
        Assert.Pass();
    }

    [Test]
    public void ExecuteShouldThrowExceptionWhenUserDoesNotExist()
    {
        Guid testUserId = Guid.NewGuid();
        _userEFServiceMock
            .Setup(userEFService => userEFService.GetUserById(testUserId))
            .Returns((UserEntity?)null);
        
        Assert.ThrowsAsync<KeyNotFoundException>(async () => await _sut.Execute(testUserId));
    }
}