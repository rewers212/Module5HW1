using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module5HW1.Services;

namespace Module5HW1
{
    public class Startup
    {
        public async Task Run()
        {
            var usersClient = new UsersClient();
            var getUsers = await usersClient.GetUsers(2);
            var getuser = await usersClient.GetUser(2);
            var userNotFound = await usersClient.GetUser(30);
            var listResource = await usersClient.GetUnknownResource();
            var singleResource = await usersClient.GetResource(2);
            var singleResourceNotFound = await usersClient.GetResource(23);
            var create = await usersClient.CreateUser("morpheus", "leader");
            var update = await usersClient.UpdateUser(2, "morpheus", "zion resident");
            var patchUpdate = await usersClient.PatchUpdateUser(2, "morpheus", "zion resident");
            await usersClient.DeleteUser(2);
            var registerSuccessfull = await usersClient.UserRegister("eve.holt@reqres.in", "pistol");
            var registerUnsuccessfull = await usersClient.UserRegister("sydney@fife", null);
            var loginSuccessful = await usersClient.Login("eve.holt@reqres.in", "cityslicka");
            var loginUnsuccessful = await usersClient.Login("peter@klaven", null);
            var delayedResponse = await usersClient.GetDelay(3);
        }
    }
}
