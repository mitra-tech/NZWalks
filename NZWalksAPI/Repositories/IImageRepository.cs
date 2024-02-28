using NZWalksAPI.Models.Domains;

namespace NZWalksAPI.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
