using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetUserEmail(string email);
        Task<User> GetUserById(int id);
        Task<User> GetUserByIdIncludeUserProfile(int id);
        Task<List<User>> GetAllUsers();
        Task<List<User>> GetAllUsersIncludeUserProfile();

        //Task<UserProfile> GetUserProfileById(int id);
        //Task<List<UserProfile>> GetUserProfiles();

        Task<int> UpdateUserProfileAsync(User user);
        Task<User> AddUserAsync(User user);
        void DeleteUserAsync(int id);
        //Task<int> CreateUser(User user);
    }
}
