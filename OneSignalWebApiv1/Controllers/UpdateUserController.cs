using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


//200 dönüyor ama güncellemiyor
namespace OneSignalWebApiv1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateUserController : ControllerBase
    {
        private static readonly string REST_API_KEY = "N2Q5ZmYxNzgtYzEwZi00ZGM3LTliNDYtMzAzZTE1OTEyM2Iy";
        private static readonly string APP_ID = "1af6fc63-a7de-4ccc-8f67-7a6a2a14bd65"; // OneSignal uygulama ID'nizi buraya ekleyin
        private static readonly string BASE_URL = "https://onesignal.com/api/v1/players/{0}";
        [HttpGet]
        public async Task<IActionResult> UpdateUser()
        {
            string playerId = "84ce3580-c026-480c-9c62-b1904c075994"; // Güncellemek istediğiniz OneSignal ID
            string newEmail = "newemail@example.com"; // Yeni e-posta adresi

            // URL'yi OneSignal ID ile formatla
            string url = string.Format(BASE_URL, playerId);

            // JSON içeriğini oluştur
            string jsonContent = "{"
                + "\"app_id\": \"" + APP_ID + "\","
                + "\"email\": \"" + newEmail + "\""
                + "}";

            using (var client = new HttpClient())
            {
                // HTTP isteğini yapılandır
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + REST_API_KEY);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var requestContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(url, requestContent);

                // Yanıtı kontrol et
                if (response.IsSuccessStatusCode)
                {
                    return Ok("E-posta başarıyla güncellendi.");
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine("Hata: " + response.StatusCode + " - " + errorMessage);

                    // Yanıtın içeriğini ayrıntılı olarak yazdır
                    System.Diagnostics.Debug.WriteLine("Detaylı Hata Mesajı: " + errorMessage);
                }
            }


            return Ok();
        }
    }
}
