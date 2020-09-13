using System;
using System.Linq;
using MeetupEfDemo.Data.EF.Data;
using MeetupEfDemo.Data.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetupEfDemo.Data.Repositories
{
    public interface IMeetupRepository
    {
        IQueryable<Person> GetPeople();
        IQueryable<MeetupEvent> GetMeetupEvents();
        MeetupEvent GetMeetupEvent(int eventId);
        void CreateEvent(MeetupEvent meetupEvent);
        bool AddAttendee(EventAttendance eventAttendance);
    }

    public class MeetupRepository : IMeetupRepository
    {
        private readonly MeetupEfDemoContext _context;

        public MeetupRepository(MeetupEfDemoContext context)
        {
            _context = context;
        }

        public IQueryable<Person> GetPeople()
        {
            return _context.Persons
                .AsQueryable();
        }

        public IQueryable<MeetupEvent> GetMeetupEvents()
        {
            return _context.MeetupEvents
                .AsQueryable();
        }

        public MeetupEvent GetMeetupEvent(int eventId)
        {
            return GetMeetupEvents()
                .Include(me => me.EventAttendance)
                .Where(me => me.Id == eventId)
                .Single();
        }

        public void CreateEvent(MeetupEvent meetupEvent)
        {
            _context.MeetupEvents.Add(meetupEvent);
            _context.SaveChanges();
        }

        public bool AddAttendee(EventAttendance eventAttendance)
        {
            _context.EventAttendances.Add(eventAttendance);
            _context.SaveChanges();

            return eventAttendance.Id > 0;
        }
    }
}
