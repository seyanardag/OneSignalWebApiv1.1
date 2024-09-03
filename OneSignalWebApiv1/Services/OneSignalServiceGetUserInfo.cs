using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OneSignalWebApiv1.Entities.OneSignalEntities;
using System.Text.Json.Nodes;

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
            oneSignalID = oneSignalID.Trim();
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



        //PlayerId veya Subscription ID kullanarak OneSignalId nin döndürülmesi
        public async Task<string> GetOneSignalIdByPlayerId(string playerId)
        {                    
            playerId = playerId.Trim();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,

                RequestUri = new Uri($"https://api.onesignal.com/apps/{_appId}/subscriptions/{playerId}/user/identity"),

                Headers =
                    {
                        { "accept", "application/json" },
                    },
            };

            try
            {
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    if (body.Length < 0 || body != null)
                    {
                        var json = JsonObject.Parse(body);
                        var oneSignalId = json["identity"]["onesignal_id"].ToString();
                        return oneSignalId;
                    }
                    else return null;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
        }






    }
}
