using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using Newtonsoft.Json;
using WebAPILogging.DTO;
using WebAPILogging.Entities;
using WebAPILogging.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPILogging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private ILogService _service;
        public LogController(ILogService service)
        {
            _service = service;
        }
        // GET: api/<LogController>
        [HttpGet]
        public async Task<ActionResult<List<Logs>>> Get([FromBody] DateTime dataInizio, DateTime dataFine)// la mia idea qui era di fare un dto contenente le date perchè cosi non funzioma ma non ho fatto in tempo
        {
            try
            {
                return await _service.trovaLogsDate(dataInizio, dataFine);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // GET api/<LogController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LogController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] string stringa)
        {
            logDto log = JsonConvert.DeserializeObject<logDto>(stringa);
            await _service.postLog(log);
            return Ok();
        }

        // PUT api/<LogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
