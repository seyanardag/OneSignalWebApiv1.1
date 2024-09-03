using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OneSignalWebApiv1.Services;
using System.Net.Http.Headers;

namespace OneSignalWebApiv1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendNotifByEmailController : ControllerBase
    {
        private readonly OneSignalServiceSendByEmail _oneSignalServiceSendByEmail;
        public SendNotifByEmailController(OneSignalServiceSendByEmail oneSignalServiceSendByEmail)
        {
            _oneSignalServiceSendByEmail = oneSignalServiceSendByEmail;
        }

        [HttpGet("SendByEmail")]
        public async Task<IActionResult> SendByEmail (string heading, string message, string email)
        {
            var result = await _oneSignalServiceSendByEmail.SendByEmailAsync(heading, message, email);
            if (result.IsNullOrEmpty()) return Ok("Bildirim gönderilecek cihaz bulunamadı");
            return Ok($"bildirim Id si:{result}");
        }

        [HttpPost("SendByEmailMULTIPLE")]
        public async Task<IActionResult> SendByEmailMULTIPLE(string heading, string message, string email1, string email2)
        {
            var list = new List<string>()
            {
                email1, email2
            };
            var SentNotifs = new List<string>();
            foreach (var item in list)
            {
                var result = await _oneSignalServiceSendByEmail.SendByEmailAsync(heading, message, item);
                SentNotifs.Add(result);
            }


            if (SentNotifs.IsNullOrEmpty()) return Ok("Bildirim gönderilecek cihaz bulunamadı");
            return Ok($"bildirim Id si:{SentNotifs[0]} **** {SentNotifs[1]}");
        }


        [HttpPost("SendByEmailMULTIPLE_LIST")]
        public async Task<IActionResult> SendByEmailMULTIPLE(string heading, string message, List<string> emailList )
        {
            
            var SentNotifs = new List<string>();
            foreach (var item in emailList)
            {
                var result = await _oneSignalServiceSendByEmail.SendByEmailAsync(heading, message, item);
                SentNotifs.Add(result);
            }


            if (SentNotifs.IsNullOrEmpty()) return Ok("Bildirim gönderilecek cihaz bulunamadı");
            //return Ok($"bildirim Id si:{SendNotifs[0]} **** {SendNotifs[1]}");
            return Ok(SentNotifs);
        }




    }
}
