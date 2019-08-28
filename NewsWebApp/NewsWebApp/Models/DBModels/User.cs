using System;
using System.Collections.Generic;

namespace NewsWebApp.Models.DBModels
{
    public partial class User
    {
        public User()
        {
            Post = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }
}