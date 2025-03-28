using SportManagement.Data.IRepositories;
using SportManagement.Domain.Entities;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;
    private readonly IRepository<User> _userRepository;
    public AuthService(ITokenService tokenService, IRepository<User> userRepository)
    {
        _tokenService = tokenService;
        _userRepository = userRepository;
    }
    public async Task<LoginResultDto> AuthentificateAsync(LoginDto dto)
    {
        var user = _userRepository.SelectAll().Where(x => x.Email == dto.Email && x.Password == dto.Password).FirstOrDefault();
        if (user is null)
            throw new Exception("Invalid Email or password");

        var newAccesToken = _tokenService.GenerateToken(user);
        var newRefreshToken = _tokenService.GenerateRefreshToken();

        var refreshTokenEntity = new RefreshToken
        {
            Token = newRefreshToken,
            ExpiryDate = DateTime.UtcNow.AddHours(2),
            UserId = user.Id,
        };
        return new LoginResultDto
        {
            AccessToken = newAccesToken,
            RefreshToken = newRefreshToken,
        };
    }
}