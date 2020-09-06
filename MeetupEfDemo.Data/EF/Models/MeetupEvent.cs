using System;
using System.Collections.Generic;

namespace MeetupEfDemo.Data.EF.Models
{
    public class MeetupEvent
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public bool? IsVirtual { get; set; }
        public DateTime? When { get; set; }
        public string Location { get; set; }

        public virtual ICollection<EventAttendance> EventAttendance { get; set; }
    }
}
