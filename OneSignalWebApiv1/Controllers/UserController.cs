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

        public UserController(OneSignalServiceGetUserInfo getuserInfo)
        {
            _getUserInfoService = getuserInfo;
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
            var oneSignalId = await _getUserInfoService.GetOneSignalIdByPlayerId(playerId);
            
            return Ok(oneSignalId);

        }


    }
}
