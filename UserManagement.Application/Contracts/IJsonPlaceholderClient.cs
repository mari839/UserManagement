using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Services.Models;

namespace UserManagement.Application.Contracts
{
    public interface IJsonPlaceholderClient
    {
        Task<List<Post>> GetPostsByUserIdAsync(int userId);
        Task<List<Comment>> GetCommentsByUserIdAsync(int userId);
        Task<List<Photo>> GetPhotosByUserIdAsync(int userId);
        Task<List<Todo>> GetTodosByUserIdAsync(int userId);
        
    }
}
