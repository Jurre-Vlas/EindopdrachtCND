using CampaingControlCenterAPI.Services;
using Eindopdrachtcnd2.Data;
using Eindopdrachtcnd2.Data.Entities;
using Eindopdrachtcnd2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eindopdrachtcnd2.Services
{
    public interface IUserService
    {
        //Task<BaseServiceResult<IEnumerable<UserDTO>>> GetUsersAsync();
        ////Task<BaseServiceResult<UserDTO>> GetUserAsync(int id);
        //Task<BaseServiceResult<UserDTO>> CreateUserAsync(UserDTO userDTO);
        //Task<BaseServiceResult<UserDTO>> UpdateUserAsync(int id, UserDTO userDTO);
        //Task<BaseServiceResult<bool>> DeleteUserAsync(int id);
    }

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;

        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }

        //public async Task<BaseServiceResult<IEnumerable<UserDTO>>> GetUsersAsync()
        //{
        //    return await BaseServiceResult<IEnumerable<UserDTO>>.TryCatch(async () =>
        //    {
        //        var users = await _db.Users
        //            .Select(u => new UserDTO() { Id = u.Id, Name = u.Name })
        //            .ToListAsync();

        //        return users;
        //    });
        //}

        //public async Task<BaseServiceResult<UserDTO>> GetUserAsync(int id)
        //{
        //    return await BaseServiceResult<UserDTO>.TryCatch(async () =>
        //    {
        //        var user = await _db.Users
        //            .Where(u => u.Id == id)
        //            .Select(u => new UserDTO() { Id = u.Id, Name = u.Name })
        //            .FirstOrDefaultAsync();

        //        if (user == null)
        //        {
        //            throw new Exception("User not found");
        //        }

        //        return user;
        //    });
        //}

        //public async Task<BaseServiceResult<UserDTO>> CreateUserAsync(UserDTO userDTO)
        //{
        //    return await BaseServiceResult<UserDTO>.TryCatch(async () =>
        //    {
        //        // Check if the user already exists
        //        if (await _db.Users.AnyAsync(u => u.Name.ToLower() == userDTO.Name.ToLower()))
        //        {
        //            throw new Exception("User already exists");
        //        }

        //        var user = new User { Name = userDTO.Name };

        //        _db.Users.Add(user);
        //        await _db.SaveChangesAsync();

        //        userDTO.Id = user.Id;

        //        return userDTO;
        //    });
        //}

        //public async Task<BaseServiceResult<UserDTO>> UpdateUserAsync(int id, UserDTO userDTO)
        //{
        //    return await BaseServiceResult<UserDTO>.TryCatch(async () =>
        //    {
        //        var user = await _db.Users.FindAsync(id);
        //        if (user == null)
        //        {
        //            throw new Exception("User not found");
        //        }

        //        user.Name = userDTO.Name;

        //        await _db.SaveChangesAsync();

        //        return userDTO;
        //    });
        //}

        //public async Task<BaseServiceResult<bool>> DeleteUserAsync(int id)
        //{
        //    return await BaseServiceResult<bool>.TryCatch(async () =>
        //    {
        //        var user = await _db.Users.FindAsync(id);
        //        if (user == null)
        //        {
        //            throw new Exception("User not found");
        //        }

        //        _db.Users.Remove(user);
        //        await _db.SaveChangesAsync();

        //        return true;
        //    });
        //}
    }
}
