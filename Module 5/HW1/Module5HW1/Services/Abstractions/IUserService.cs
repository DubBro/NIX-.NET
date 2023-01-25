using Module5HW1.DTOs;
using Module5HW1.DTOs.Responses;

namespace Module5HW1.Services.Abstractions
{
    public interface IUserService
    {
        Task<IList<UserDTO>> GetUsers(int page);
        Task<IList<UserDTO>> GetUsersDelayed(int delay);
        Task<UserDTO> GetUser(int id);
        Task<AddUserResponse> AddUser(string name, string job);
        Task<UpdateUserResponse> UpdateUser(int id, string name, string job);
        Task<UpdateUserResponse> ModifyUser(int id, string name, string job);
        Task DeleteUser(int id);
    }
}
