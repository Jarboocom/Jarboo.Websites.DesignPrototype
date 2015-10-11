using System.Collections.Generic;

namespace Services.Domain.Pages.DTO
{


    public class WordpressPageList
    {
        public string status { get; set; }
        public WordpressPage[] pages { get; set; }
    }
    

    public class WordpressPage
    {
        public int id { get; set; }
        public string type { get; set; }
        public string slug { get; set; }
        public string url { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public string title_plain { get; set; }
        public string content { get; set; }
        public string excerpt { get; set; }
        public string date { get; set; }
        public string modified { get; set; }
        public object[] categories { get; set; }
        public object[] tags { get; set; }
        public Author author { get; set; }
        public object[] comments { get; set; }
        public object[] attachments { get; set; }
        public int comment_count { get; set; }
        public string comment_status { get; set; }
        public Custom_Fields custom_fields { get; set; }
        public WordpressPage[] children { get; set; }
    }

    public class Author
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string nickname { get; set; }
        public string url { get; set; }
        public string description { get; set; }
    }

    public class Custom_Fields
    {
    }

    public class Child
    {
        public int id { get; set; }
        public string type { get; set; }
        public string slug { get; set; }
        public string url { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public string title_plain { get; set; }
        public string content { get; set; }
        public string excerpt { get; set; }
        public string date { get; set; }
        public string modified { get; set; }
        public object[] categories { get; set; }
        public object[] tags { get; set; }
        public Author1 author { get; set; }
        public object[] comments { get; set; }
        public Attachment[] attachments { get; set; }
        public int comment_count { get; set; }
        public string comment_status { get; set; }
        public Custom_Fields1 custom_fields { get; set; }
        public int parent { get; set; }
        public Child1[] children { get; set; }
    }

    public class Author1
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string nickname { get; set; }
        public string url { get; set; }
        public string description { get; set; }
    }

    public class Custom_Fields1
    {
    }

    public class Attachment
    {
        public int id { get; set; }
        public string url { get; set; }
        public string slug { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string caption { get; set; }
        public int parent { get; set; }
        public string mime_type { get; set; }
        public Images images { get; set; }
    }

    public class Images
    {
        public Full full { get; set; }
        public Thumbnail thumbnail { get; set; }
        public Medium medium { get; set; }
        public PostThumbnail postthumbnail { get; set; }
    }

    public class Full
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Thumbnail
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Medium
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class PostThumbnail
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Child1
    {
        public int id { get; set; }
        public string type { get; set; }
        public string slug { get; set; }
        public string url { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public string title_plain { get; set; }
        public string content { get; set; }
        public string excerpt { get; set; }
        public string date { get; set; }
        public string modified { get; set; }
        public object[] categories { get; set; }
        public object[] tags { get; set; }
        public Author2 author { get; set; }
        public object[] comments { get; set; }
        public object[] attachments { get; set; }
        public int comment_count { get; set; }
        public string comment_status { get; set; }
        public Custom_Fields2 custom_fields { get; set; }
        public int parent { get; set; }
        public object[] children { get; set; }
    }

    public class Author2
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string nickname { get; set; }
        public string url { get; set; }
        public string description { get; set; }
    }

    public class Custom_Fields2
    {
    }



}