using CampaingControlCenterAPI.Services;
using Eindopdrachtcnd2.Data;
using Eindopdrachtcnd2.Data.Entities;
using Eindopdrachtcnd2.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Eindopdrachtcnd2.Services
{
    public interface IGroupUserService
    {
        Task<BaseServiceResult<GroupUserDTO>> AddUserToGroupAsync(GroupUserDTO groupUserDTO);
        Task<BaseServiceResult<bool>> RemoveUserFromGroupAsync(GroupUserDTO groupUserDTO);
    }

    public class GroupUserService : IGroupUserService
    {
        private readonly ApplicationDbContext _db;

        public GroupUserService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<BaseServiceResult<GroupUserDTO>> AddUserToGroupAsync(GroupUserDTO groupUserDTO)
        {
            return await BaseServiceResult<GroupUserDTO>.TryCatch(async () =>
            {
                // Check if the User exists
                var user = await _db.Users.FindAsync(groupUserDTO.UserId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }

                // Check if the Group exists
                var group = await _db.Groups.FindAsync(groupUserDTO.GroupId);
                if (group == null)
                {
                    throw new Exception("Group not found");
                }

                // Check if the User is already in the Group
                var existingGroupUser = await _db.GroupUsers.FindAsync(groupUserDTO.UserId, groupUserDTO.GroupId);
                if (existingGroupUser != null)
                {
                    throw new Exception("User already belongs to the Group");
                }

                var newGroupUser = new GroupUser
                {
                    UserId = groupUserDTO.UserId,
                    GroupId = groupUserDTO.GroupId
                };

                _db.GroupUsers.Add(newGroupUser);
                await _db.SaveChangesAsync();

                return groupUserDTO;
            });
        }

        public async Task<BaseServiceResult<bool>> RemoveUserFromGroupAsync(GroupUserDTO groupUserDTO)
        {
            return await BaseServiceResult<bool>.TryCatch(async () =>
            {
                // Check if the User exists
                var user = await _db.Users.FindAsync(groupUserDTO.UserId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }

                // Check if the Group exists
                var group = await _db.Groups.FindAsync(groupUserDTO.GroupId);
                if (group == null)
                {
                    throw new Exception("Group not found");
                }

                // Check if the User is in the Group
                var existingGroupUser = await _db.GroupUsers.FindAsync(groupUserDTO.UserId, groupUserDTO.GroupId);
                if (existingGroupUser == null)
                {
                    throw new Exception("User does not belong to the Group");
                }

                _db.GroupUsers.Remove(existingGroupUser);
                await _db.SaveChangesAsync();

                return true;
            });
        }
    }
}
