namespace Arenda.BusinessLogic.Contracts.Providers
{
    public interface IDateTimeProvider
    {
        DateTime NowUtc { get; }
    }
}
