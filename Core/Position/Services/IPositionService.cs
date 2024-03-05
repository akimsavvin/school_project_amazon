using Amazon.Core.Position.Dto;
using Amazon.Core.Position.Models;

namespace Amazon.Core.Position.Services;

public interface IPositionService
{
    public Task<IEnumerable<PositionModel>> GetAllAsync();
    public Task<PositionModel> GetOneAsync(Guid id);
    public Task<PositionModel> CreateAsync(CreatePositionDto createPositionDto);
    public Task DeleteByIdAsync(Guid id);
}
