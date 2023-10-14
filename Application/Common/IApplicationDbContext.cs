using System.Data;

namespace Application.Common;

public interface IApplicationDbContext
{
    IDbConnection CreateConnection();
}