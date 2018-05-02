using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EntityframeworkTest.Model
{
    public partial class BlogUsers
    {
        public BlogUsers()
        {
            BlogArticle = new HashSet<BlogArticle>();
        }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public string BlogUrl { get; set; }

        [JsonIgnore]
        public ICollection<BlogArticle> BlogArticle { get; set; }
    }
}
