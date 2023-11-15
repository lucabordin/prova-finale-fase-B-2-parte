using System.ComponentModel.DataAnnotations;

namespace WebAPILogging.DTO
{
    public class logDto
    {
        public string Messaggio { get; set; }
        public DateTime Timestamp { get; set; }
        public string? EndpointUrl { get; set; }
    }
}
