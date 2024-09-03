using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
namespace OneSignalWebApiv1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ViewDevice ()
        {

            var AppId = "1af6fc63-a7de-4ccc-8f67-7a6a2a14bd65";
            var RestApiKey = "N2Q5ZmYxNzgtYzEwZi00ZGM3LTliNDYtMzAzZTE1OTEyM2Iy";


            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://onesignal.com/api/v1/players?app_id={AppId}&limit=200&offset=0"),
                Headers =
                        {
                            { "accept", "application/json" },
                            { "Authorization", "Basic N2Q5ZmYxNzgtYzEwZi00ZGM3LTliNDYtMzAzZTE1OTEyM2Iy" },
                        },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return Ok(body);
            }

            
        }

    }
}
