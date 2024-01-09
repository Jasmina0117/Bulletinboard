using Bulletinboard.Models;

namespace Bulletinboard.Services
{
    public class AnnouncementService: IAnnouncementService
    {
        private readonly IAnnouncementRepo _announcementRepo;
        public AnnouncementService(IAnnouncementRepo announcementRepo)
        {
            _announcementRepo = announcementRepo;
        }

        public IEnumerable<Announcement> GetAnnouncement()
        {
            return _announcementRepo.GetAll();
        }

        public Announcement AddAnnouncement(Announcement announcement)
        {
            announcement.AnnouncementID = _announcementRepo.GetAll().Count() + 1;
            return _announcementRepo.Add(announcement);
        }

        public Announcement UpdateAnnouncement(Announcement announcement)
        {
            if (announcement == null || announcement.AnnouncementID == 0)
                throw new Exception("請確認輸入內容是否有誤");

            return _announcementRepo.Update(announcement);
        }

        public bool DeleteAnnouncement(int announceId)
        {

            var tr = _announcementRepo.BeginTransaction();
            try
            {
                _announcementRepo.Delete(announceId);
                tr.Commit();
                return true;
            }
            catch (Exception e)
            {
                tr.Rollback();
                throw new Exception(e.ToString());
            }
        }


    }
}
