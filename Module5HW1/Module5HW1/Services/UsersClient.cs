using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Module5HW1.Models;
using Module5HW1.Services.Abstract;
using Newtonsoft.Json;

namespace Module5HW1.Services
{
    public class UsersClient : IUsersClient
    {
        private HttpClient _client = new HttpClient();
        public async Task<CreateUser> CreateUser(string name, string job)
        {
            var url = $"https://reqres.in/api/users";
            var content = JsonConvert.SerializeObject(new { Name = name, Job = job });
            var data = await GetJson(url, HttpMethod.Post, content);

            var user = JsonConvert.DeserializeObject<CreateUser>(data);

            return user;
        }

        public async Task<CreateUser> UpdateUser(int id, string name, string job)
        {
            var url = $"https://reqres.in/api/users/{id}";
            var content = JsonConvert.SerializeObject(new { Name = name, Job = job });
            var data = await GetJson(url, HttpMethod.Put, content);

            var user = JsonConvert.DeserializeObject<CreateUser>(data);

            return user;
        }

        public async Task<CreateUser> PatchUpdateUser(int id, string name, string job)
        {
            var url = $"https://reqres.in/api/users/{id}";
            var content = JsonConvert.SerializeObject(new { Name = name, Job = job });
            var data = await GetJson(url, HttpMethod.Patch, content);

            var user = JsonConvert.DeserializeObject<CreateUser>(data);

            return user;
        }

        public async Task<UserSecurity> UserRegister(string email, string password)
        {
            var url = $"https://reqres.in/api/register";
            var content = JsonConvert.SerializeObject(new { Email = email, Password = password });
            var data = await GetJson(url, HttpMethod.Post, content);

            var user = JsonConvert.DeserializeObject<UserSecurity>(data);

            return user;
        }

        public async Task<UserSecurity> Login(string email, string password)
        {
            var url = $"https://reqres.in/api/login";
            var content = JsonConvert.SerializeObject(new { Email = email, Password = password });
            var data = await GetJson(url, HttpMethod.Post, content);

            var registerUser = JsonConvert.DeserializeObject<UserSecurity>(data);

            return registerUser;
        }

        public async Task<PageInfo<User>> GetDelay(int delay)
        {
            var url = $"https://reqres.in/api/users?delay={delay}";
            var data = await GetJson(url, HttpMethod.Get);
            var page = JsonConvert.DeserializeObject<PageInfo<User>>(data);

            return page;
        }

        public async Task DeleteUser(int id)
        {
            var url = $"https://reqres.in/api/users/{id}";
            await GetJson(url, HttpMethod.Delete);
        }

        public async Task<PageInfo<Resource>> GetUnknownResource()
        {
            var url = $"https://reqres.in/api/unknown";
            var data = await GetJson(url, HttpMethod.Get);

            var users = JsonConvert.DeserializeObject<PageInfo<Resource>>(data);

            return users;
        }

        public async Task<DataInfo<Resource>> GetResource(int id)
        {
            var url = $"https://reqres.in/api/unknown/{id}";
            var data = await GetJson(url, HttpMethod.Get);

            var user = JsonConvert.DeserializeObject<DataInfo<Resource>>(data);

            return user;
        }

        public async Task<DataInfo<User>> GetUser(int id)
        {
            var url = $"https://reqres.in/api/users/{id}";
            var data = await GetJson(url, HttpMethod.Get);

            var user = JsonConvert.DeserializeObject<DataInfo<User>>(data);

            return user;
        }

        public async Task<PageInfo<User>> GetUsers(int page)
        {
            var url = $"https://reqres.in/api/users?page={page}";
            var data = await GetJson(url, HttpMethod.Get);

            var users = JsonConvert.DeserializeObject<PageInfo<User>>(data);

            return users;
        }

        private async Task<string> GetJson(string url, HttpMethod methods, string content = null)
        {
            var method = methods;
            var uri = new Uri(url);
            var data = await CreateMessage(method, uri, content);
            return data;
        }

        private async Task<string> CreateMessage(HttpMethod methodType, Uri url, string content = null)
        {
            var message = new HttpRequestMessage();

            message.Method = methodType;
            message.RequestUri = url;
            message.Content = new StringContent(content);
            var response = await _client.SendAsync(message);
            var data = await response.Content.ReadAsStringAsync();

            return data;
        }
    }
}
