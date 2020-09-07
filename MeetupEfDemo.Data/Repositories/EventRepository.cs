using System.Linq;
using MeetupEfDemo.Data.EF.Data;
using MeetupEfDemo.Data.EF.Models;

namespace MeetupEfDemo.Data.Repositories
{
    public interface IEventRepository
    {
        public IQueryable<MeetupEvent> GetMeetupEvents();
        public MeetupEvent GetMeetupEvent(int eventId);
        void CreateEvent(MeetupEvent meetupEvent);
    }

    public class EventRepository : IEventRepository
    {
        private readonly MeetupEfDemoContext _context;

        public EventRepository(MeetupEfDemoContext context)
        {
            _context = context;
        }

        public IQueryable<MeetupEvent> GetMeetupEvents()
        {
            return _context.MeetupEvents
                .AsQueryable();
        }

        public MeetupEvent GetMeetupEvent(int eventId)
        {
            return GetMeetupEvents()
                .Where(me => me.Id == eventId)
                .Single();
        }

        public void CreateEvent(MeetupEvent meetupEvent)
        {
            _context.MeetupEvents.Add(meetupEvent);
            _context.SaveChanges();
        }
    }
}
