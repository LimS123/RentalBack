namespace Arenda.DataAccess.Contracts
{
    public interface IDataContext
    {
        Task SaveChanges(CancellationToken token);
    }
}
