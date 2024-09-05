using OneSignalWebApiv1.Entities.Abstract;

namespace OneSignalWebApiv1.Entities
{
    public class CustomSchedule: BaseEntity
    {
        public string LessonName { get; set; }
        public DateTime ScheduleDate { get; set; }
        public bool isNotificationSent { get; set; }
        public bool isNotificationRead { get; set; }


        public Student? Student { get; set; }
        public Guid? StudentId { get; set; }

       
    }
}
