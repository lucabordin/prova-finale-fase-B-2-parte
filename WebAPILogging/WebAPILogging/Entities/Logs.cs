using System.ComponentModel.DataAnnotations;

namespace WebAPILogging.Entities
{
    public class Logs
    {
        [Key]
        public int idLog { get; set; }
        [Required]
        public string Messaggio { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        public string EndpointUrl { get; set; }
    }
}
