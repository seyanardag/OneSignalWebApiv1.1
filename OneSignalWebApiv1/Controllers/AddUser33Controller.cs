using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OneSignalWebApiv1.Entities.OneSignalEntities;
using System.Net;
using System.Security.Policy;

namespace OneSignalWebApiv1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddUser33Controller : ControllerBase
    {
        [HttpGet("AddUser3")]
        public async Task<IActionResult> AddUser3()
        {

            var REST_API_KEY = "N2Q5ZmYxNzgtYzEwZi00ZGM3LTliNDYtMzAzZTE1OTEyM2Iy";
            var ONESIGNAL_APP_ID = "1af6fc63-a7de-4ccc-8f67-7a6a2a14bd65";


            HttpWebRequest request = WebRequest.Create("https://api.onesignal.com/apps/1af6fc63-a7de-4ccc-8f67-7a6a2a14bd65/users") as HttpWebRequest;
            
            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.Headers.Add("authorization", "Basic " + REST_API_KEY + "");
            byte[] byteArray;
            //byteArray = System.Text.Encoding.UTF8.GetBytes("{"
            //                                                        + "\"app_id\": \"" + ONESIGNAL_APP_ID + "\","
            //                                                        + "\"headings\": {\"en\": \"" + Baslik + "\"},"
            //                                                        + "\"subtitle\": {\"en\": \"" + AltBaslik + "\"},"
            //                                                        + "\"contents\": {\"en\": \"" + Mesaj + "\"},"
            //                                                        + "\"url\": \"" + URL + "\","
            //                                                        + "\"included_segments\": [\"All\"]}");

            byteArray = System.Text.Encoding.UTF8.GetBytes("{"
                                                                    + "\"properties\": {"
                                                                    + "\"country\": \"US\","
                                                                    + "\"tags\": {\"favorite_team\": \"Lakers\"},"
                                                                    + "\"language\": \"EN\""
                                                                    + "},"
                                                                    + "\"identity\": {"
                                                                    + "\"external_id\": \"7ae7e33d-badc-4d4d-a154-ed199b779985\""
                                                                    + "}"
                                                                    + "}");





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

            return Ok();



        }
    }
}
