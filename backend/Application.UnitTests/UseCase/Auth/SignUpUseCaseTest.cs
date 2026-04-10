using Application.DTOs.Auth.Requests;
using Application.UseCase.Auth;
using Domain;
using Infrastructure;
using Moq;

namespace Application.UnitTests.UseCase.Auth;

[TestFixture]
public class SignUpUseCaseTest
{
    private Mock<IUserEFService> _userEfServiceMock = null!;
    private Mock<IPasswordService> _passwordServiceMock = null!;
    private SignUpUseCase _signUpUseCase = null!;

    private const string DefaultUsername = "john.doe";
    private const string DefaultEmail = "john@doe.com";
    private const string DefaultPassword = "password123";

    [SetUp]
    public void Setup()
    {
        _userEfServiceMock = new Mock<IUserEFService>();
        _passwordServiceMock = new Mock<IPasswordService>();
        _signUpUseCase = new SignUpUseCase(_userEfServiceMock.Object, _passwordServiceMock.Object);
    }

    [Test]
    public async Task ExecuteShouldReturnUserProfileWhenUserExists()
    {
        SignUpRequest request = new SignUpRequest
        {
            Username = DefaultUsername,
            Email = DefaultEmail,
            Password = DefaultPassword,
        };
        const string hashedPassword = "hashedPassword";

        _userEfServiceMock.Setup(userEfServiceMock => userEfServiceMock.AddUserAsync(It.Is<UserEntity>(u =>
                u.Username == request.Username &&
                u.Email == request.Email &&
                u.Password == hashedPassword)))
            .Returns(Task.CompletedTask);
        _passwordServiceMock.Setup(passwordServiceMock => passwordServiceMock.Hash(request.Password))
            .Returns(hashedPassword);

        (bool IsSuccess, string? Error) result = await _signUpUseCase.ExecuteAsync(request);

        Assert.IsTrue(result.IsSuccess);
        Assert.IsNull(result.Error);
        _passwordServiceMock.Verify(x => x.Hash(request.Password), Times.Once);
        _userEfServiceMock.Verify(x => x.AddUserAsync(It.IsAny<UserEntity>()), Times.Once);
    }

    [Test]
    public async Task ExecuteShouldReturnErrorWhenEmailAlreadyExists()
    {
        SignUpRequest request = new SignUpRequest
        {
            Username = DefaultUsername,
            Email = DefaultEmail,
            Password = DefaultPassword,
        };
        _userEfServiceMock.Setup(userEfServiceMock => userEfServiceMock.ExistsByEmailAsync(request.Email))
            .ReturnsAsync(true);

        (bool IsSuccess, string? Error) result = await _signUpUseCase.ExecuteAsync(request);

        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual("this email is already registered.", result.Error);
        _userEfServiceMock.Verify(x => x.ExistsByEmailAsync(request.Email), Times.Once);
        _userEfServiceMock.Verify(x => x.AddUserAsync(It.IsAny<UserEntity>()), Times.Never);
        _passwordServiceMock.Verify(x => x.Hash(DefaultPassword), Times.Never);
    }

    [Test]
    public async Task ExecuteAsyncShouldReturnErrorWhenRequestIsNull()
    {
        (bool IsSuccess, string? Error) result = await _signUpUseCase.ExecuteAsync(null!);

        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Error, Is.EqualTo("Request is invalid."));

        _passwordServiceMock.Verify(x => x.Hash(It.IsAny<string>()), Times.Never);
        _userEfServiceMock.Verify(x => x.AddUserAsync(It.IsAny<UserEntity>()), Times.Never);
        _userEfServiceMock.Verify(x => x.ExistsByEmailAsync(It.IsAny<string>()), Times.Never);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public async Task ExecuteAsyncShouldReturnErrorWhenUsernameIsMissing(string? username)
    {
        SignUpRequest request = new SignUpRequest
        {
            Username = username!,
            Email = DefaultEmail,
            Password = DefaultPassword
        };

        (bool IsSuccess, string? Error) result = await _signUpUseCase.ExecuteAsync(request);

        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Error, Is.EqualTo("username is required."));

        _passwordServiceMock.Verify(x => x.Hash(It.IsAny<string>()), Times.Never);
        _userEfServiceMock.Verify(x => x.AddUserAsync(It.IsAny<UserEntity>()), Times.Never);
        _userEfServiceMock.Verify(x => x.ExistsByEmailAsync(It.IsAny<string>()), Times.Never);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("not-an-email")]
    public async Task ExecuteAsyncShouldReturnErrorWhenEmailIsInvalid(string? email)
    {
        SignUpRequest request = new SignUpRequest
        {
            Username = DefaultUsername,
            Email = email!,
            Password = DefaultPassword
        };

        (bool IsSuccess, string? Error) result = await _signUpUseCase.ExecuteAsync(request);

        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Error, Is.EqualTo("email is invalid."));

        _passwordServiceMock.Verify(x => x.Hash(It.IsAny<string>()), Times.Never);
        _userEfServiceMock.Verify(x => x.AddUserAsync(It.IsAny<UserEntity>()), Times.Never);
        _userEfServiceMock.Verify(x => x.ExistsByEmailAsync(It.IsAny<string>()), Times.Never);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("1234567")]
    public async Task ExecuteAsyncShouldReturnErrorWhenPasswordIsTooShort(string? password)
    {
        SignUpRequest request = new SignUpRequest
        {
            Username = DefaultUsername,
            Email = DefaultEmail,
            Password = password!
        };

        (bool IsSuccess, string? Error) result = await _signUpUseCase.ExecuteAsync(request);

        Assert.That(result.IsSuccess, Is.False);
        Assert.That(
            result.Error,
            Is.EqualTo("the password should have at least " + SignUpUseCase.MinPasswordLength + " characters.")
        );

        _passwordServiceMock.Verify(x => x.Hash(It.IsAny<string>()), Times.Never);
        _userEfServiceMock.Verify(x => x.AddUserAsync(It.IsAny<UserEntity>()), Times.Never);
        _userEfServiceMock.Verify(x => x.ExistsByEmailAsync(It.IsAny<string>()), Times.Never);
    }
}