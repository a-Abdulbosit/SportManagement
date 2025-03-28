using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportManagement.Data.IRepositories;
using SportManagement.Domain.Entities;
using SportManagement.Service.DTOs.Teams;
using SportManagement.Service.Exceptions;
using SportManagement.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TeamService : ITeamInterface
{
    private readonly IMapper _mapper;
    private readonly IRepository<Team> _teamRepository;

    public TeamService(IRepository<Team> teamRepository, IMapper mapper)
    {
        _teamRepository = teamRepository;
        _mapper = mapper;
    }

    public async Task<TeamForResultDto> AddAsync(TeamForCreationDto dto)
    {
        var existingTeam = await _teamRepository.SelectAll()
            .FirstOrDefaultAsync(t => t.TeamName == dto.TeamName);

        if (existingTeam != null)
            throw new SportManagementException(409, "This team already exists!");

        var newTeam = _mapper.Map<Team>(dto);
        await _teamRepository.InsertAsync(newTeam);

        return _mapper.Map<TeamForResultDto>(newTeam);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var team = await _teamRepository.SelectByIdAsync(id);
        if (team == null)
            throw new SportManagementException(404, "Team not found!");

        await _teamRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<TeamForResultDto>> GetAllAsync()
    {
        var teams = await _teamRepository.SelectAll()
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<TeamForResultDto>>(teams);
    }

    public async Task<TeamForResultDto> GetByIdAsync(int id)
    {
        var team = await _teamRepository.SelectAll()
            .FirstOrDefaultAsync(t => t.Id == id);

        if (team == null)
            throw new SportManagementException(404, "Team not found!");

        return _mapper.Map<TeamForResultDto>(team);
    }

    public async Task<TeamForResultDto> ModifyAsync(int id, TeamForUpdateDto dto)
    {
        var team = await _teamRepository.SelectByIdAsync(id);
        if (team == null)
            throw new SportManagementException(404, "Team not found!");

        var existingTeam = await _teamRepository.SelectAll()
            .FirstOrDefaultAsync(t => t.TeamName == dto.TeamName);

        if (existingTeam != null)
            throw new SportManagementException(409, "A team with this name already exists!");

        var updatedTeam = _mapper.Map(dto, team);
        await _teamRepository.UpdateAsync(updatedTeam);

        return _mapper.Map<TeamForResultDto>(updatedTeam);
    }
}
