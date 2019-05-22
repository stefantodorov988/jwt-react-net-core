using System;
using System.Collections.Generic;
using System.Text;
using TemplateApp.Data.Models;
using TemplateApp.Data.Models.RequestModels;
using TemplateApp.Data.Models.ResponseModel;

namespace TemplateApp.Services.Contract
{
    public interface IStatisticsService
    {
        void HandleVisit(PageVisitRequestModel model);
        SiteStatisticsResponseModel GetSiteStatistics();
    }
}
