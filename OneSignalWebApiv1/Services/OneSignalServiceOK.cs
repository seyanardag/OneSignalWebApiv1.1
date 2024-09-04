using Microsoft.EntityFrameworkCore;
using OneSignalApi.Api;
using OneSignalApi.Client;
using OneSignalApi.Model;
using OneSignalWebApiv1.Context;

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
                throw;
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
                CreateNotificationSuccessResponse result = await _client.CreateNotificationAsync(notification);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //Dersi yaklaşan kullanıcıya bildirim gönderilmesi
        public Task SendNotificationToCustomScheduled()
        {

            var startTimeSpan = TimeSpan.Zero;
            //heading = "DERS YAKLAŞTI";
            var message = "Planlı dersiniz için son 15 dakika. Lütfen hazırlık yapınız";

            //Test amaçlı 20 saniye seçildi, normalde alt satırdaki 15 dakika aktif olacak            
            var periodTimeSpan = TimeSpan.FromSeconds(10);
            //var periodTimeSpan = TimeSpan.FromMinutes(15);

            var timer = new System.Threading.Timer(async (e) =>
            {
                //TODO DbContext in daha verimli şekilde kullanılması düşünülebilir
                var _context = new OneSignalDbContext();
                //Öğrencinin kendi hazırladığı dersin başlamasına son 10 dk dan az kaldığının hesaplanması ve bu öğrencilerin listesinin oluştyurulması
                //TODO isNotifSent bilgisinin doldurulması?
                var ScheduleTimeComingPlayerIds = _context.CustomSchedules.Include(x=>x.Student).Where(x => x.ScheduleDate > DateTime.UtcNow.AddHours(3) && x.ScheduleDate < DateTime.UtcNow.AddHours(3).AddMinutes(15)).Select(x=>x.Student.SubscriptionId).ToList();
                var notNullPlayerIds = ScheduleTimeComingPlayerIds.Where(x=> x != null).Distinct().ToList();



                //Timer ın çalıştığını kontrol etmek için;
                System.Diagnostics.Debug.WriteLine("calisti");
                System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString());


                if (ScheduleTimeComingPlayerIds.Any())
                {
                    await ToPlayersByPlayerIds("PLANLI DERS YAKLAŞTI", "HAZIRLIK YAPINIZ", ScheduleTimeComingPlayerIds);                   
                }

            }, null, startTimeSpan, periodTimeSpan);

            return Task.CompletedTask;

        }






    }
}
