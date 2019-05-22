using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateApp.Data.Models.ResponseModel
{
    public class SiteStatisticsResponseModel
    {
        public int Visits { get; set; }
        public int UniqueVisits { get; set; }

        public IEnumerable<PostUniqueClickResponseModel> Posts { get; set; }

        public int OverallClicks { get; set; }
        public int OverallUniqueClicks { get; set; }
    }
}
