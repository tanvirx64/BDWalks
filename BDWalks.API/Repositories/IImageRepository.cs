using BDWalks.API.Models.Domain;

namespace BDWalks.API.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
