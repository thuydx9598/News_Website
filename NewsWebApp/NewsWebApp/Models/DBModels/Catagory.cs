using System;
using System.Collections.Generic;

namespace NewsWebApp.Models.DBModels
{
    public partial class Catagory
    {
        public Catagory()
        {
            Post = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }
}