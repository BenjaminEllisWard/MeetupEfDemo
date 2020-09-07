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
        private readonly IEventService _service;

        public HomeController(IEventService service)
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
                MeetupEvent = _service.GetMeetupEvent(eventId)
            };

            return View(model);
        }

        [HttpPost]
        public void CreateEvent(MeetupEvent meetupEvent)
        {
            _service.CreateEvent(meetupEvent);
        }
    }
}
