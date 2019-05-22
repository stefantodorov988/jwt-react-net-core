using System;
using System.Collections.Generic;
using System.Text;
using TemplateApp.Data.Models.Base;

namespace TemplateApp.Data.Models
{
    public class Post : Entity
    {
        public string Title { get; set; }

        public string ImageLink { get; set; }

        public int ClickCounter { get; set; }

    }
}
