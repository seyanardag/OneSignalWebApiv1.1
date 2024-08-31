using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OneSignalWebApiv1.Entities.OneSignalEntities;

namespace OneSignalWebApiv1.Services
{
    public class OneSignalServiceGetUserInfo
    {
        private readonly string _appId;

        public OneSignalServiceGetUserInfo(string appId)
        {
            _appId = appId;
        }

        public async Task<OneSignalUser> GetUser(string oneSignalID)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.onesignal.com/apps/{_appId}/users/by/onesignal_id/{oneSignalID}"),

                Headers =
                {
                    { "accept", "application/json" },
                },
            };


            try
            {
                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                        if (string.IsNullOrWhiteSpace(body))
                        {
                            return null; // Kullanıcı bulunamadı
                        }
                        OneSignalUser user = JsonConvert.DeserializeObject<OneSignalUser>(body);
                        if (user == null)
                        {
                            return null; // dönen yanıt convert edilememiş
                        }

                        return user; //User başarılı şekilde bulundu ve çevirme başarılı, bunu döndür

                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return null;
        }

    }
}
