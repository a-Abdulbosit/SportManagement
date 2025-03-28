using Microsoft.AspNetCore.Mvc;
using SportManagement.Service.DTOs.Scores;
using SportManagement.Service.Interfaces;

namespace SportManagementApi.Controllers
{
    public class ScoreController : BaseController
    {
        private readonly IScoreInterFace scoreService;

        public ScoreController(IScoreInterFace scoreService)
        {
            this.scoreService = scoreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var scores = await scoreService.GetAllAsync();
            return Ok(scores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var score = await scoreService.GetByIdAsync(id);
            return Ok(score);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await scoreService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ScoreForCreationDto dto)
        {
            var score = await scoreService.AddAsync(dto);
            return Ok(score);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] ScoreForUpdateDto dto, [FromRoute] int id)
        {
            var score = await scoreService.ModifyAsync(id, dto);
            return Ok(score);
        }
    }
}
