using Amazon.Core.Position.Dto;
using Amazon.Core.Position.Models;
using Amazon.Core.Position.Storage;

namespace Amazon.Core.Position.Services;

public class PositionService(IPositionRepository positionRepository) : IPositionService
{
    private readonly IPositionRepository _positionRepository = positionRepository;

    public async Task<IEnumerable<PositionModel>> GetAllAsync()
    {
        return await _positionRepository.GetAllAsync();
    }

    public async Task<PositionModel> GetOneAsync(Guid id)
    {
        return await _positionRepository.GetOneAsync(id);
    }

    public async Task<PositionModel> CreateAsync(CreatePositionDto createPositionDto)
    {
        var position = new PositionModel(
            Guid.NewGuid(),
            createPositionDto.Name,
            createPositionDto.Description
        );

        await _positionRepository.InsertAsync(position);
        return position;
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var position = await _positionRepository.GetOneAsync(id);
        await _positionRepository.DeleteAsync(position);
    }
}
