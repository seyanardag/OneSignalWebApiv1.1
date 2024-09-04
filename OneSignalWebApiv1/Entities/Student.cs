using OneSignalWebApiv1.Entities.Abstract;

namespace OneSignalWebApiv1.Entities
{
    public class Student : BaseEntity
    {
        public string StudentName { get; set; }
        public string? OneSignalId { get; set; }
        public string? SubscriptionId { get; set; }
        public string? PushToken { get; set; }

        public ICollection<StudentHomeworkMV> StudentHomeworkMVs { get; set; } = new HashSet<StudentHomeworkMV>();
    }
}
