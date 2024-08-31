namespace OneSignalWebApiv1.Entities.OneSignalEntities
{
    public class OneSignalUser
    {
        public properties properties { get; set; }
        public identity identity { get; set; }
        public List<subscriptions> subscriptions { get; set; }
    }
    public class subscriptions
    {
        public string id { get; set; }
        public string app_id { get; set; }
        public string type { get; set; }
        public string token { get; set; }
        public bool enabled { get; set; }
        public int notification_types { get; set; }
        public int session_time { get; set; }
        public int session_count { get; set; }
        public string sdk { get; set; }
        public string device_model { get; set; }
        public string device_os { get; set; }
        public bool rooted { get; set; }
        public int test_type { get; set; }
        public string app_version { get; set; }
        public int net_type { get; set; }
        public string carrier { get; set; }
        public string web_auth { get; set; }
        public string web_p256 { get; set; }
    }

    public class identity
    {
        public string onesignal_id { get; set; }
    }

    public class properties
    {
        public string language { get; set; }
        public string timezone_id { get; set; }
        public string country { get; set; }
        public long first_active { get; set; }
        public long last_active { get; set; }
        public string ip { get; set; }
    }



}
