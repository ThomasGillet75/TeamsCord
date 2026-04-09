using Application.UseCase.Auth;
using Infrastructure;
using Moq;

namespace Application.UnitTests.UseCase.Auth;

[TestFixture]
public class SignUpUseCaseTest
{
    
    private Mock<IUserEFService> _userEFServiceMock = null!;
    private SignUpUseCase _sut = null!;

    [SetUp]
    public void Setup()
    {
        _userEFServiceMock = new Mock<IUserEFService>();
    }


    [Test]
    public async Task ExecuteShouldReturnUserProfileWhenUserExists()
    {
        
    }
}