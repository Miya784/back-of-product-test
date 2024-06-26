using Microsoft.AspNetCore.Mvc;
using simpleWebApp.Models;

namespace simpleWebApp.controller
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Test")]
    public class simpleController : Controller
    {
        [HttpGet]
        [Route("hello")]
        public string Get()
        {
            return "Hello World!";
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Test")]
    public class TestApiController : ControllerBase
    {
        [HttpGet]
        [Route("test")]
        public IActionResult Get()
        {
            var data = new[]
                    {
            new DeviceDataSchedul { id = 1, client_id = 1, name = "test1", status = false, scheduler_active = true, started = System.DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") },
            new DeviceDataSchedul { id = 2, client_id = 2, name = "test2", status = true, scheduler_active = false, started = System.DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") },
            new DeviceDataSchedul { id = 3, client_id = 3, name = "test3", status = false, scheduler_active = true, started = System.DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") }
        };

            var OnlineSchedul = new OnlineSchedul
            {
                data = data.Where(d => d.status == true).ToArray(),
                count = data.Count(d => d.status == true)
            };

            var OfflineSchedul = new OfflineSchedul
            {
                data = data.Where(d => d.status == false).ToArray(),
                count = data.Count(d => d.status == false)
            };

            var activeSchedul = new ActiveSchedul
            {
                data = data.Where(d => d.scheduler_active == true).ToArray(),
                count = data.Count(d => d.scheduler_active == true)
            };

            var response = new
            {
                onlineSchedul = OnlineSchedul,
                offlineSchedul = OfflineSchedul,
                completed = activeSchedul
            };

            return Ok(response);
        }
    }
}