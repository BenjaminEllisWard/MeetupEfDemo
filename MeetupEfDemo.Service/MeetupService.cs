using MeetupEfDemo.Data.EF.Models;
using MeetupEfDemo.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetupEfDemo.Service
{
    public interface IMeetupService
    {
        public IEnumerable<Person> GetPeople();
        public IEnumerable<MeetupEvent> GetMeetupEvents();
        public MeetupEvent GetMeetupEvent(int eventId);
        void CreateEvent(MeetupEvent meetupEvent);
        bool AddAttendee(EventAttendance eventAttendance);
    }

    public class MeetupService : IMeetupService
    {
        private readonly IMeetupRepository _repository;

        public MeetupService(IMeetupRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Person> GetPeople()
        {
            return _repository.GetPeople().ToList();
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

        public bool AddAttendee(EventAttendance eventAttendance)
        {
            return _repository.AddAttendee(eventAttendance);
        }
    }
}
