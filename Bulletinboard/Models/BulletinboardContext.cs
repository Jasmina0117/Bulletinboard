using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Bulletinboard.Models
{
    public class BulletinboardContext : DbContext
    {
        public BulletinboardContext(DbContextOptions<BulletinboardContext> options) : base(options)
        {
        }

        public DbSet<Announcement> Announcement { get; set; }

    }
}
