using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;


namespace OneSignalWebApiv1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddUser5GptController : ControllerBase
    {
        public class OneSignalUser
        {
            public Identity identity { get; set; }
            public Properties properties { get; set; }
        }

        public class Identity
        {
            public string external_id { get; set; }
            public string onesignal_id { get; set; }
        }

        public class Properties
        {
            public string alias { get; set; }
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser()
        {
            var client = new HttpClient();

            var newUser = new OneSignalUser
            {
                identity = new Identity
                {
                    external_id = "user123", // Kullanıcı kimliği
                    onesignal_id = "0e7a7d3e-aa48-4faa-acdd-f09348fee33c"
                },
                properties = new Properties
                {
                    alias = "user_alias_123"
                }
            };

            var jsonUser = JsonConvert.SerializeObject(newUser);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.onesignal.com/apps/1af6fc63-a7de-4ccc-8f67-7a6a2a14bd65/users"),
                Headers =
                    {
                        { "accept", "application/json" },
                        { "Authorization", "Basic N2Q5ZmYxNzgtYzEwZi00ZGM3LTliNDYtMzAzZTE1OTEyM2Iy" }
                    },
                Content = new StringContent(jsonUser)
                {
                    Headers =
                        {
                            ContentType = new MediaTypeHeaderValue("application/json")
                        }
                }
            };

            try
            {
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }

            return Ok();
        }

    }
}
