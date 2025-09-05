using System.Data.Common;

namespace AeroTicketing.Common.Application.Data;
public interface IDbConnectionFactory
{
    ValueTask<DbConnection> OpenConnectionAsync();
}
