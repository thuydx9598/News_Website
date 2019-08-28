using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsWebApp.Models.DBModels;

namespace NewsWebApp.Models.DataModels
{
    public class HomeDataModel
    {
        DBContext db = null;
        // 3 post have tha most visited
        public List<Post> lst3Newest { get; set; }
        public List<Post> lstNewestPostOfCategories { get; set; }
        public List<Post> lst4PopularNews { get; set; }

        public HomeDataModel()
        {
            db = new DBContext();

            lst3Newest = db.Post.OrderByDescending(n => n.CreatedDate).Take(3).ToList();
            lst3Newest = GetDataOfPost(lst3Newest);
            lst3Newest = ChangeContentToPlainText(lst3Newest);

            lst4PopularNews = db.Post.OrderByDescending(n => n.NumOfVisitors).Take(4).ToList();
            lst4PopularNews = GetDataOfPost(lst4PopularNews);
        }

        public HomeDataModel(string layout)
        {
            db = new DBContext();

            lstNewestPostOfCategories = db.Post.GroupBy(n => n.CatagoryId).Select(n => n.LastOrDefault()).ToList();
            lstNewestPostOfCategories = GetDataOfPost(lstNewestPostOfCategories);

            lst4PopularNews = db.Post.OrderByDescending(n => n.NumOfVisitors).Take(4).ToList();
            lst4PopularNews = GetDataOfPost(lst4PopularNews);
        }

        private List<Post> GetDataOfPost(List<Post> list)
        {
            foreach (var item in list)
            {
                item.GetDataPost();
            }

            return list;
        }

        private List<Post> ChangeContentToPlainText(List<Post> list)
        {
            foreach (var item in list)
            {
                item.ChangeContentToPlainText();
            }

            return list;
        }
    }
}
