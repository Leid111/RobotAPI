namespace WebApplication1.Services
{
    public class LocationService
    {
        private readonly HttpClient _httpClient;

        public LocationService(HttpClient client) 
        {
            _httpClient = client;
            client.DefaultRequestHeaders.Add("User-Agent", "C# App");

        }


        public async Task<string> GetNearestBodyOfWater(Location location) // make it async  
        {

            string url = $"https://nominatim.openstreetmap.org/search.php?q=water%20near%20{location.Name}%20Australia&polygon_geojson=1&format=jsonv2";
           HttpResponseMessage y = await _httpClient.GetAsync(url);

            return await y.Content.ReadAsStringAsync();
        }



    }


}
