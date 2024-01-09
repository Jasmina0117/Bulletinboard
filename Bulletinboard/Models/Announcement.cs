namespace Bulletinboard.Models
{
    public class Announcement
    {
        public int AnnouncementID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Publisher { get; set; }
        public DateTime Date { get; set; }
    }
}
