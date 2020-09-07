using MeetupEfDemo.Data.EF.Models;
using MeetupEfDemo.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MeetupEfDemo.Service
{
    public interface IEventService
    {
        public IEnumerable<MeetupEvent> GetMeetupEvents();
        public MeetupEvent GetMeetupEvent(int eventId);
        void CreateEvent(MeetupEvent meetupEvent);
    }

    public class EventService : IEventService
    {
        private readonly IEventRepository _repository;

        public EventService(IEventRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<MeetupEvent> GetMeetupEvents()
        {
            // TODO : Query syntax example
            return 
                from e in _repository.GetMeetupEvents()
                orderby e.When descending
                select e;
        }

        public MeetupEvent GetMeetupEvent(int eventId)
        {
            return _repository.GetMeetupEvent(eventId);
        }

        public void CreateEvent(MeetupEvent meetupEvent)
        {
            _repository.CreateEvent(meetupEvent);
        }
    }
}
