using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsWebApp.Models.DBModels;

namespace NewsWebApp.Models.DataModels
{
    public class DetailDataModel
    {
        public Post post { get; set; }
        public List<Post> lst2Posts { get; set; }

        public DetailDataModel()
        {
            this.lst2Posts = new List<Post>();
        }

        public DetailDataModel(Post post, List<Post> lstPost)
        {
            this.post = post;
            this.lst2Posts = lstPost;
        }
    }
}
