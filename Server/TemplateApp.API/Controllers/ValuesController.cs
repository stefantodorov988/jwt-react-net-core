using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateApp.Data.Models;
using TemplateApp.Data.Models.Base;
using TemplateApp.Repositories;
using TemplateApp.Repositories.Contract;

namespace TemplateApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly IRepository<Blog> blogRepository;
        private readonly IRepository<Post> postRepository;

        public ValuesController(IRepository<Blog> blogRepository , IRepository<Post> postRepository)
        {
            this.blogRepository = blogRepository;
            this.postRepository = postRepository;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            Func<Blog, bool> pred = k => k.Id == 2;
            IEnumerable<Blog> result = this.blogRepository.Filter(pred);
            var test = result.ToList();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
