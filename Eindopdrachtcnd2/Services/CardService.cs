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
    public interface ICardService
    {
        //Task<BaseServiceResult<IEnumerable<CardDTO>>> GetCardsAsync();
        //Task<BaseServiceResult<CardDTO>> GetCardAsync(int id);
        //Task<BaseServiceResult<CardDTO>> CreateCardAsync(CardDTO cardDTO);
        //Task<BaseServiceResult<CardDTO>> UpdateCardAsync(int id, CardDTO cardDTO);
        //Task<BaseServiceResult<bool>> DeleteCardAsync(int id);
    }

    public class CardService : ICardService
    {
        private readonly ApplicationDbContext _db;

        public CardService(ApplicationDbContext db)
        {
            _db = db;
        }

        //public async Task<BaseServiceResult<IEnumerable<CardDTO>>> GetCardsAsync()
        //{
        //    return await BaseServiceResult<IEnumerable<CardDTO>>.TryCatch(async () =>
        //    {
        //        var cards = await _db.Cards
        //            .Select(c => new CardDTO()
        //            {
        //                Id = c.Id,
        //                Name = c.Name,
        //                Description = c.Description,
        //                Status = c.Status,
        //                Deadline = c.Deadline,
        //                GroupId = c.GroupId
        //            })
        //            .ToListAsync();

        //        return cards;
        //    });
        //}

        //public async Task<BaseServiceResult<CardDTO>> GetCardAsync(int id)
        //{
        //    return await BaseServiceResult<CardDTO>.TryCatch(async () =>
        //    {
        //        var card = await _db.Cards
        //            .Where(c => c.Id == id)
        //            .Select(c => new CardDTO()
        //            {
        //                Id = c.Id,
        //                Name = c.Name,
        //                Description = c.Description,
        //                Status = c.Status,
        //                Deadline = c.Deadline,
        //                GroupId = c.GroupId
        //            })
        //            .FirstOrDefaultAsync();

        //        if (card == null)
        //        {
        //            throw new Exception("Card not found");
        //        }

        //        return card;
        //    });
        //}

        //public async Task<BaseServiceResult<CardDTO>> CreateCardAsync(CardDTO cardDTO)
        //{
        //    return await BaseServiceResult<CardDTO>.TryCatch(async () =>
        //    {
        //        // Check if the card already exists
        //        if (await _db.Cards.AnyAsync(c => c.Name.ToLower() == cardDTO.Name.ToLower()))
        //        {
        //            throw new Exception("Card already exists");
        //        }

        //        var card = new Card
        //        {
        //            Name = cardDTO.Name,
        //            Description = cardDTO.Description,
        //            Status = cardDTO.Status,
        //            Deadline = cardDTO.Deadline,
        //            GroupId = cardDTO.GroupId
        //        };

        //        _db.Cards.Add(card);
        //        await _db.SaveChangesAsync();

        //        cardDTO.Id = card.Id;

        //        return cardDTO;
        //    });
        //}

        //public async Task<BaseServiceResult<CardDTO>> UpdateCardAsync(int id, CardDTO cardDTO)
        //{
        //    return await BaseServiceResult<CardDTO>.TryCatch(async () =>
        //    {
        //        var card = await _db.Cards.FindAsync(id);
        //        if (card == null)
        //        {
        //            throw new Exception("Card not found");
        //        }

        //        card.Name = cardDTO.Name;
        //        card.Description = cardDTO.Description;
        //        card.Status = cardDTO.Status;
        //        card.Deadline = cardDTO.Deadline;
        //        card.GroupId = cardDTO.GroupId;

        //        await _db.SaveChangesAsync();

        //        return cardDTO;
        //    });
        //}

        //public async Task<BaseServiceResult<bool>> DeleteCardAsync(int id)
        //{
        //    return await BaseServiceResult<bool>.TryCatch(async () =>
        //    {
        //        var card = await _db.Cards.FindAsync(id);
        //        if (card == null)
        //        {
        //            throw new Exception("Card not found");
        //        }

        //        _db.Cards.Remove(card);
        //        await _db.SaveChangesAsync();

        //        return true;
        //    });
        //}
    }
}
