using System.Linq;
using System;
using EntityframeworkTest.Model;
using Newtonsoft.Json;

namespace EntityframeworkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BlogDataContext())
            {
                var blogUser = db.BlogUsers.Where(x => x.UserId == "testuser").FirstOrDefault();
                var blogUser2 = db.BlogUsers.Where(x => x.UserId == "test01").FirstOrDefault();
                
                Console.WriteLine("user count : " + db.BlogUsers.Count());
                Console.WriteLine("article count : " + db.BlogArticle.Count());

                //BlogUsers user = new BlogUsers();
                //user.UserId = "test01";
                //user.UserName = "test_user_01";
                //user.BlogUrl = "test_blog_url";

                //db.Add(user);
                //db.SaveChanges();
                

                // Parent Article
                BlogArticle article = new BlogArticle();
                int articleCount = db.BlogArticle.Count();
                article.ArticleNo = articleCount + 1;
                article.WriteUser = blogUser.UserId;
                article.Content = $"test content is {article.ArticleNo}";

                // Child Article
                BlogArticle articleChild = new BlogArticle();
                articleChild.ArticleNo = article.ArticleNo + 1;
                articleChild.WriteUser = blogUser2.UserId;
                articleChild.Content = $"child test content from parent article no {article.ArticleNo}";
                articleChild.ParentNo = article.ArticleNo;

                //db.Add(article);
                //db.Add(articleChild);
                //db.SaveChanges();
                
                Console.WriteLine("article count : " + db.BlogArticle.Count());
                string jsonResult = JsonConvert.SerializeObject(db.BlogArticle.ToList<BlogArticle>());
                Console.ReadLine();



            }



        }
    }
}
