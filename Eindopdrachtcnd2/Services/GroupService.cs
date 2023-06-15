using CampaingControlCenterAPI.Services;
using Eindopdrachtcnd2.Data;
using Eindopdrachtcnd2.Data.Entities;
using Eindopdrachtcnd2.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eindopdrachtcnd2.Services
{
    public interface IGroupService
    {
        Task<BaseServiceResult<IEnumerable<GroupDTO>>> GetGroupsAsync();
        Task<BaseServiceResult<GroupDTO>> GetGroupAsync(int id);
        Task<BaseServiceResult<GroupDTO>> CreateGroupAsync(GroupDTO groupDTO);
        Task<BaseServiceResult<GroupDTO>> UpdateGroupAsync(int id, GroupDTO groupDTO);
        Task<BaseServiceResult<bool>> DeleteGroupAsync(int id);
    }

    public class GroupService : IGroupService
    {
        private readonly ApplicationDbContext _db;

        public GroupService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<BaseServiceResult<IEnumerable<GroupDTO>>> GetGroupsAsync()
        {
            return await BaseServiceResult<IEnumerable<GroupDTO>>.TryCatch(async () =>
            {
                var groups = await _db.Groups
                    .Select(g => new GroupDTO() { Id = g.Id, Name = g.Name, Description = g.Description })
                    .ToListAsync();

                return groups;
            });
        }

        public async Task<BaseServiceResult<GroupDTO>> GetGroupAsync(int id)
        {
            return await BaseServiceResult<GroupDTO>.TryCatch(async () =>
            {
                var group = await _db.Groups
                    .Where(g => g.Id == id)
                    .Select(g => new GroupDTO() { Id = g.Id, Name = g.Name, Description = g.Description })
                    .FirstOrDefaultAsync();

                if (group == null)
                {
                    throw new Exception("Group not found");
                }

                return group;
            });
        }

        public async Task<BaseServiceResult<GroupDTO>> CreateGroupAsync(GroupDTO groupDTO)
        {
            return await BaseServiceResult<GroupDTO>.TryCatch(async () =>
            {
                // Check if the group already exists
                if (await _db.Groups.AnyAsync(g => g.Name.ToLower() == groupDTO.Name.ToLower()))
                {
                    throw new Exception("Group already exists");
                }

                var group = new Group { Name = groupDTO.Name, Description = groupDTO.Description };

                _db.Groups.Add(group);
                await _db.SaveChangesAsync();

                groupDTO.Id = group.Id;

                return groupDTO;
            });
        }

        public async Task<BaseServiceResult<GroupDTO>> UpdateGroupAsync(int id, GroupDTO groupDTO)
        {
            return await BaseServiceResult<GroupDTO>.TryCatch(async () =>
            {
                var group = await _db.Groups.FindAsync(id);
                if (group == null)
                {
                    throw new Exception("Group not found");
                }

                group.Name = groupDTO.Name;
                group.Description = groupDTO.Description;

                await _db.SaveChangesAsync();

                return groupDTO;
            });
        }

        public async Task<BaseServiceResult<bool>> DeleteGroupAsync(int id)
        {
            return await BaseServiceResult<bool>.TryCatch(async () =>
            {
                var group = await _db.Groups.FindAsync(id);
                if (group == null)
                {
                    throw new Exception("Group not found");
                }

                _db.Groups.Remove(group);
                await _db.SaveChangesAsync();

                return true;
            });
        }
    }
}
