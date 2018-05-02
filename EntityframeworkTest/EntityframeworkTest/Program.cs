using System.Linq;
using System;
using EntityframeworkTest.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

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
                article.ParentNo = article.ArticleNo;
                article.Content = $"test content is {article.ArticleNo}";
                db.Add(article);
                //db.SaveChanges();

                // Child Article
                BlogArticle articleChild = new BlogArticle();
                articleChild.ArticleNo = article.ArticleNo + 1;
                articleChild.WriteUser = blogUser2.UserId;
                articleChild.Content = $"child test content from parent article no {article.ArticleNo}";
                articleChild.ParentNo = article.ArticleNo;
                db.Add(articleChild);
                //db.SaveChanges();

                // Not exists Blog User's Article
                BlogArticle articleOfNoneUser = new BlogArticle();
                articleCount = db.BlogArticle.Count();
                articleOfNoneUser.ArticleNo = articleCount + 1;
                articleOfNoneUser.ParentNo = articleChild.ArticleNo;
                articleOfNoneUser.WriteUser = blogUser.UserId;
                articleOfNoneUser.Content = $"this is none of parent's article";
                //db.Add(articleOfNoneUser);
                //db.SaveChanges();

                // Blog User Insert


                //db.Add(article);
                //db.Add(articleChild);
                //db.SaveChanges();

                Console.WriteLine("article count : " + db.BlogArticle.Count());
                string jsonResult = JsonConvert.SerializeObject(db.BlogArticle.ToList<BlogArticle>());
                Console.ReadLine();

                //List<Goods> goodsList = new List<Goods>();
                //Goods good1 = new Goods() { GoodsNo = 1, GoodsNm = "goods 1", Price = 1000, SetGoodsYn = false };
                //Goods good2 = new Goods() { GoodsNo = 2, GoodsNm = "goods 2", Price = 1500, SetGoodsYn = false };
                //goodsList.Add(good1);
                //goodsList.Add(good2);
                //List<Goods> partialGoods = new List<Goods>();
                //partialGoods.Add(good1);
                //partialGoods.Add(good2);

                //goodsList.Add(new Goods() { GoodsNo = 3, GoodsNm = "goods_3", Price = 2500, SetGoodsYn = true, CompliationGoods = partialGoods });

                //Goods good4 = new Goods() { GoodsNo = 4, GoodsNm = "goods_4", Price = 1000, SetGoodsYn = true, CompliationGoods = goodsList };
                //List<Goods> goodsList2 = new List<Goods>();
                //goodsList2.AddRange(goodsList);
                //goodsList2.Add(good4);

                //Goods good5 = new Goods() { GoodsNo = 4, GoodsNm = "goods_4", Price = 1000, SetGoodsYn = true, CompliationGoods = goodsList2 };
                //List<Goods> goodsList3 = new List<Goods>();
                //goodsList3.AddRange(goodsList2);
                //goodsList3.Add(good5);

                //string jsonResult2 = JsonConvert.SerializeObject(goodsList);
                //Console.ReadLine();
            }



        }
    }
}
