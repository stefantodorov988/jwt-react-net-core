using System;
using System.Collections.Generic;
using System.Text;
using TemplateApp.Data.Models.Base;

namespace TemplateApp.Data.Models
{
    public class Blog : Entity
    {
        public string Url { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
