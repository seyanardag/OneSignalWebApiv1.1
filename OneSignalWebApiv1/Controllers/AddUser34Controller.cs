using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OneSignalWebApiv1.Entities.OneSignalEntities;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
namespace OneSignalWebApiv1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddUser34Controller : ControllerBase
    {

        //PushToken bazlı olarak mevcut pushToken varsa bu kaydı günceller, yoksa yeni player kaydı oluşturur.
        [HttpGet("KullaniciEkleVeyaGuncelle")]
        public async Task<IActionResult> AddUser36(string email, string phoneNumber)
        {
            var client = new HttpClient();

            // API anahtarınızı ve uygulama ID'nizi buraya ekleyin
            var appId = "1af6fc63-a7de-4ccc-8f67-7a6a2a14bd65";
            var apiKey = "N2Q5ZmYxNzgtYzEwZi00ZGM3LTliNDYtMzAzZTE1OTEyM2Iy";

            // OneSignalUser nesnesi oluşturun
            var user = new OnseSignalPlayerEntity()
            {
                AppId = appId,
                Identifier = email,
                Language = "TR",
                Country = "TR",
                DeviceType = 5 //web push kodu https://github.com/OneSignal/onesignal-dotnet-api/blob/main/docs/Player.md                
            };
            user.Tags.Phone = phoneNumber;
            user.Tags.Email = email;
            user.ExternalUserId = email;

            //var jsonContent = JsonSerializer.Serialize(user);
            var jsonContent = JsonConvert.SerializeObject(user);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://onesignal.com/api/v1/players"),
                Headers =
                {
                    { "accept", "application/json" },
                    { "Authorization", $"Basic {apiKey}" }
                },
                Content = new StringContent(jsonContent)
                {
                    Headers =
                            {
                                ContentType = new MediaTypeHeaderValue("application/json")
                            }
                }
            };

            using (var response = await client.SendAsync(request))
            {
                var body = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(body);
            }

            return Ok();
        }


        //    [HttpGet("AddUser34")]
        //    public async Task<IActionResult> AddUser34()
        //    {
        //        var client = new HttpClient();

        //        // API anahtarınızı ve uygulama ID'nizi buraya ekleyin
        //        var appId = "1af6fc63-a7de-4ccc-8f67-7a6a2a14bd65";
        //        var apiKey = "N2Q5ZmYxNzgtYzEwZi00ZGM3LTliNDYtMzAzZTE1OTEyM2Iy"; // Bir API anahtarı ekleyin (genellikle bir başlık olarak eklenir)

        //        var request = new HttpRequestMessage
        //        {
        //            Method = HttpMethod.Post,
        //            RequestUri = new Uri($"https://api.onesignal.com/apps/{appId}/users"),
        //            Headers =
        //                    {
        //                        { "accept", "application/json" },
        //                        { "Authorization", $"Basic {apiKey}" } // API anahtarınızı eklemeyi unutmayın
        //                    },

        //            Content = new StringContent("{\"properties\":{\"country\":\"US\",\"tags\":{\"favorite_team\":\"Lakers\"},\"language\":\"EN\"},\"identity\":{\"external_id\":\"test123abcddd\"}}")
        //           // Content = new StringContent("{\"properties\":{\"tags\":\"string\",\"language\":\"en\",\"timezone_id\":\"America\\\\/Los_Angeles\",\"lat\":90,\"long\":135,\"country\":\"US\",\"first_active\":1678215680,\"last_active\":1678215682,\"ip\":\"string\"},\"identity\":{\"external_id\":\"test_external_id\",\"onesignal_id\":\"string\"},\"subscriptions\":[{\"type\":\"iOSPush\",\"token\":\"pushToken,email,OR,phoneNumber\",\"enabled\":true,\"notification_types\":0,\"session_time\":60,\"session_count\":1,\"app_version\":\"1.0.0\",\"device_model\":\"iPhone 14\",\"device_os\":\"16.0.0\",\"test_type\":0,\"sdk\":\"5.0.0\",\"rooted\":false,\"web_auth\":\"string\",\"web_p256\":\"string\"}]}")


        //            {
        //                Headers =
        //                        {
        //                            ContentType = new MediaTypeHeaderValue("application/json")
        //                        }
        //                }
        //        };

        //        using (var response = await client.SendAsync(request))
        //        {
        //            response.EnsureSuccessStatusCode();
        //            var body = await response.Content.ReadAsStringAsync();
        //            System.Diagnostics.Debug.WriteLine(body);
        //        }

        //        return Ok();
        //    }

        //    //ÇALIŞIYOR-  BASE OLARAK KULLANILACAK
        //    [HttpGet("AddUser35")]
        //    public async Task<IActionResult> AddUser35(string email, string phoneNumber, string additionalInfo)
        //    {
        //        var client = new HttpClient();

        //        // API anahtarınızı ve uygulama ID'nizi buraya ekleyin
        //        var appId = "1af6fc63-a7de-4ccc-8f67-7a6a2a14bd65";
        //        var apiKey = "N2Q5ZmYxNzgtYzEwZi00ZGM3LTliNDYtMzAzZTE1OTEyM2Iy"; // Bir API anahtarı ekleyin (genellikle bir başlık olarak eklenir)


        //        //var uniqueIdentifier = Guid.NewGuid().ToString(); //Yeni kullanıcının Push Token i olarak atanacak. Yeni kullanıcı oluşturulması için bu değer benzersiz olmalı. 
        //        var uniqueIdentifier = "d0c381d3-73f4-4421-bf72-8124722bf2de";

        //        var request = new HttpRequestMessage
        //        {
        //            Method = HttpMethod.Post,
        //            RequestUri = new Uri($"https://onesignal.com/api/v1/players"),
        //            Headers =
        //                {
        //                    { "accept", "application/json" },
        //                    { "Authorization", $"Basic {apiKey}" } // API anahtarınızı eklemeyi unutmayın
        //                },

        //            //unique identifier gelirse email-tag tagına verilen emaili atar, unique identfier olarak push-token verilirse de mevcut olanı günceller
        //            //Content = new StringContent($"{{\"app_id\":\"{appId}\",\"identifier\":\"{uniqueIdentifier}\",\"language\":\"EN\",\"country\":\"TR\",\"tags\":{{\"email-tag\":\"{email}\"}},\"device_type\":3}}")
        //            //Content = new StringContent($"{{\"app_id\":\"{appId}\",\"identifier\":\"{email}\",\"language\":\"EN\",\"country\":\"US\",\"tags\":{{\"favorite_team\":\"Lakers\"}},\"device_type\":4}}") // 4 = Web Push; e-posta için uygun bir device_type değeri
        //            Content = new StringContent($"{{\"app_id\":\"{appId}\",\"identifier\":\"{email}\",\"language\":\"EN\",\"country\":\"US\",\"tags\":{{\"favorite_team\":\"Lakers\"}},\"device_type\":4,\"properties\":{{\"phone_number\":\"{phoneNumber}\",\"additional_info\":\"{additionalInfo}\"}}}}")

        //            {
        //                Headers =
        //                        {
        //                            ContentType = new MediaTypeHeaderValue("application/json")
        //                        }
        //            }
        //        };

        //        using (var response = await client.SendAsync(request))
        //        {
        //            var body = await response.Content.ReadAsStringAsync(); //Dönen yanıttaki Id: yeni kaydın playerId si
        //            Debug.WriteLine(body);
        //        }

        //        return Ok();
        //    }





    }
}
