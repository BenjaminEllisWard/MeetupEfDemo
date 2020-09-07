using System.Collections.Generic;
using MeetupEfDemo.Data.EF.Models;

namespace MeetupEfDemo.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<MeetupEvent> MeetupEvents { get; set; }
    }
}
