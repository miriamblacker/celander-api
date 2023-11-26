using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.Collections;

using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace firstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private static List<Event> events = new List<Event> {
        new Event { Id = 1, Title = "Event 1", Start = DateTime.Now, End = DateTime.Now.AddDays(1) },
    new Event { Id = 2, Title = "Event 2", Start = DateTime.Now.AddDays(2), End = DateTime.Now.AddDays(3) },
    new Event { Id = 3, Title = "Event 3", Start = DateTime.Now.AddDays(4), End = DateTime.Now.AddDays(5) }
        };

        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }

        // POST api/<EventsController>
        [HttpPost]
        //add
        public void Post([FromBody] Event value)
        {
            events.Add(new Event { Id = 4, Title = "Event 4", Start = DateTime.Now.AddDays(5), End = DateTime.Now.AddDays(6) });
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        //update
        public void Put(int id, [FromBody] Event value)
        {
            //events = events.Where(x => x.Id == id).Select(x => value).ToList();
            Event existingEvent = events.FirstOrDefault(x => x.Id == id);
            if (existingEvent != null)
            {
                existingEvent.Id = value.Id;
                existingEvent.Title = value.Title;
                existingEvent.Start = value.Start;
                existingEvent.End = value.End;

            }
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            events.RemoveAll(e => e.Id == id);
            //var eventToRemove = events.FirstOrDefault(e => e.Id == id);
            //if (eventToRemove != null)
            //    events.Remove(eventToRemove);

        }

    }
}
