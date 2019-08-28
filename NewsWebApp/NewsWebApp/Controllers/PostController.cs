using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsWebApp.Models.DBModels;
using NewsWebApp.Models.DataModels;

namespace NewsWebApp.Controllers
{
    public class PostController : Controller
    {
        DBContext db = new DBContext();

        [Route("catagories")]
        public IActionResult Catagory(int typeId = 0, int page = 1)
        {
            List<Post> lstPost = new List<Post>();
            // Breaking News
            if (typeId == 0)
            {
                lstPost = db.Post.Where(n => n.IsBreakingNews == 1).OrderByDescending(n => n.CreatedDate).Take(5).ToList();
            }
            else
            {
                lstPost = db.Post.Where(n => n.CatagoryId == typeId).OrderByDescending(n => n.CreatedDate).Skip((page - 1) * 5).Take(5).ToList();
            }

            // Get Data(Author, Catagory) for Post
            foreach (var post in lstPost)
            {
                post.GetDataPost();
                post.ChangeContentToPlainText();
            }

            return View(lstPost);
        }

        [HttpGet("/{postId}")]
        public IActionResult Detail(string postId = "")
        {
            Post post = db.Post.Where(n => n.Id == postId).SingleOrDefault();

            if (post == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                try
                {
                    post.NumOfVisitors += 1;
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            post.GetDataPost();

            // Get random 2 post with the same catagory
            Random r = new Random();
            List<Post> lst2Post = new List<Post>();

            lst2Post.AddRange(db.Post.Skip(r.Next(0, db.Post.Count() - 1)).Take(1).ToList());
            lst2Post.AddRange(db.Post.Skip(r.Next(0, db.Post.Count() - 1)).Take(1).ToList());

            DetailDataModel data = new DetailDataModel(post, lst2Post);

            return View(data);
        }

        [HttpGet]
        [Route("search")]
        public IActionResult Search(string key = "", int page = 1)
        {
            List<Post> data = db.Post.Where(n => n.Title.Contains(key) || n.Content.Contains(key)).Skip((page - 1) * 5).Take(5).ToList();

            // Get Data(Author, Catagory) for Post
            foreach (var post in data)
            {
                post.GetDataPost();
                post.ChangeContentToPlainText();
            }

            return View("Catagory", data);
        }
    }
}