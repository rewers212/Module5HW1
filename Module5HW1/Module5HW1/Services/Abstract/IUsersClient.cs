using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module5HW1.Models;

namespace Module5HW1.Services.Abstract
{
    public interface IUsersClient
    {
        public Task<PageInfo<User>> GetUsers(int page);
        public Task<DataInfo<User>> GetUser(int id);
        public Task<PageInfo<Resource>> GetUnknownResource();
        public Task<DataInfo<Resource>> GetResource(int id);
        public Task<CreateUser> CreateUser(string name, string job);
        public Task<CreateUser> UpdateUser(int id, string name, string job);
        public Task<CreateUser> PatchUpdateUser(int id, string name, string job);
        public Task<UserSecurity> UserRegister(string email, string password);
        public Task<UserSecurity> Login(string email, string password);
        public Task<PageInfo<User>> GetDelay(int delay);
        public Task DeleteUser(int id);
    }
}
