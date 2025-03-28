using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportManagement.Data.IRepositories;
using SportManagement.Domain.Entities;
using SportManagement.Service.DTOs.Scores;
using SportManagement.Service.Exceptions;
using SportManagement.Service.Interfaces;

public class ScoreService : IScoreInterFace
{
    private readonly IMapper _mapper;
    private readonly IRepository<Score> _scoreRepository;
    private readonly IRepository<Player> _playerRepository;
    private readonly IRepository<Match> _matchRepository;

    public ScoreService(
        IRepository<Score> scoreRepository,
        IRepository<Player> playerRepository,
        IRepository<Match> matchRepository,
        IMapper mapper)
    {
        _mapper = mapper;
        _scoreRepository = scoreRepository;
        _playerRepository = playerRepository;
        _matchRepository = matchRepository;
    }

    public async Task<ScoreForResultDto> AddAsync(ScoreForCreationDto dto)
    {
        var player = await _playerRepository.SelectByIdAsync(dto.PlayerId);
        var match = await _matchRepository.SelectByIdAsync(dto.MatchId);

        if (player == null || match == null)
            throw new SportManagementException(404, "Player or Match not found!");

        var newScore = _mapper.Map<Score>(dto);
        await _scoreRepository.InsertAsync(newScore);

        return _mapper.Map<ScoreForResultDto>(newScore);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var score = await _scoreRepository.SelectByIdAsync(id);
        if (score == null)
            throw new SportManagementException(404, "Score not found!");

        await _scoreRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<ScoreForResultDto>> GetAllAsync()
    {
        var scores = await _scoreRepository.SelectAll()
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<ScoreForResultDto>>(scores);
    }

    public async Task<ScoreForResultDto> GetByIdAsync(int id)
    {
        var score = await _scoreRepository.SelectByIdAsync(id);
        if (score == null)
            throw new SportManagementException(404, "Score not found!");

        return _mapper.Map<ScoreForResultDto>(score);
    }

    public async Task<ScoreForResultDto> ModifyAsync(int id, ScoreForUpdateDto dto)
    {
        var score = await _scoreRepository.SelectByIdAsync(id);
        if (score == null)
            throw new SportManagementException(404, "Score not found!");

        var player = await _playerRepository.SelectByIdAsync(dto.PlayerId);
        var match = await _matchRepository.SelectByIdAsync(dto.MatchId);

        if (player == null || match == null)
            throw new SportManagementException(404, "Player or Match not found!");

        var updatedScore = _mapper.Map(dto, score);
        await _scoreRepository.UpdateAsync(updatedScore);

        return _mapper.Map<ScoreForResultDto>(updatedScore);
    }
}
