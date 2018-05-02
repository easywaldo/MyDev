using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityframeworkTest.Model
{
    public partial class BlogArticle
    {
        public BlogArticle()
        {
            InverseParentNoNavigation = new HashSet<BlogArticle>();
        }

        [Required]
        public int ArticleNo { get; set; }
        [ForeignKey("ArticleNo")]
        public int? ParentNo { get; set; }
        [Required]
        public string WriteUser { get; set; }
        [Required]
        public string Content { get; set; }

        [JsonIgnore]
        public BlogArticle ParentNoNavigation { get; set; }

        [JsonIgnore]
        public BlogUsers WriteUserNavigation { get; set; }

        [JsonIgnore]
        public ICollection<BlogArticle> InverseParentNoNavigation { get; set; }
    }
}
