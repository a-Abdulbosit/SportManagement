using Microsoft.AspNetCore.Mvc;
using SportManagement.Service.DTOs.Matches;
using SportManagement.Service.Interfaces;

namespace SportManagementApi.Controllers
{
    public class MatchController : BaseController
    {
        private readonly IMatchInterface matchService;

        public MatchController(IMatchInterface matchService)
        {
            this.matchService = matchService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var matches = await matchService.GetAllAsync();
            return Ok(matches);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var match = await matchService.GetByIdAsync(Id);

            return Ok(match);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await matchService.DeleteAsync(id);
            
            return NoContent(); 
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] MatchForCreationDto dto)
        {
            var match = await matchService.AddAsync(dto);
            return Ok(match);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] MatchForUpdateDto dto,[FromRoute] int Id)
        {
            var match = await matchService.ModifyAsync(Id, dto);
            return Ok(match);
        }
    }
}
