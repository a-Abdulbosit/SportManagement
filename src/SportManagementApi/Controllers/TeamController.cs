using Microsoft.AspNetCore.Mvc;
using SportManagement.Service.DTOs.Teams;
using SportManagement.Service.Interfaces;

namespace SportManagementApi.Controllers
{
    public class TeamController : BaseController
    {
        private readonly ITeamInterface teamService;

        public TeamController(ITeamInterface teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var teams = await teamService.GetAllAsync();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var team = await teamService.GetByIdAsync(id);
            return Ok(team);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await teamService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] TeamForCreationDto dto)
        {
            var team = await teamService.AddAsync(dto);
            return Ok(team);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] TeamForUpdateDto dto, [FromRoute] int id)
        {
            var team = await teamService.ModifyAsync(id, dto);
            return Ok(team);
        }
    }
}
