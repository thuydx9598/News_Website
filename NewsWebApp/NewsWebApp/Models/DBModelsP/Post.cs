using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewsWebApp.Models.DBModels
{
    public partial class Post
    {
        private DBContext db = new DBContext();

        public void GetDataPost()
        {
            this.Author = db.User.Where(n => n.Id == this.AuthorId).First();
            this.Catagory =  db.Catagory.Where(n => n.Id == this.CatagoryId).First();
        }

        public void ChangeContentToPlainText()
        {
            string htmlTagPattern = "<.*?>";
            var regexCss = new Regex(@"<(meta|link|/?o:|/?style|/?div|/?std|/?head|/?html|body|/?body|/?span|!\[)[^>]*?>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            this.Content = regexCss.Replace(this.Content, string.Empty);
            this.Content = Regex.Replace(this.Content, htmlTagPattern, string.Empty);
            this.Content = Regex.Replace(this.Content, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);

            //StringCollection sc = new StringCollection();
            //// Issue with following line
            //sc.Add(@"<(meta|link|/?o:|/?style|/?div|/?std|/?head|/?html|body|/?body|/?span|!\[)[^>]*?>");
            //foreach (string s in sc)
            //{
            //    this.Content = Regex.Replace(this.Content, s, "", RegexOptions.IgnoreCase);
            //}
        }
    }
}
