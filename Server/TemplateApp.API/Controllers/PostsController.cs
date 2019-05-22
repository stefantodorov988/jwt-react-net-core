using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateApp.Data.Models;
using TemplateApp.Data.Models.Base;
using TemplateApp.Data.Models.RequestModels;
using TemplateApp.Repositories;
using TemplateApp.Repositories.Contract;
using TemplateApp.Services.Contract;

namespace TemplateApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService postService;

        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<Post>> Get()
        {
            var result = postService.GetPosts();
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("click")]
        public ActionResult<string> Click([FromBody]PostClickRequestModel model)
        {
            this.postService.HandlePostClick(model);
            return Ok();
        }

        [HttpPost]
        public ActionResult<string> Create([FromBody]Post post)
        {
            this.postService.CreatePost(post);
            return Ok();
        }
    }
}
