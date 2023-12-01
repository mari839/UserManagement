using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UserManagement.Application.Contracts;
using UserManagement.Application.Services.Models;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Services.JsonPlaceHolder
{
    public class JsonPlaceholderClient : IJsonPlaceholderClient
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://jsonplaceholder.typicode.com/";

        public JsonPlaceholderClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Post>> GetPostsByUserIdAsync(int userId)
        {
            string endpoint = $"posts?userId={userId}";
            return await GetAsync<List<Post>>(endpoint);
        }

        public async Task<List<Comment>> GetCommentsByUserIdAsync(int userId)
        {
            string endpoint = $"comments?userId={userId}";
            return await GetAsync<List<Comment>>(endpoint);
        }

        public async Task<List<Photo>> GetPhotosByUserIdAsync(int userId)
        {
            string endpoint = $"photos?userId={userId}";
            return await GetAsync<List<Photo>>(endpoint);
        }

        public async Task<List<Todo>> GetTodosByUserIdAsync(int userId)
        {
            string endpoint = $"todos?userId={userId}";
            return await GetAsync<List<Todo>>(endpoint);
        }

        private async Task<T> GetAsync<T>(string endpoint)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{BaseUrl}{endpoint}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }

            throw new Exception($"Error: {response.StatusCode}");
        }
    }
}
