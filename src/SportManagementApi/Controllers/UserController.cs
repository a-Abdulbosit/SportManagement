using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportManagement.Service.DTOs.Users;
using SportManagement.Service.Interfaces;
using SportManagementApi.Controllers;

namespace AstroPharm.Api.Controllers.Users
{
    public class UsersController : BaseController
    {
        private readonly IUserInterface _userService;

        public UsersController(IUserInterface userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.RetrieveAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            var user = await _userService.RetrieveByIdAsync(id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            await _userService.RemoveAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] UserForCreationDto user)
        {
            var createdUser = await _userService.AddAsync(user);
            return Ok(createdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] UserForUpdateDto user, [FromRoute] long id)
        {
            var updatedUser = await _userService.ModifyAsync(id, user);
            return Ok(updatedUser);
        }
    }
}
