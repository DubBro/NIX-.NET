using Module5HW1.DTOs.Responses;

namespace Module5HW1.Services.Abstractions
{
    public interface ILoginService
    {
        Task<LoginResponse> Login(string email, string password);
    }
}
