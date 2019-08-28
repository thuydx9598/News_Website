using System;
using System.Collections.Generic;

namespace NewsWebApp.Models.DBModels
{
    public partial class Subscriber
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}