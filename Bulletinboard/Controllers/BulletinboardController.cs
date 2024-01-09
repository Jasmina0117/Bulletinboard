using Bulletinboard.Models;
using Bulletinboard.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bulletinboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BulletinboardController : Controller
    {
        private readonly IAnnouncementService _service;
        public BulletinboardController(IAnnouncementService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Announcement> Get()
        {
            return _service.GetAnnouncement().OrderByDescending(s => s.Date);
        }

        [HttpPost]
        [Route("")]
        public Announcement Add(Announcement announcement)
        {
            return _service.AddAnnouncement(announcement);
        }

        [HttpPut]
        [Route("")]
        public Announcement Put(Announcement announcement)
        {
            return _service.UpdateAnnouncement(announcement);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _service.DeleteAnnouncement(id);
            return Ok(result);
        }
    }
}
