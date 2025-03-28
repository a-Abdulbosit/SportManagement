using Microsoft.AspNetCore.Mvc;
using SportManagementApi.Controllers;

public class AuthController : BaseController
{
    private readonly IAuthService service;

    public AuthController(IAuthService service)
    {
        this.service = service;
    }
    [HttpPost]
    public async Task<IActionResult> AuthentificateAsync(LoginDto dto)
    {
        var result = await service.AuthentificateAsync(dto);
        return Ok(result);
    }
}
