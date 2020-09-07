using MeetupEfDemo.Data.EF.Models;

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
    }
}
