using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OneSignalWebApiv1.Entities.OneSignalEntities;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace OneSignalWebApiv1.Services
{
    public class OneSignalServiceCreateOrUpdatePlayer
    {

        private readonly string _addId;
        private readonly string _apiKey;

        public OneSignalServiceCreateOrUpdatePlayer(string appId, string apiKey)
        {
            _addId = appId;
            _apiKey = apiKey;
        }

        //girilen email ile Push Token olarak kaydedilmiş bir email eşleşirse günceller, yoksa yeni player oluşturur
        public async Task<string> CreateOrUpdatePlayerAsync(string email, string phoneNumber)
        {
            email = email.Trim();
            phoneNumber = phoneNumber.Trim();

            var client = new HttpClient();

            // OneSignalPlayer nesnesi oluştur- manuel olarak Entities içinde tanımlandı
            var user = new OnseSignalPlayerEntity()
            {
                AppId = _addId,
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
                    { "Authorization", $"Basic {_apiKey}" }
                },
                Content = new StringContent(jsonContent)
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
                    var body = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(body);
                    return body;
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
                return ex.Message;
            }
            

        }
    }
}
