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
            

            HttpResponseMessage y = await _httpClient.GetAsync("https://nominatim.openstreetmap.org/reverse?format=json&lat=-32&lon=151.2082848");

            return await y.Content.ReadAsStringAsync();
        }



    }


}
