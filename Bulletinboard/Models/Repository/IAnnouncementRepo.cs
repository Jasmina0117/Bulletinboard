using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bulletinboard.Models
{
    public interface IAnnouncementRepo
    {
        IDbContextTransaction BeginTransaction();

        IEnumerable<Announcement> GetAll();
        Announcement Add(Announcement announcement);
        Announcement Update(Announcement announcement);
        void Delete(int announceId);
    }
}
