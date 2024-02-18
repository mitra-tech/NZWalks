using NZWalksAPI.Models.Domains;

namespace NZWalksAPI.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
    }
}
