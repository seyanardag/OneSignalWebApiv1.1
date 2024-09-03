using Newtonsoft.Json;

namespace OneSignalWebApiv1.Entities.OneSignalEntities
{

    //Daha fazla özellik eklenmek istenirse için bu incelenebilir;
    //https://github.com/OneSignal/onesignal-dotnet-api/blob/main/docs/Player.md
    public class OnseSignalPlayerEntity
    {

        [JsonProperty("app_id")]
        public string AppId { get; set; } = String.Empty;

        [JsonProperty("identifier")]
        public string Identifier { get; set; } = String.Empty;
        [JsonProperty("external_user_id")]
        public string? ExternalUserId { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; } = String.Empty;

        [JsonProperty("country")]
        public string Country { get; set; } = String.Empty;

        [JsonProperty("tags")]
        public Tags? Tags { get; set; } = new Tags(); 

        [JsonProperty("device_type")]
        public int DeviceType { get; set; }



    }
    public class Tags
    {
        [JsonProperty("email")]
        public string? Email { get; set; } = String.Empty;

        [JsonProperty("phone")]
        public string? Phone { get; set; } = String.Empty;
    }



}
