using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateApp.Data.Models.ResponseModel
{
    public class PostUniqueClickResponseModel
    {
        public string Title { get; set; }

        public string ImageLink { get; set; }

        public int ClickCounter { get; set; }

        public int UniqueClickCounter { get; set; }
    }
}
