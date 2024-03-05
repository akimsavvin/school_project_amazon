using Amazon.Core.Position.Models;

namespace Amazon.Core.Position.Storage;

public interface IPositionRepository
{
    public Task<IEnumerable<PositionModel>> GetAllAsync();
    public Task<PositionModel> GetOneAsync(Guid id);
    public Task InsertAsync(PositionModel position);
    public Task DeleteAsync(PositionModel position);
}
