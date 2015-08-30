using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Domain.Pages.DTO
{


    public class WordpressPage
    {
        public string status { get; set; }
        public Page page { get; set; }
    }

    public class Page
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


}