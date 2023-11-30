using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Contracts;
using UserManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace UserManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _userDbContext;
        public UserRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _userDbContext.User.Where(x => x.UserId == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _userDbContext.User.OrderBy(u => u.UserId).ToListAsync();
            return users;
        }
        public async Task<List<User>> GetAllUsersIncludeUserProfile()
        {
            var users = await _userDbContext.User.Include(p=> p.UserProfile).OrderBy(u => u.UserId).ToListAsync();
            return users;
        }
        public async Task<User> AddUserAsync(User user)
        {
            var result = await _userDbContext.User.AddAsync(user);
            await _userDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> UpdateUserProfileAsync(User user)
        {
            var existingUser = await _userDbContext.User.Include(u=> u.UserProfile).FirstOrDefaultAsync(u=>u.UserId == user.UserId);

            if(existingUser != null)
            {
                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;
                existingUser.Email = user.Email;
                existingUser.UserProfile.FirstName = user.UserProfile.FirstName;
                existingUser.UserProfile.LastName = user.UserProfile.LastName;
                existingUser.UserProfile.PersonalNumber = user.UserProfile.PersonalNumber;
                await _userDbContext.SaveChangesAsync();
            }
            return existingUser.UserId;
        }

        public async void DeleteUserAsync(int id)
        {
            var user = _userDbContext.User.Include(u => u.UserProfile).FirstOrDefault(u => u.UserId == id);
            if(user != null)
            {
                _userDbContext.User.Remove(user);
                await _userDbContext.SaveChangesAsync();
            }
        }


        public async Task<UserProfile> GetUserProfileById(int id)
        {
            var user = await _userDbContext.User.Where(x => x.UserId == id).FirstOrDefaultAsync() !=null ? _userDbContext.User.Where(u => u.UserId == id).Select(u => u.UserProfile).FirstOrDefault() : throw new NullReferenceException();
            return user; 
        }

        public async Task<List<UserProfile>> GetUserProfiles()
        {
            var userProfiles = await _userDbContext.UserProfile.OrderBy(u => u.UserProfileId).ToListAsync();
            return userProfiles;
        }

        public async Task<int> CreateUser(User user)
        {
            await _userDbContext.User.AddAsync(user);
            await _userDbContext.SaveChangesAsync();
            return user.UserId;
        }
    }
}
