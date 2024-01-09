using Bulletinboard.Models;

namespace Bulletinboard.Services
{
    public interface IAnnouncementService
    {
        IEnumerable<Announcement> GetAnnouncement();
        Announcement AddAnnouncement(Announcement announcement);
        Announcement UpdateAnnouncement(Announcement announcement);
        bool DeleteAnnouncement(int announceId);
    }
}
