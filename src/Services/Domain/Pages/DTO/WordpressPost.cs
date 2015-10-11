using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Pages.DTO
{


    public class WordpressPostList
    {
        public string status { get; set; }
        public int count { get; set; }
        public int count_total { get; set; }
        public int pages { get; set; }
        public WordpressPost[] posts { get; set; }
        public Query query { get; set; }
    }

    public class Query
    {
        public bool ignore_sticky_posts { get; set; }
    }

    public class WordpressPost
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
        public PostAuthor author { get; set; }
        public object[] comments { get; set; }
        public object[] attachments { get; set; }
        public int comment_count { get; set; }
        public string comment_status { get; set; }

    }

    public class PostAuthor
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
    

}
