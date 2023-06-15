using CampaingControlCenterAPI.Services;
using Eindopdrachtcnd2.Data;
using Eindopdrachtcnd2.Data.Entities;
using Eindopdrachtcnd2.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Eindopdrachtcnd2.Services
{
    public interface ICardUserService
    {
        Task<BaseServiceResult<CardUserDTO>> AddUserToCardAsync(CardUserDTO cardUserDTO);
        Task<BaseServiceResult<bool>> RemoveUserFromCardAsync(CardUserDTO cardUserDTO);
    }

    public class CardUserService : ICardUserService
    {
        private readonly ApplicationDbContext _db;

        public CardUserService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<BaseServiceResult<CardUserDTO>> AddUserToCardAsync(CardUserDTO cardUserDTO)
        {
            return await BaseServiceResult<CardUserDTO>.TryCatch(async () =>
            {
                // Check if the User exists
                var user = await _db.Users.FindAsync(cardUserDTO.UserId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }

                // Check if the Card exists
                var card = await _db.Cards.FindAsync(cardUserDTO.CardId);
                if (card == null)
                {
                    throw new Exception("Card not found");
                }

                // Check if the User is already assigned to the Card
                var existingCardUser = await _db.CardUsers.FindAsync(cardUserDTO.CardId, cardUserDTO.UserId);
                if (existingCardUser != null)
                {
                    throw new Exception("User is already assigned to the Card");
                }

                var newCardUser = new CardUser
                {
                    CardId = cardUserDTO.CardId,
                    UserId = cardUserDTO.UserId
                };

                _db.CardUsers.Add(newCardUser);
                await _db.SaveChangesAsync();

                return cardUserDTO;
            });
        }

        public async Task<BaseServiceResult<bool>> RemoveUserFromCardAsync(CardUserDTO cardUserDTO)
        {
            return await BaseServiceResult<bool>.TryCatch(async () =>
            {
                // Check if the User exists
                var user = await _db.Users.FindAsync(cardUserDTO.UserId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }

                // Check if the Card exists
                var card = await _db.Cards.FindAsync(cardUserDTO.CardId);
                if (card == null)
                {
                    throw new Exception("Card not found");
                }

                // Check if the User is assigned to the Card
                var existingCardUser = await _db.CardUsers.FindAsync(cardUserDTO.CardId, cardUserDTO.UserId);
                if (existingCardUser == null)
                {
                    throw new Exception("User is not assigned to the Card");
                }

                _db.CardUsers.Remove(existingCardUser);
                await _db.SaveChangesAsync();

                return true;
            });
        }
    }
}
