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
    public interface ICardTaskService
    {
        //Task<BaseServiceResult<IEnumerable<CardTaskDTO>>> GetCardTasksAsync();
        //Task<BaseServiceResult<CardTaskDTO>> GetCardTaskAsync(int id);
        //Task<BaseServiceResult<CardTaskDTO>> CreateCardTaskAsync(CardTaskDTO cardTaskDTO);
        //Task<BaseServiceResult<CardTaskDTO>> UpdateCardTaskAsync(int id, CardTaskDTO cardTaskDTO);
        //Task<BaseServiceResult<bool>> DeleteCardTaskAsync(int id);
    }

    public class CardTaskService : ICardTaskService
    {
        private readonly ApplicationDbContext _db;

        public CardTaskService(ApplicationDbContext db)
        {
            _db = db;
        }

        //public async Task<BaseServiceResult<IEnumerable<CardTaskDTO>>> GetCardTasksAsync()
        //{
        //    return await BaseServiceResult<IEnumerable<CardTaskDTO>>.TryCatch(async () =>
        //    {
        //        var cardTasks = await _db.CardTasks
        //            .Select(ct => new CardTaskDTO
        //            {
        //                Id = ct.Id,
        //                Name = ct.Name,
        //                Description = ct.Description,
        //                Status = ct.Status,
        //                CardId = ct.CardId
        //            })
        //            .ToListAsync();

        //        return cardTasks;
        //    });
        //}

        //public async Task<BaseServiceResult<CardTaskDTO>> GetCardTaskAsync(int id)
        //{
        //    return await BaseServiceResult<CardTaskDTO>.TryCatch(async () =>
        //    {
        //        var cardTask = await _db.CardTasks
        //            .Where(ct => ct.Id == id)
        //            .Select(ct => new CardTaskDTO
        //            {
        //                Id = ct.Id,
        //                Name = ct.Name,
        //                Description = ct.Description,
        //                Status = ct.Status,
        //                CardId = ct.CardId
        //            })
        //            .FirstOrDefaultAsync();

        //        if (cardTask == null)
        //        {
        //            throw new Exception("CardTask not found");
        //        }

        //        return cardTask;
        //    });
        //}

        //public async Task<BaseServiceResult<CardTaskDTO>> CreateCardTaskAsync(CardTaskDTO cardTaskDTO)
        //{
        //    return await BaseServiceResult<CardTaskDTO>.TryCatch(async () =>
        //    {
        //        // Check if the associated Card exists
        //        if (!await _db.Cards.AnyAsync(c => c.Id == cardTaskDTO.CardId))
        //        {
        //            throw new Exception("Associated Card not found");
        //        }

        //        var cardTask = new CardTask
        //        {
        //            Name = cardTaskDTO.Name,
        //            Description = cardTaskDTO.Description,
        //            Status = cardTaskDTO.Status,
        //            CardId = cardTaskDTO.CardId
        //        };

        //        _db.CardTasks.Add(cardTask);
        //        await _db.SaveChangesAsync();

        //        cardTaskDTO.Id = cardTask.Id;

        //        return cardTaskDTO;
        //    });
        //}

        //public async Task<BaseServiceResult<CardTaskDTO>> UpdateCardTaskAsync(int id, CardTaskDTO cardTaskDTO)
        //{
        //    return await BaseServiceResult<CardTaskDTO>.TryCatch(async () =>
        //    {
        //        var cardTask = await _db.CardTasks.FindAsync(id);
        //        if (cardTask == null)
        //        {
        //            throw new Exception("CardTask not found");
        //        }

        //        // Check if the associated Card exists
        //        if (!await _db.Cards.AnyAsync(c => c.Id == cardTaskDTO.CardId))
        //        {
        //            throw new Exception("Associated Card not found");
        //        }

        //        cardTask.Name = cardTaskDTO.Name;
        //        cardTask.Description = cardTaskDTO.Description;
        //        cardTask.Status = cardTaskDTO.Status;
        //        cardTask.CardId = cardTaskDTO.CardId;

        //        await _db.SaveChangesAsync();

        //        return cardTaskDTO;
        //    });
        //}

        //public async Task<BaseServiceResult<bool>> DeleteCardTaskAsync(int id)
        //{
        //    return await BaseServiceResult<bool>.TryCatch(async () =>
        //    {
        //        var cardTask = await _db.CardTasks.FindAsync(id);
        //        if (cardTask == null)
        //        {
        //            throw new Exception("CardTask not found");
        //        }

        //        _db.CardTasks.Remove(cardTask);
        //        await _db.SaveChangesAsync();

        //        return true;
        //    });
        //}
    }
}
