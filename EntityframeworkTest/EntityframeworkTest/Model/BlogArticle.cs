using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EntityframeworkTest.Model
{
    public partial class BlogArticle
    {
        public int ArticleNo { get; set; }
        public int? ParentNo { get; set; }
        public string WriteUser { get; set; }
        public string Content { get; set; }

        [JsonIgnore]
        public BlogUsers WriteUserNavigation { get; set; }
    }
}
