using AeroTicketing.Common.Application.Clock;

namespace AeroTicketing.Common.Infrastructure.Clock;
internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
