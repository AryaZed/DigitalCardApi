using CleanArc.Application.Contracts.Persistence;
using CleanArc.Domain.Entities.Card;
using CleanArc.Domain.Entities.Order;
using CleanArc.Infrastructure.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace CleanArc.Infrastructure.Persistence.Repositories
{
    internal class CardRepository(ApplicationDbContext dbContext) : BaseAsyncRepository<BusinessCard>(dbContext), ICardRepository
    {
        public async Task AddCardAsync(BusinessCard card)
        {
            await base.AddAsync(card);
        }

        public async Task<List<BusinessCard>> GetAllUserCardsAsync(int userId)
        {
            return await base.TableNoTracking
                .Include(i => i.User)
                .Include(i => i.CustomFields)
                .Include(i => i.ContactOptions)
                .Include(i => i.SocialMediaLinks)
                .Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task<List<BusinessCard>> GetAllCardsWithRelatedUserAsync()
        {
            var cards = await base.TableNoTracking.Include(c => c.User).ToListAsync();

            return cards;
        }

        public async Task<BusinessCard> GetUserCardByIdAndUserIdAsync(int userId, int cardId, bool trackEntity)
        {
            var card = await base.TableNoTracking.FirstOrDefaultAsync(c => c.UserId == userId && c.Id == cardId);

            if (card is not null && trackEntity)
                base.DbContext.Attach(card);

            return card;
        }

        public async Task DeleteUserCardsAsync(int userId)
        {
            await UpdateAsync(c => c.UserId == userId, p => p.SetProperty(card => card.IsDeleted, true));
        }

        public async Task<int> CountUserCardsAsync(int userId)
        {
            return await base.TableNoTracking.CountAsync(c => c.UserId == userId);
        }
    }
}
