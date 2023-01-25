using Module5HW1.Services.Abstractions;

namespace Module5HW1
{
    public class App
    {
        private readonly IUserService _userService;
        private readonly ILoginService _loginService;
        private readonly IResourceService _resourceService;
        private readonly IRegisterService _registerService;

        public App(IUserService userService, ILoginService loginService, IResourceService resourceService, IRegisterService registerService)
        {
            _userService = userService;
            _loginService = loginService;
            _resourceService = resourceService;
            _registerService = registerService;
        }

        public async Task Start()
        {
            try
            {
                var userTask = Task.Run(async () => await _userService.GetUser(3));
                var usersTask = Task.Run(async () => await _userService.GetUsers(1));
                var usersDelayedTask = Task.Run(async () => await _userService.GetUsersDelayed(3));
                var addUserTask = Task.Run(async () => await _userService.AddUser("Carl", "king"));
                var updateUserTask = Task.Run(async () => await _userService.UpdateUser(1, "Clark", "imperator"));
                var modifyUserTask = Task.Run(async () => await _userService.ModifyUser(1, "Richard", "monarch"));
                var deleteUserTask = Task.Run(async () => await _userService.DeleteUser(1));
                var resourceTask = Task.Run(async () => await _resourceService.GetResource(3));
                var resourcesTask = Task.Run(async () => await _resourceService.GetResources(1));
                var registrationTask = Task.Run(async () => await _registerService.Register("eve.holt@reqres.in", "pistol"));
                var loginTask = Task.Run(async () => await _loginService.Login("eve.holt@reqres.in", "cityslicka"));

                await Task.WhenAll(
                    userTask,
                    usersTask,
                    usersDelayedTask,
                    addUserTask,
                    updateUserTask,
                    modifyUserTask,
                    deleteUserTask,
                    resourceTask,
                    resourcesTask,
                    registrationTask,
                    loginTask);

                var user = await userTask;
                var users = await usersTask;
                var usersDelayed = await usersDelayedTask;
                var addUser = await addUserTask;
                var updateUser = await updateUserTask;
                var modifyUser = await modifyUserTask;
                await deleteUserTask;
                var resource = await resourceTask;
                var resources = await resourcesTask;
                var registration = await registrationTask;
                var login = await loginTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
