using Microsoft.AspNetCore.Mvc;
using SportManagement.Domain.Configurations.Pagination;
using SportManagement.Service.DTOs.Players;
using SportManagement.Service.Interfaces;

namespace SportManagementApi.Controllers
{
    public class PlayerController : BaseController
    {
        private readonly IPlayerInterface playerService;

        public PlayerController(IPlayerInterface playerService)
        {
            this.playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        {
            var players = await playerService.GetAllAsync(@params);
            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var player = await playerService.GetByIdAsync(id);
            return Ok(player);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await playerService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromForm] PlayerForCreationDto dto)
        {
            var player = await playerService.AddAsync(dto);
            return Ok(player);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromForm] PlayerForUpdateDto dto, [FromRoute] int id)
        {
            var player = await playerService.ModifyAsync(id, dto);
            return Ok(player);
        }
    }
}
