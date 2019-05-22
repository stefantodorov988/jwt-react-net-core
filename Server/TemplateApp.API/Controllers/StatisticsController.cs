using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateApp.Data.Models;
using TemplateApp.Data.Models.RequestModels;
using TemplateApp.Data.Models.ResponseModel;
using TemplateApp.Services.Contract;

namespace TemplateApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }


        [HttpGet]
        public ActionResult<SiteStatisticsResponseModel> Get()
        {
            // var result = postService.GetPosts();
            var result =this.statisticsService.GetSiteStatistics();
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("alertvisit")]
        public IActionResult AlertVisit([FromBody]PageVisitRequestModel model)
        {
            this.statisticsService.HandleVisit(model);
            return Ok();
        }
    }
}
