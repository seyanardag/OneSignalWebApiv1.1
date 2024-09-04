using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneSignalWebApiv1.Services;

namespace OneSignalWebApiv1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationOKController : ControllerBase
    {
        private readonly OneSignalServiceOK _oneSignalServiceOK;

        public NotificationOKController(OneSignalServiceOK oneSignalServiceOK)
        {
            _oneSignalServiceOK = oneSignalServiceOK;
        }


        //Bütün Kullanıcılara bildirim gönderilmesi
        [HttpPost("ButunKullanicilaraBildirim")]
        public async Task<ActionResult> SendNotificationToTotalSubscribtions(string heading, string content)
        {
            await _oneSignalServiceOK.SendNotificationToTotalSubscribtions(heading, content);
            return Ok("Bildirim Gönderme Başarılı");
        }


        //Son 3 gündür sisteme giriş yapmamış kullanıcılara bildirim gönderilmesi
        [HttpPost("Son3GundurGirisYapmayanaBildirim")]
        public async Task<IActionResult> SendNotificationToPassiveForLast3Days(string heading, string content)
        {
            await _oneSignalServiceOK.SendNotificationToPassiveForLast3Days(heading, content);
            return Ok("Son 3 gün içinde aktif olmayan kullanıcılara bildirim gönderildi.");

        }

        //Belirli bir kullanıcıya veya kullanıcılara bildirim gönderilmesi
        [HttpPost("BelirliKullanicilaraBildirim")]
        public async Task<IActionResult> SendNotificationToSpecificUser(string heading, string content, List<string> playerIds)
        {
            await _oneSignalServiceOK.ToPlayersByPlayerIds(heading, content, playerIds);
            return Ok("Belirlenen kişiye/kişilere bildirim gönderildi");

        }

        //Öğrencinin ders programındaki etkinliğin yaklaştığının bildiriminin gönderilme servisinin başlatılması (THREAD KULLANILDI)
        [HttpPost("DersYaklastiBildirimServisiniBaslat")]
        public async Task<IActionResult> CustomScheduleReminder()
        {
            await _oneSignalServiceOK.SendNotificationToCustomScheduled();
            return Ok();
        }










    }
}
