using System;
using TemplateApp.Data.Models;
using TemplateApp.Data.Models.RequestModels;
using TemplateApp.Repositories.Contract;
using TemplateApp.Services.Contract;
using System.Linq;
using TemplateApp.Data.Models.ResponseModel;

namespace TemplateApp.Services
{
    public class StatisticsService : IStatisticsService
    {
        private const int HARDCODED_SITE = 3;
        private readonly IRepository<PageStatistics> pageRepository;
        private readonly IRepository<IpAdress> ipRepository;
        private readonly IRepository<Post> postRepository;
        private readonly IRepository<UniqueClick> uniqueClickRepository;

        public StatisticsService(IRepository<PageStatistics> repository, IRepository<IpAdress> ipRepository, IRepository<Post> postRepository, IRepository<UniqueClick> uniqueClickRepository)
        {
            this.pageRepository = repository;
            this.ipRepository = ipRepository;
            this.postRepository = postRepository;
            this.uniqueClickRepository = uniqueClickRepository;
        }

        public SiteStatisticsResponseModel GetSiteStatistics()
        {
            var result = this.pageRepository.GetById(HARDCODED_SITE);
            if (result != null)
            {
                return new SiteStatisticsResponseModel
                {
                    Visits = result.Visits,
                    UniqueVisits = result.UniqueVisits,
                    Posts = this.postRepository.Filter().OrderByDescending(x => x.ClickCounter).Select(x => new PostUniqueClickResponseModel
                    {
                        ClickCounter = x.ClickCounter,
                        ImageLink = x.ImageLink,
                        Title = x.Title,
                        UniqueClickCounter = GetUniqueClick(x)
                    }).ToList(),
                    OverallClicks = this.postRepository.Filter().ToList().Sum(x => x.ClickCounter),
                    OverallUniqueClicks = this.uniqueClickRepository.Filter().ToList().Count()
                };
            }
            return null;
        }

        public int GetUniqueClick(Post post)
        {
            return this.uniqueClickRepository.Filter(x => x.PostId == post.Id).Count();
        }

        public void HandleVisit(PageVisitRequestModel model)
        {
            var result = this.pageRepository.GetById(HARDCODED_SITE);
            if (result != null)
            {
                result.Visits++;
                Func<IpAdress, bool> filter = x => x.Value == model.Ip;
                var ipAdresses = this.ipRepository.Filter(filter).ToList().FirstOrDefault();
                if (ipAdresses == null)
                {
                    result.UniqueVisits++;
                    this.ipRepository.Create(new IpAdress { Value = model.Ip });
                }


                this.pageRepository.SaveChanges();
                this.ipRepository.SaveChanges();
            }
        }
    }
}
