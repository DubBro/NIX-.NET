using Basket.Host.Models.Requests;
using Basket.Host.Models.Responses;

namespace Basket.Host.Services.Interfaces
{
    public interface IBasketService
    {
        Task<AddItemResponse<int?>> AddItemToCatalogAsync(CreateProductRequest request);
    }
}
