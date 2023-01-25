using Module5HW1.DTOs.Responses;

namespace Module5HW1.Services.Abstractions
{
    public interface IRegisterService
    {
        Task<RegisterResponse> Register(string email, string password);
    }
}
