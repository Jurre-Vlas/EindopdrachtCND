using CampaingControlCenterAPI.Services;
using Eindopdrachtcnd2.Data;
using Eindopdrachtcnd2.Data.Entities;
using Eindopdrachtcnd2.Models;
using Eindopdrachtcnd2.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Eindopdrachtcnd2.Services
{
    public interface ICardTaskUserService
    {
        Task<BaseServiceResult<CardTaskUserDTO>> AddUserToCardTaskAsync(CardTaskUserDTO cardTaskUserDTO);
        Task<BaseServiceResult<bool>> RemoveUserFromCardTaskAsync(CardTaskUserDTO cardTaskUserDTO);
    }

    public class CardTaskUserService : ICardTaskUserService
    {
        private readonly ApplicationDbContext _db;

        public CardTaskUserService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<BaseServiceResult<CardTaskUserDTO>> AddUserToCardTaskAsync(CardTaskUserDTO cardTaskUserDTO)
        {
            return await BaseServiceResult<CardTaskUserDTO>.TryCatch(async () =>
            {
                // Check if the User exists
                var user = await _db.Users.FindAsync(cardTaskUserDTO.UserId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }

                // Check if the CardTask exists
                var cardTask = await _db.CardTasks.FindAsync(cardTaskUserDTO.CardTaskId);
                if (cardTask == null)
                {
                    throw new Exception("CardTask not found");
                }

                // Check if the User is already assigned to the CardTask
                var existingCardTaskUser = await _db.CardTaskUsers.FindAsync(cardTaskUserDTO.CardTaskId, cardTaskUserDTO.UserId);
                if (existingCardTaskUser != null)
                {
                    throw new Exception("User is already assigned to the CardTask");
                }

                var newCardTaskUser = new CardTaskUser
                {
                    CardTaskId = cardTaskUserDTO.CardTaskId,
                    UserId = cardTaskUserDTO.UserId
                };

                _db.CardTaskUsers.Add(newCardTaskUser);
                await _db.SaveChangesAsync();

                return cardTaskUserDTO;
            });
        }

        public async Task<BaseServiceResult<bool>> RemoveUserFromCardTaskAsync(CardTaskUserDTO cardTaskUserDTO)
        {
            return await BaseServiceResult<bool>.TryCatch(async () =>
            {
                // Check if the User exists
                var user = await _db.Users.FindAsync(cardTaskUserDTO.UserId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }

                // Check if the CardTask exists
                var cardTask = await _db.CardTasks.FindAsync(cardTaskUserDTO.CardTaskId);
                if (cardTask == null)
                {
                    throw new Exception("CardTask not found");
                }

                // Check if the User is assigned to the CardTask
                var existingCardTaskUser = await _db.CardTaskUsers.FindAsync(cardTaskUserDTO.CardTaskId, cardTaskUserDTO.UserId);
                if (existingCardTaskUser == null)
                {
                    throw new Exception("User is not assigned to the CardTask");
                }

                _db.CardTaskUsers.Remove(existingCardTaskUser);
                await _db.SaveChangesAsync();

                return true;
            });
        }
    }
}
