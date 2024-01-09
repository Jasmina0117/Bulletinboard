using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bulletinboard.Models
{
    public class AnnouncementRepo : IAnnouncementRepo
    {
        private readonly BulletinboardContext _context;
        public AnnouncementRepo(BulletinboardContext context)
        {
            _context = context;
        }
        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public IEnumerable<Announcement> GetAll()
        {
            return _context.Announcements.ToList();
        }

        public Announcement Add(Announcement announcement)
        {

            _context.Announcements.Add(announcement);
            _context.SaveChanges();
            return announcement;
        }

        public Announcement Update(Announcement announcement)
        {
            var item = _context.Announcements.Find(announcement.AnnouncementID);
            if (item == null)
                throw new Exception("無此資料");
            item.Title = announcement.Title;
            item.Content = announcement.Content;
            item.Publisher = announcement.Publisher;
            item.Date = announcement.Date;

            _context.SaveChanges();
            return announcement;
        }

        public void Delete(int id)
        {
            var delValue = _context.Announcements.Find(id);
            _context.Announcements.Remove(delValue);
            _context.SaveChanges();
        }
    }
}
