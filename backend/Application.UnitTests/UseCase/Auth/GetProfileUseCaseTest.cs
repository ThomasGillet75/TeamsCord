using Application.DTOs.Profile;
using Application.UseCase.Auth;
using Domain;
using Infrastructure;
using Moq;

namespace Application.UnitTests.UseCase.Auth;

public class GetProfileUseCaseTest
{
    private Mock<IUserEFService> _userEServiceMock = null!;
    private GetProfileUseCase _profileUseCase = null!;
    
    [SetUp]
    public void Setup()
    {
        _userEServiceMock = new Mock<IUserEFService>();
        _profileUseCase = new GetProfileUseCase(_userEServiceMock.Object);
    }

    [Test]
    public void ExecuteShouldReturnUserProfileWhenUserExists()
    {
        Guid testUserId = Guid.NewGuid();
        
        _userEServiceMock
            .Setup(userEfService => userEfService.GetUserById(testUserId))
            .Returns(new UserEntity(testUserId, "john.doe", "test@Test.com", "password")
         );
        
        GetUserResponse response = _profileUseCase.Execute(testUserId);  
        
        Assert.IsNotNull(response);
        Assert.That(response.Username, Is.EqualTo("john.doe"));
        _userEServiceMock.Verify(userEfService => userEfService.GetUserById(testUserId), Times.Once);
        Assert.Pass();
    }

    [Test]
    public void ExecuteShouldThrowExceptionWhenUserDoesNotExist()
    {
        Guid testUserId = Guid.NewGuid();
        _userEServiceMock
            .Setup(userEfService => userEfService.GetUserById(testUserId))
            .Returns((UserEntity?)null);
        
        Assert.Throws<KeyNotFoundException>(() => _profileUseCase.Execute(testUserId));
    }
}