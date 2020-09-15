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

            // TODO : demonstrate raw sql query.
            //return _context.MeetupEvents
            //    .FromSqlRaw("SELECT * FROM dbo.MeetupEvents WHERE ID = {0}", eventId)
            //    .Include(e => e.EventAttendance)
            //    .Single();
        }

        public void CreateEvent(MeetupEvent meetupEvent)
        {
            _context.MeetupEvents.Add(meetupEvent);
            _context.SaveChanges();
        }

        public bool AddAttendee(EventAttendance eventAttendance)
        {
            // TODO : demonstrate entity changes after insert.
            _context.EventAttendances.Add(eventAttendance);
            return _context.SaveChanges() == 1;
        }
    }
}
