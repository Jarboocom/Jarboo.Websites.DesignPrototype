namespace Services.Domain.Case
{
    public class Case
    {
        public int Id { get; set; }
        public string DownloadUrl { get; set; }

        public string Slug { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public string LowerDescriptionHeadline { get; set; }
        public string LowerDescription { get; set; }

        public string Mailchimp { get; set; }
    }
}