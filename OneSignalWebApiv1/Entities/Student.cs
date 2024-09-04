using OneSignalWebApiv1.Entities.Abstract;

namespace OneSignalWebApiv1.Entities
{
    public class Student : BaseEntity
    {
        public string StudentName { get; set; }
        public string? OneSignalId { get; set; }
        public string? SubscriptionId { get; set; }
        public string? PushToken { get; set; }
        public string? Email { get; set; }

        

        public ICollection<StudentHomeworkMV> StudentHomeworkMVs { get; set; } = new HashSet<StudentHomeworkMV>();
        public ICollection<CustomSchedule> CustomSchedules { get; set; } = new List<CustomSchedule>();
    }
}
