using System.Collections.Generic;

namespace MeetupEfDemo.Data.EF.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual ICollection<EventAttendance> EventAttendance { get; set; }
    }
}
