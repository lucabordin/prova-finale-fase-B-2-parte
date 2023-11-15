using WebAPILogging.DTO;
using WebAPILogging.Entities;

namespace WebAPILogging.Services
{
    public interface ILogService
    {
        Task<int> postLog(logDto log);
        Task<List<Logs>> trovaLogsDate(DateTime datainizio, DateTime datafine);
    }
}
