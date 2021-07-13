
using CentralLog.Infrastructure.Context;
using CentralLog.Infrastructure.Repositories.Common;
using CentraLog.ApplicationCore.Entities;
using CentraLog.ApplicationCore.Repositories;


namespace CentralLog.Infrastructure.Repositories
{
    public class LogRepository : BaseRepository<LogAplicacaoEntity>, ILogRepository
    {
        public LogRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
