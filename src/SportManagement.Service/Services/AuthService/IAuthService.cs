public interface IAuthService
    {
        Task<LoginResultDto> AuthentificateAsync(LoginDto dto);
    }