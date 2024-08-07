namespace CleanArc.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        public IUserRefreshTokenRepository UserRefreshTokenRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public ICardRepository CardRepository { get; }
        Task CommitAsync();
        ValueTask RollBackAsync();
    }
}