using CleanArc.Domain.Entities.Card;

namespace CleanArc.Application.Contracts.Persistence
{
    public interface ICardRepository
    {
        Task AddCardAsync(BusinessCard card);
        Task<List<BusinessCard>> GetAllUserCardsAsync(int userId);
        Task<List<BusinessCard>> GetAllCardsWithRelatedUserAsync();
        Task<BusinessCard> GetUserCardByIdAndUserIdAsync(int userId, int cardId, bool trackEntity);
        Task DeleteUserCardsAsync(int cardId);
        Task<int> CountUserCardsAsync(int userId);
    }
}
