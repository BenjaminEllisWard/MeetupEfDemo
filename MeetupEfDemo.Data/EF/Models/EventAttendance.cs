namespace MeetupEfDemo.Data.EF.Models
{
    /// <summary>
    /// This model represents a person's attendance at a particular event.
    /// </summary>
    public class EventAttendance
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int MeetupEventId { get; set; }
        public bool? WillAttend { get; set; }

        public virtual Person Person { get; set; }
        public virtual MeetupEvent MeetupEvent { get; set; }
    }
}
