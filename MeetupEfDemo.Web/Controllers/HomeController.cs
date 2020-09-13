using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MeetupEfDemo.Web.Models;
using MeetupEfDemo.Service;
using MeetupEfDemo.Data.EF.Models;

namespace MeetupEfDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMeetupService _service;

        public HomeController(IMeetupService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                MeetupEvents = _service.GetMeetupEvents()
            };

            return View(model);
        }

        public IActionResult Event(int eventId)
        {
            var model = new EventViewModel
            {
                People = _service.GetPeople(),
                MeetupEvent = _service.GetMeetupEvent(eventId)
            };

            return View(model);
        }

        [HttpPost]
        public void CreateEvent(MeetupEvent meetupEvent)
        {
            _service.CreateEvent(meetupEvent);
        }

        [HttpPost]
        public IActionResult AddAttendee(EventAttendance eventAttendance)
        {
            _service.AddAttendee(eventAttendance);

            var model = new EventViewModel
            {
                People = _service.GetPeople(),
                MeetupEvent = _service.GetMeetupEvent(eventAttendance.MeetupEventId)
            };

            return PartialView("~/Views/Home/Partial/_eventDetailsPartial.cshtml", model);
        }
    }
}
