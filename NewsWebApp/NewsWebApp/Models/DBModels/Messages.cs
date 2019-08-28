using System;
using System.Collections.Generic;

namespace NewsWebApp.Models.DBModels
{
    public partial class Messages
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime? SentDate { get; set; }
    }
}