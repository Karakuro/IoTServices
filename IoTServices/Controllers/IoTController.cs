using IoTServices.Data;
using IoTServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IoTServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IoTController : ControllerBase
    {
        private ILogger<IoTController> _logger;
        private IotDbContext _ctx;

        public IoTController(ILogger<IoTController> logger, IotDbContext dbContext)
        {
            _logger = logger;
            _ctx = dbContext;
        }

        [HttpPost]
        // POST https://localhost/api/iot
        public IActionResult PostData([FromBody]IoTDataModel data)
        {
            _logger.LogInformation($"Post chiamata - id: {data.Id}");
            IotData newData = new IotData()
            {
                IdDevice = data.Id,
                Temperatura = data.Temperatura,
                Altitudine = data.Altitudine,
                Pressione = data.Pressione,
                Umidita = data.Umidita,
                TimeStamp = DateTime.Now
            };
            _ctx.IotData.Add(newData);
            _ctx.SaveChanges();
            return Created("", null); //201
        }

        [HttpGet]
        public IActionResult GetData()
        {
            return Ok(_ctx.IotData.ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDataByDevice(int id)
        {
            return Ok(_ctx.IotData.Where(d => d.IdDevice == id).ToList());
        }

        /*
         * 1** => informativi
         * 2** => Risposta positiva 200 Ok, 201 Created, 204 No Content
         * 3** => Redirezione 301 redirect
         * 4** => Errore lato client
         * 5** => Errore lato server
         */
    }
}
