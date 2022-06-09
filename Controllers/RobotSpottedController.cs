using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using System.Text.Json;



namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]

 
    public class RobotSpottedController : ControllerBase
    {
        private readonly ILogger<RobotSpottedController> _logger;
        private readonly LocationService _service; // what is dependecy injection 
      
        public RobotSpottedController(LocationService service, ILogger<RobotSpottedController> logger) // add services to the constructor 
        {
            _service = service;
            _logger = logger;
        }

    

        [HttpPost(Name = "RobotSpotted")]
        public async Task<string> Post(Location location) // create a loaction class
        {
          
            _logger.Log(LogLevel.Information, new EventId(),null,"Finding the nearest ocean to" + location.Name, null); 
            //using the existing logger to record the event ( in this case posting the nam
            string NearestWater = await _service.GetNearestBodyOfWater(location);
            JsonSerializer.Serialize(NearestWater);
            CloseWaterLoaction[] ClosestWater = JsonSerializer.Deserialize<CloseWaterLoaction[]>(NearestWater);
            return $"The nearest body of water to {location.Name} is {ClosestWater[0].display_name}";

   
        }

    }
}