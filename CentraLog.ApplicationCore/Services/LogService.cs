using CentraLog.ApplicationCore.Entities;
using CentraLog.ApplicationCore.Interfaces.Services;
using CentraLog.ApplicationCore.Repositories;
using CentraLog.ApplicationCore.Services.Common;


namespace CentraLog.ApplicationCore.Services
{
    public class LogService : BaseService<LogAplicacaoEntity>, ILogService
    {
        private readonly ILogRepository _repository;

        public LogService(ILogRepository repository) : base(repository)
        {
            this._repository = repository;
        }

    }
}
