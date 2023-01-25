using Module5HW1.DTOs;

namespace Module5HW1.Services.Abstractions
{
    public interface IResourceService
    {
        Task<IList<ResourceDTO>> GetResources(int page);
        Task<ResourceDTO> GetResource(int id);
    }
}
