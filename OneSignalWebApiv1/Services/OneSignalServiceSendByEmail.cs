using OneSignalApi.Api;
using OneSignalApi.Model;
using OneSignalWebApiv1.Context;
using System.Configuration;
using OneSignalApi.Client;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace OneSignalWebApiv1.Services
{
    public class OneSignalServiceSendByEmail
    {
        private readonly DefaultApi _client;
        private readonly string _appId;
        public OneSignalServiceSendByEmail(string appId, string oneSignalApiKey)
        {
            _appId = appId;
            var appConfig = new OneSignalApi.Client.Configuration
            {
                BasePath = "https://onesignal.com/api/v1",
                AccessToken = oneSignalApiKey
            };
            _client = new DefaultApi(appConfig);
        }

        
        public async Task<string> SendByEmailAsync(string heading, string message, string email)
        {
            heading = heading.Trim();
            message = message.Trim();
            email = email.Trim();

            // Bildirim oluşturma
            var notification = new Notification(appId: _appId)
            {
                // Bildirim başlığı                
                Headings = new StringMap { En = heading },
                // Bildirim içeriği
                Contents = new StringMap { En = message },
                // Hedef kitle           

                Filters = new List<Filter> ()
                    {                       
                        new Filter (field : "tag")
                        {
                            Field = "tag",
                            Key = "email",
                            Relation = Filter.RelationEnum.Equal,
                            Value = email
                        }
                    }

            };         

            try
            {
                CreateNotificationSuccessResponse result = await _client.CreateNotificationAsync(notification);
                return result.Id;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return ex.Message;
            }

        }
        



    }
}
