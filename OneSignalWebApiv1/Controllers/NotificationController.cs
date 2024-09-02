﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneSignalWebApiv1.Services;

namespace OneSignalWebApiv1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly OneSignalService _oneSignalService;
        private readonly OneSignalServiceSpecificUsers _oneSignalServiceSpecificUsers;
        
        public NotificationController(OneSignalService oneSignalService, OneSignalServiceSpecificUsers oneSignalServiceSpecificUsers)
        {
            _oneSignalService = oneSignalService;
            _oneSignalServiceSpecificUsers = oneSignalServiceSpecificUsers;
            
        }


        //Bütün Kullanıcılara bildirim gönderilmesi
        [HttpPost("ButunKullanicilaraBildirim")]       
        public async Task<ActionResult> SendNotificationToTotalSubscribtions(string heading, string content)
        {           
            await _oneSignalService.SendNotificationToTotalSubscribtions(heading, content);
            return Ok("Bildirim Gönderme Başarılı");
        }


        //Son 3 gündür sisteme giriş yapmamış kullanıcılara bildirim gönderilmesi
        [HttpPost("Son3GundurGirisYapmayanaBildirim")]
        public async Task<IActionResult> SendNotificationToPassiveForLast3Days(string heading, string content)
        {
            await _oneSignalService.SendNotificationToPassiveForLast3Days(heading, content);
            return Ok("Son 3 gün içinde aktif olmayan kullanıcılara bildirim gönderildi.");

        }

        //Belirli bir kullanıcıya veya kullanıcılara bildirim gönderilmesi
        [HttpPost("BelirliKullaniciyaBildirim")]
        public async Task<IActionResult> SendNotificationToSpecificUser(string heading, string content, List<string> playerIds)
        {
            await _oneSignalServiceSpecificUsers.SendNotificationSpecificUser(heading, content, playerIds);
            return Ok("Belirlenen kişiye mesaj gönderildi");

        }

        //Öğrencinin ders programındaki etkinliğin yaklaştığının bildiriminin gönderilmesi
        [HttpPost("DersYaklastiBildirimi")]
        public async Task<IActionResult> CustomScheduleReminder()
        {
            await _oneSignalServiceSpecificUsers.SendNotificationToCustomScheduled("başlık", "mesaj");
            return Ok();
        }



    }
}
