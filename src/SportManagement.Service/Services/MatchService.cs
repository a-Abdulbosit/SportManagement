using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportManagement.Data.IRepositories;
using SportManagement.Domain.Entities;
using SportManagement.Service.DTOs.Matches;
using SportManagement.Service.Exceptions;
using SportManagement.Service.Interfaces;

public class MatchService : IMatchInterface
{
    private readonly IMapper _mapper;
    private readonly IRepository<Match> _matchRepository;
    private readonly IRepository<Team> _teamRepository;

    public MatchService(
        IRepository<Match> matchRepository,
        IRepository<Team> teamRepository,
        IMapper mapper)
    {
        _mapper = mapper;
        _matchRepository = matchRepository;
        _teamRepository = teamRepository;
    }

    public async Task<MatchForResultDto> AddAsync(MatchForCreationDto dto)
    {
        var team1 = await _teamRepository.SelectByIdAsync(dto.Team1Id);
        var team2 = await _teamRepository.SelectByIdAsync(dto.Team2Id);

        if (team1 == null || team2 == null)
            throw new SportManagementException(404, "One or both teams not found!");

        var existingMatch = await _matchRepository.SelectAll()
            .FirstOrDefaultAsync(m => m.Team1Id == dto.Team1Id && m.Team2Id == dto.Team2Id);

        if (existingMatch != null)
            throw new SportManagementException(409, "This match already exists!");

        var newMatch = _mapper.Map<Match>(dto);
        await _matchRepository.InsertAsync(newMatch);

        return _mapper.Map<MatchForResultDto>(newMatch);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var match = await _matchRepository.SelectByIdAsync(id);
        if (match == null)
            throw new SportManagementException(404, "Match not found!");

        await _matchRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<MatchForResultDto>> GetAllAsync()
    {
        var matches = await _matchRepository.SelectAll()
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<MatchForResultDto>>(matches);
    }

    public async Task<MatchForResultDto> GetByIdAsync(int id)
    {
        var match = await _matchRepository.SelectAll()
            .FirstOrDefaultAsync(m => m.Id == id);

        if (match == null)
            throw new SportManagementException(404, "Match not found!");

        return _mapper.Map<MatchForResultDto>(match);
    }

    public async Task<MatchForResultDto> ModifyAsync(int id, MatchForUpdateDto dto)
    {
        var match = await _matchRepository.SelectByIdAsync(id);
        if (match == null)
            throw new SportManagementException(404, "Match not found!");

        var team1 = await _teamRepository.SelectByIdAsync(dto.Team1Id);
        var team2 = await _teamRepository.SelectByIdAsync(dto.Team2Id);

        if (team1 == null || team2 == null)
                throw new SportManagementException(404, "One or both teams not found!");

        var updatedMatch = _mapper.Map(dto, match);
        await _matchRepository.UpdateAsync(updatedMatch);

        return _mapper.Map<MatchForResultDto>(updatedMatch);
    }
}
