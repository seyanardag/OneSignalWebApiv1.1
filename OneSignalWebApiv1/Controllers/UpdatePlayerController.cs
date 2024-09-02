using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneSignalApi.Model;
using System.Collections.Generic;
using System.Diagnostics;
using OneSignalApi.Api;
using OneSignalApi.Client;
using OneSignalApi.Model;


//player bilgisini alabilirken player güncellemede sıkıntı yapıyor, playerId geçersiz diyor
namespace OneSignalWebApiv1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatePlayerController : ControllerBase
    {
        [HttpGet("UpdatePlayer")]
        public async Task<IActionResult> UpdatePlayer(string playerId)
        {
            Configuration config = new Configuration();
            config.BasePath = "https://onesignal.com/api/v1";
            // Configure Bearer token for authorization: app_key
            config.AccessToken = "N2Q5ZmYxNzgtYzEwZi00ZGM3LTliNDYtMzAzZTE1OTEyM2Iy";

            var apiInstance = new DefaultApi(config);
            var player = new Player(); // Player | 

            player.Playtime = 111111111;

            try
            {
                var res = await apiInstance.GetPlayerAsync("1af6fc63-a7de-4ccc-8f67-7a6a2a14bd65", playerId);
                UpdatePlayerSuccessResponse result = await apiInstance.UpdatePlayerAsync(playerId, player);
                // Edit device

                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DefaultApi.UpdatePlayer: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }




            return Ok();
        }


        //ExternalId sinin ayarlanmış olması gerekiyor
        //https://github.com/OneSignal/onesignal-dotnet-api/blob/main/docs/DefaultApi.md#UpdatePlayerTags
        [HttpGet("UpdatePlayerTagsByExternalUserId")]
        public async Task<IActionResult> UpdatePlayerTags()
        {

            Configuration config = new Configuration();
            config.BasePath = "https://onesignal.com/api/v1";
            // Configure Bearer token for authorization: app_key
            config.AccessToken = "N2Q5ZmYxNzgtYzEwZi00ZGM3LTliNDYtMzAzZTE1OTEyM2Iy";

            var apiInstance = new DefaultApi(config);
            var appId = "1af6fc63-a7de-4ccc-8f67-7a6a2a14bd65";  // string | The OneSignal App ID the user record is found under.
            var externalUserId = "c84d34af-6ca8-40d3-a9e7-ecd2424e4f3a";  // string | The External User ID mapped to teh device record in OneSignal.  Must be actively set on the device to be updated.
            var updatePlayerTagsRequestBody = new UpdatePlayerTagsRequestBody()
            {
                Tags = new Dictionary<string, string>
                {
                    { "email", "deneme2@gmail.com" }
                }
            }; // UpdatePlayerTagsRequestBody |  (optional) 

      
            try
            {
                // Edit tags with external user id
                UpdatePlayerTagsSuccessResponse result = apiInstance.UpdatePlayerTags(appId, externalUserId, updatePlayerTagsRequestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DefaultApi.UpdatePlayerTags: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }

            return Ok();

        }
    }
}
