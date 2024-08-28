namespace BookMgr.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string ?Title { get; set; }
        public string ?ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ?PublisherName { get; set; }
        public List<string> ?AuthorNames { get; set; }
    }
}
