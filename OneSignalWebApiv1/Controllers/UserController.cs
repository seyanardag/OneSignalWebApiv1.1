using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OneSignalWebApiv1.Entities.OneSignalEntities;
using OneSignalWebApiv1.Services;
using System.Drawing.Text;
using System.Net.Http.Headers;
using System.Security.Policy;

namespace OneSignalWebApiv1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly OneSignalServiceGetUserInfo _getUserInfoService;
        private readonly OneSignalServiceCreateOrUpdatePlayer _getUserInfoServiceCreateOrUpdatePlayer;

        public UserController(OneSignalServiceGetUserInfo getUserInfoService, OneSignalServiceCreateOrUpdatePlayer getUserInfoServiceCreateOrUpdatePlayer)
        {
            _getUserInfoService = getUserInfoService;
            _getUserInfoServiceCreateOrUpdatePlayer = getUserInfoServiceCreateOrUpdatePlayer;
        }


        //OneSignalID kullanarak kayıtlı user bilgilerini getirme
        [HttpGet("OneSignalIDileUserInfoGetir")]
        public async Task<IActionResult> GetUser(string oneSignalID)
        {            
            var oneSignalUserInfo = await _getUserInfoService.GetUser(oneSignalID);
            if (oneSignalUserInfo == null)
            {
                return BadRequest("Hata;kullanıcı bulunamadı");
            } else
            {
                return Ok(oneSignalUserInfo);                      
            }

        }



        //https://documentation.onesignal.com/reference/fetch-identity-by-subscription
        [HttpGet("PlayerIddenOneSignalIdGetir")]
        public async Task<IActionResult> ViewUserIdentity(string playerId)
        {
            if (playerId == null) return NotFound();
            var oneSignalId = await _getUserInfoService.GetOneSignalIdByPlayerId(playerId);
            
            return Ok(oneSignalId);

        }

        [HttpPost("playerOlusturVeyaGuncelle")]
        public async Task<string> OneSignalServiceCreateOrUpdatePlayer (string email, string phoneNumber)
        {
            var result = await _getUserInfoServiceCreateOrUpdatePlayer.CreateOrUpdatePlayerAsync(email, phoneNumber);

            return result;
        }






    }
}
