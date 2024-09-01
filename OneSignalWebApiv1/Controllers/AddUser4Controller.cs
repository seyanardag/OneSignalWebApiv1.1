using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneSignalApi.Api;
using OneSignalApi.Client;
using OneSignalApi.Model;
using OneSignalWebApiv1.Entities.OneSignalEntities;
using System.Diagnostics;
using System.Net;
using System.Security.Policy;
using System.Text;

namespace OneSignalWebApiv1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddUser4Controller : ControllerBase
    {

        [HttpGet("CreateUser")]
        public IActionResult CreateUser()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://onesignal.com/api/v1";
            // Configure Bearer token for authorization: app_key
            config.AccessToken = "N2Q5ZmYxNzgtYzEwZi00ZGM3LTliNDYtMzAzZTE1OTEyM2Iy";

            var apiInstance = new DefaultApi(config);
            var appId = "1af6fc63-a7de-4ccc-8f67-7a6a2a14bd65";  // string | 
            var user = new User(); // User | 
            
            SubscriptionObject subscription = new SubscriptionObject();
            subscription.Id = Guid.NewGuid().ToString();
            var ekle =    new List<SubscriptionObject>();
            ekle.Add(subscription);
            user.Subscriptions = ekle;



            try
            {
                User result = apiInstance.CreateUser(appId, user);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DefaultApi.CreateUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }

            return Ok();
        }


        //public void SendOnesignalMobil(String Baslik, String AltBaslik, String Mesaj)
        //{
        //    var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;
        //    request.KeepAlive = true;
        //    request.Method = "POST";
        //    request.ContentType = "application/json; charset=utf-8";

        //    request.Headers.Add("authorization", "Basic " + REST_API_KEY + "");
        //    byte[] byteArray;
        //    byteArray = Encoding.UTF8.GetBytes("{"
        //                                                        + "\"app_id\": \"" + ONESIGNAL_APP_ID + "\","
        //                                                        + "\"headings\": {\"en\": \"" + Baslik + "\"},"
        //                                                        + "\"subtitle\": {\"en\": \"" + AltBaslik + "\"},"
        //                                                        + "\"contents\": {\"en\": \"" + Mesaj + "\"},"
        //                                                        + "\"ios_badgeType\": \"Increase\","
        //                                                        + "\"ios_badgeCount\": 1,"
        //                                                        //+ "\"included_segments\": [\"All\"]}");
        //                                                        + "\"include_player_ids\": [\"c395f934-1d76-423f-95ae-a65d05a55525\"]}");
        //    string responseContent = null;
        //    try
        //    {
        //        using (var writer = request.GetRequestStream())
        //        {
        //            writer.Write(byteArray, 0, byteArray.Length);
        //        }

        //        using (var response = request.GetResponse() as HttpWebResponse)
        //        {
        //            using (var reader = new StreamReader(response.GetResponseStream()))
        //            {
        //                responseContent = reader.ReadToEnd();
        //            }
        //        }
        //    }
        //    catch (WebException ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //        System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
        //    }

        //    System.Diagnostics.Debug.WriteLine(responseContent);
        //}

        [HttpGet("SendOnesignalWeb")]
        public void SendOnesignalWeb(String Baslik, String AltBaslik, String Mesaj)
        {

            var REST_API_KEY = "N2Q5ZmYxNzgtYzEwZi00ZGM3LTliNDYtMzAzZTE1OTEyM2Iy";
            var ONESIGNAL_APP_ID = "1af6fc63-a7de-4ccc-8f67-7a6a2a14bd65";
            var URL = "https://www.youtube.com";

            HttpWebRequest request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;

            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            request.Headers.Add("authorization", "Basic " + REST_API_KEY + "");
            byte[] byteArray;
            byteArray = System.Text.Encoding.UTF8.GetBytes("{"
                                                                    + "\"app_id\": \"" + ONESIGNAL_APP_ID + "\","
                                                                    + "\"headings\": {\"en\": \"" + Baslik + "\"},"
                                                                    + "\"subtitle\": {\"en\": \"" + AltBaslik + "\"},"
                                                                    + "\"contents\": {\"en\": \"" + Mesaj + "\"},"
                                                                    + "\"url\": \"" + URL + "\","
                                                                    + "\"included_segments\": [\"All\"]}");
            string responseContent = null;
            try
            {
                using (Stream writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (WebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
            }
            System.Diagnostics.Debug.WriteLine(responseContent);
        }
    }
}
