using Microsoft.EntityFrameworkCore;
using OneSignalApi.Api;
using OneSignalApi.Client;
using OneSignalApi.Model;
using OneSignalWebApiv1.Context;
using Polly;
using System.Diagnostics;

namespace OneSignalWebApiv1.Services
{
    public class OneSignalServiceOK
    {
        private readonly DefaultApi _client;
        private readonly string _appId;
        public OneSignalServiceOK(string appId, string oneSignalApiKey)
        {
            _appId = appId;
            var appConfig = new Configuration
            {
                BasePath = "https://onesignal.com/api/v1",
                AccessToken = oneSignalApiKey
            };
            _client = new DefaultApi(appConfig);
        }


        public async Task SentToSegment(string heading, string message, List<string> segments)
        {
            heading = heading.Trim();
            message = message.Trim();
            // Bildirim oluşturma
            var notification = new Notification(appId: _appId)
            {
                // Bildirim başlığı                
                Headings = new StringMap { En = heading },
                // Bildirim içeriği
                Contents = new StringMap { En = message },
                // Hedef kitle           
                IncludedSegments = segments,
            };

            try
            {
                CreateNotificationSuccessResponse result = await _client.CreateNotificationAsync(notification);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        //Bütün kayıtlı kullanıcılara 
        public Task SendNotificationToTotalSubscribtions(string heading, string message)
        {
            var segments = new List<string> { "Total Subscriptions" };
            return SentToSegment(heading, message, segments);

        }

        //son 3 gündür giriş yapmayan kullanıcılara
        public Task SendNotificationToPassiveForLast3Days(string heading, string message)
        {
            var segments = new List<string> { "son 3 gun aktif olmayanlar" };
            return SentToSegment(heading, message, segments);
        }

        //
        public async Task ToPlayersByPlayerIds(string heading, string message, List<string> playerIds)
        {
            heading = heading.Trim();
            message = message.Trim();

            // Bildirim oluşturma
            var notification = new Notification(appId: _appId)
            {
                // Bildirim başlığı                
                Headings = new StringMap { En = heading },
                // Bildirim içeriği
                Contents = new StringMap { En = message },
                // Hedef kitle
                // bu özellik depreceted olmuş ama hala kullanılabilior, doğrudan bunu karşılayan başka bir metod şu anda yok.
                IncludePlayerIds = playerIds

            };

            try
            {
                if (playerIds != null && playerIds.Any())
                {
                    CreateNotificationSuccessResponse result = await _client.CreateNotificationAsync(notification);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }


        }

        //Dersi yaklaşan kullanıcıya bildirim gönderilmesi
        public Task SendNotificationToCustomScheduled()
        {

            var startTimeSpan = TimeSpan.Zero;
            //heading = "DERS YAKLAŞTI";
            var message = "Planlı dersiniz için son 15 dakika. Lütfen hazırlık yapınız";

            //Test amaçlı 10 saniye seçildi, normalde alt satırdaki 15 dakika aktif olacak            
            var periodTimeSpan = TimeSpan.FromSeconds(10);
            //var periodTimeSpan = TimeSpan.FromMinutes(15);

            var timer = new System.Threading.Timer(async (e) =>
            {
                //TODO DbContext in daha verimli şekilde kullanılması düşünülebilir
                var _context = new OneSignalDbContext();
               
                var now = DateTime.UtcNow.AddHours(3);
                var end = now.AddMinutes(15);

                var studentIds = _context.CustomSchedules.Where(x => x.ScheduleDate > now && x.ScheduleDate < end && x.isNotificationSent == false).Select(x => x.StudentId).Distinct().ToList();
                var playerIds = _context.Students.Where(s => studentIds.Contains(s.GUID)).Select(s => s.SubscriptionId).ToList();
                var notNullPlayerIds = playerIds.Where(x => x != null).Distinct().ToList();

                var schedulesToUpdate = _context.CustomSchedules.Where(x => x.ScheduleDate > now && x.ScheduleDate < end && x.isNotificationSent == false).ToList();
                foreach (var schedule in schedulesToUpdate)
                {
                    schedule.isNotificationSent = true;
                }
                await _context.SaveChangesAsync();
                //Timer ın çalıştığını kontrol etmek için;
                System.Diagnostics.Debug.WriteLine("calisti");
                System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString());


                if (notNullPlayerIds.Any())
                {
                    await ToPlayersByPlayerIds("PLANLI DERS YAKLAŞTI", "HAZIRLIK YAPINIZ", notNullPlayerIds);
                }

            }, null, startTimeSpan, periodTimeSpan);

            return Task.CompletedTask;

        }






    }
}
