using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;



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

        [HttpGet(Name = "RobotSpotted")]
        public string Get() // returns a string instead of IEnumerable<WeatherForecast> 
            // This project will mainly use post because it useres sending and returning data.
            // I can experiment with siplay previous history of data
        {
            return "test";
        }

        [HttpPost(Name = "RobotSpotted")]
        public async Task<string> Post(Location location) // create a loaction class
        {
            _logger.Log(LogLevel.Information, new EventId(),null,"Finding the nearest ocean to" + location.Name,null); 
            //using the existing logger to record the event ( in this case posting the name)
             //var x = await _service.GetNearestBodyOfWater(location);
            if (location.Longitude >= 125) 
            {
                return $"The nearest body of water to {location.Name} is {Listx.Listx.locationList.First(x => x.Longitude >= 125).Name}";

            }
            else return $"The nearest body of water to {location.Name} is {Listx.Listx.locationList.First(x => x.Longitude < 125).Name}";
            ; // we can reference the name: loaction.Name
        }
    }
}