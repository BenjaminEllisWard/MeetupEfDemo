using MeetupEfDemo.Data.EF.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MeetupEfDemo.Web.Models
{
    public class EventViewModel
    {
        public MeetupEvent MeetupEvent { get; set; }

        public string IsVirtualDisplay
        {
            get
            {
                return MeetupEvent.IsVirtual != null ? MeetupEvent.IsVirtual == true ? "Yes" : "No" : "TBA";
            }
        }

        public string WhenDisplay
        {
            get
            {
                var dateTime = MeetupEvent.When;
                return dateTime.HasValue ? dateTime.Value.ToString() : "TBA";
            }
        }

        public string LocationDisplay
        {
            get
            {
                var location = MeetupEvent.Location;
                return string.IsNullOrWhiteSpace(location) ? "TBA" : location;
            }
        }

        public IEnumerable<EventAttendance> Attending
        {
            get
            {
                if (MeetupEvent.EventAttendance == null)
                {
                    return Enumerable.Empty<EventAttendance>();
                }
                else
                {
                    return MeetupEvent.EventAttendance.Where(e => e.WillAttend == true);
                }
            }
        }

        public IEnumerable<EventAttendance> MaybeAttending
        {
            get
            {
                if (MeetupEvent.EventAttendance == null)
                {
                    return Enumerable.Empty<EventAttendance>();
                }
                else
                {
                    return MeetupEvent.EventAttendance.Where(e => e.WillAttend == null);
                }
            }
        }

        public IEnumerable<EventAttendance> NotAttending
        {
            get
            {
                if (MeetupEvent.EventAttendance == null)
                {
                    return Enumerable.Empty<EventAttendance>();
                }
                else
                {
                    return MeetupEvent.EventAttendance.Where(e => e.WillAttend == false);
                }
            }
        }
    }
}
