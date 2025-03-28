using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SportManagement.Data.IRepositories;
using SportManagement.Domain.Configurations;
using SportManagement.Domain.Configurations.Pagination;
using SportManagement.Domain.Entities;
using SportManagement.Service.DTOs.Players;
using SportManagement.Service.Exceptions;
using SportManagement.Service.Interfaces;

namespace SportManagement.Service.Services
{
    public class PlayerService : IPlayerInterface
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Player> _playerRepository;
        private readonly IRepository<Team> _teamRepository;

        public PlayerService(
            IRepository<Player> playerRepository,
            IRepository<Team> teamRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
        }
        public async Task<PlayerForResultDto> AddAsync(PlayerForCreationDto dto)
        {
            var team = await _teamRepository.SelectByIdAsync(dto.TeamId);
            if (team == null)
                throw new SportManagementException(404, "Team not found!");

            var newPlayer = _mapper.Map<Player>(dto);
            newPlayer.Team = team;
            newPlayer.PhotoPath = await SaveFileAsync(dto.Photo);
            await _playerRepository.InsertAsync(newPlayer);

            return _mapper.Map<PlayerForResultDto>(newPlayer);
        }

        private async Task<string> SaveFileAsync(IFormFile file)
        {
            if (file == null)
                return null;

            string uploadsFolder = Path.Combine("wwwroot", "images");
            Directory.CreateDirectory(uploadsFolder);

            string fileName = $"{Guid.NewGuid()}_{file.FileName}";
            string filePath = Path.Combine(uploadsFolder, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return $"/images/{fileName}";
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var player = await _playerRepository.SelectByIdAsync(id);
            if (player == null)
                throw new SportManagementException(404, "Player not found!");

            await _playerRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<PlayerForResultDto>> GetAllAsync(PaginationParams @params)
        {
            var players = await _playerRepository.SelectAll()
                .ToPagedList(@params)
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<PlayerForResultDto>>(players);
        }

        public async Task<PlayerForResultDto> GetByIdAsync(int id)
        {
            var player = await _playerRepository.SelectAll()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (player == null)
                throw new SportManagementException(404, "Player not found!");

            return _mapper.Map<PlayerForResultDto>(player);
        }

        public async Task<PlayerForResultDto> ModifyAsync(int id, PlayerForUpdateDto dto)
        {
            var player = await _playerRepository.SelectByIdAsync(id);
            if (player == null)
                throw new SportManagementException(404, "Player not found!");

            var team = await _teamRepository.SelectByIdAsync(dto.TeamId);
            if (team == null)
                throw new SportManagementException(404, "Team not found!");

            var updatedPlayer = _mapper.Map(dto, player);
            updatedPlayer.PhotoPath = await SaveFileAsync(dto.Photo);
            await _playerRepository.UpdateAsync(updatedPlayer);

            return _mapper.Map<PlayerForResultDto>(updatedPlayer);
        }
    }
}
