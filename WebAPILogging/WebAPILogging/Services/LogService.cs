using Microsoft.EntityFrameworkCore;
using WebAPILogging.DTO;
using WebAPILogging.Entities;
using WebAPIProvaProgettoFinale.DataSource;

namespace WebAPILogging.Services
{
    public class LogService : ILogService
    {
        private LoggingDBContext _context;
        public LogService(LoggingDBContext context)
            => _context = context;
        public async Task<int> postLog(logDto log)
        {
            Logs logCompleto = new Logs()
            {
                Timestamp = log.Timestamp,
                EndpointUrl = log.EndpointUrl,
                Messaggio = log.Messaggio,
            };
            _context.Entry(logCompleto).State = EntityState.Added;
            //Logs log = JsonConvert.DeserializeObject<Logs>(logString);
            //if (log == null) throw new Exception("errore passato non valido");
            try
            {
                
                int numeroRecordsInseriti = await _context.SaveChangesAsync();
                if (numeroRecordsInseriti != 1)
                {
                    string messaggioErrore = "Operazione di inserimento non effettuata";
                    throw new Exception(messaggioErrore);
                }
                return numeroRecordsInseriti;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Logs>> trovaLogsDate(DateTime datainizio, DateTime datafine)
        {
            try
            {
                List<Logs> result = await _context.Logs.Where(l=>l.Timestamp < datainizio&&l.Timestamp>datafine).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
