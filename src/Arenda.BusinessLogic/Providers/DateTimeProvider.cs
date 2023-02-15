using Arenda.BusinessLogic.Contracts.Providers;

namespace Arenda.BusinessLogic.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
