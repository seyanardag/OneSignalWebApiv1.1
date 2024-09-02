using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
namespace OneSignalWebApiv1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetSegmentsController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetSegments()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.onesignal.com/apps/1af6fc63-a7de-4ccc-8f67-7a6a2a14bd65/segments"),
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
