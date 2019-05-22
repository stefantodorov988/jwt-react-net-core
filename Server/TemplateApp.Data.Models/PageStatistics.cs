using System;
using System.Collections.Generic;
using System.Text;
using TemplateApp.Data.Models.Base;

namespace TemplateApp.Data.Models
{
    public class PageStatistics : Entity
    {
        public int Visits { get; set; }
        public int UniqueVisits { get; set; }
    }
}
