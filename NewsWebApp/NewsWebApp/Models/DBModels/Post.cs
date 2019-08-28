using System;
using System.Collections.Generic;

namespace NewsWebApp.Models.DBModels
{
    public partial class Post
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? AuthorId { get; set; }
        public int? CatagoryId { get; set; }
        public string Content { get; set; }
        public int? IsBreakingNews { get; set; }
        public int? NumOfVisitors { get; set; }

        public virtual User Author { get; set; }
        public virtual Catagory Catagory { get; set; }
    }
}