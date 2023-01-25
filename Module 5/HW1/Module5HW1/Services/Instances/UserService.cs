using Microsoft.Extensions.Options;
using Module5HW1.Config;
using Module5HW1.DTOs;
using Module5HW1.DTOs.Requests;
using Module5HW1.DTOs.Responses;
using Module5HW1.Services.Abstractions;

namespace Module5HW1.Services.Instances
{
    public class UserService : IUserService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ApiOption _options;

        public UserService(IHttpClientService httpClientService, IOptions<ApiOption> options)
        {
            _httpClientService = httpClientService;
            _options = options.Value;
        }

        public async Task<AddUserResponse> AddUser(string name, string job)
        {
            var result = await _httpClientService.SendAsync<AddUserResponse, UserRequest>(
                $"{_options.UserHost}",
                HttpMethod.Post,
                new UserRequest()
                {
                    Name = name,
                    Job = job
                });

            if (result == null)
            {
                throw new Exception($"Unfortunately, user {name} was not created");
            }

            return result;
        }

        public async Task DeleteUser(int id)
        {
            await _httpClientService.SendAsync<object, object>($"{_options.UserHost}{id}", HttpMethod.Delete);
        }

        public async Task<UserDTO> GetUser(int id)
        {
            var result = await _httpClientService.SendAsync<SingleDataResponse<UserDTO>, object>($"{_options.UserHost}{id}", HttpMethod.Get);

            if (result == null || result.Data == null)
            {
                throw new Exception($"User with id = {id} was not found");
            }

            return result.Data;
        }

        public async Task<IList<UserDTO>> GetUsers(int page)
        {
            var result = await _httpClientService.SendAsync<PageResponse<UserDTO>, object>($"{_options.UserHost}?page={page}", HttpMethod.Get);

            if (result == null || result.Data == null)
            {
                throw new Exception("No data was found");
            }

            return result.Data;
        }

        public async Task<IList<UserDTO>> GetUsersDelayed(int delay)
        {
            var result = await _httpClientService.SendAsync<PageResponse<UserDTO>, object>($"{_options.UserHost}?delay={delay}", HttpMethod.Get);

            if (result == null || result.Data == null)
            {
                throw new Exception("No data was found");
            }

            return result.Data;
        }

        public async Task<UpdateUserResponse> UpdateUser(int id, string name, string job)
        {
            var result = await _httpClientService.SendAsync<UpdateUserResponse, UserRequest>(
                $"{_options.UserHost}{id}",
                HttpMethod.Put,
                new UserRequest()
                {
                    Name = name,
                    Job = job
                });

            if (result == null)
            {
                throw new Exception($"User with id = {id} was not updated");
            }

            return result;
        }

        public async Task<UpdateUserResponse> ModifyUser(int id, string name, string job)
        {
            var result = await _httpClientService.SendAsync<UpdateUserResponse, UserRequest>(
                $"{_options.UserHost}{id}",
                HttpMethod.Patch,
                new UserRequest()
                {
                    Name = name,
                    Job = job
                });

            if (result == null)
            {
                throw new Exception($"User with id = {id} was not updated");
            }

            return result;
        }
    }
}
