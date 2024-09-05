using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneSignalWebApiv1.Services;

namespace OneSignalWebApiv1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakeNotifReadController : ControllerBase
    {
        private readonly OneSignalServiceOK _oneSignalServiceOK;

        public MakeNotifReadController(OneSignalServiceOK oneSignalServiceOK)
        {
            _oneSignalServiceOK = oneSignalServiceOK;
        }

        [HttpGet("Index")]
        public IActionResult Index(string studentGUID, string tableName, string tableGUID)
        {
            


            return Ok();    
        }

        [HttpGet]
        public IActionResult Trigger(string ogrenciGUID, string tabloadı, string tablodakiGUID)
        {
            var PLAYERS = new List<string>() { "67c6fa31-dbb0-4ff4-a630-59f576d81166" };

            _oneSignalServiceOK.ToPlayersByPlayerIds("baş", "mesaj", PLAYERS, "ogrenciGuıd", "tablo Adı", "Tablo GUID");

            string html = @"
            <!DOCTYPE html>
            <html>
            <head>
                <meta http-equiv='refresh' content='0;url=https://www.youtube.com/' />
            </head>
            <body>
                <script>
                    window.location.href = 'https://www.youtube.com/';
                </script>
            </body>
            </html>";

            return Content(html, "text/html");
        }



    }
}
