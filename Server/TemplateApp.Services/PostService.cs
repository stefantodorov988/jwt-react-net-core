using System;
using System.Collections.Generic;
using TemplateApp.Data.Models;
using TemplateApp.Data.Models.RequestModels;
using TemplateApp.Repositories.Contract;
using TemplateApp.Services.Contract;
using System.Linq;

namespace TemplateApp.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> postRepository;
        private readonly IRepository<UniqueClick> uniqueClickRepository;
        private readonly IRepository<IpAdress> ipAdressRepository;

        public PostService(IRepository<Post> postRepository
            , IRepository<UniqueClick> uniqueClickRepository
            , IRepository<IpAdress> ipAdressRepository)
        {
            this.postRepository = postRepository;
            this.uniqueClickRepository = uniqueClickRepository;
            this.ipAdressRepository = ipAdressRepository;
    }

        public void CreatePost(Post post)
        {
            this.postRepository.Create(post);
            this.postRepository.SaveChanges();
        }

        public IEnumerable<Post> GetPosts()
        {
            return this.postRepository.Filter();
        }

        public void HandlePostClick(PostClickRequestModel model)
        {
            var post = this.postRepository.GetById(model.Id);
            var ip = this.ipAdressRepository.Filter(x => x.Value == model.Ip).FirstOrDefault();
            var uniqueClick = this.uniqueClickRepository.Filter(x => x.PostId == model.Id && x.IpAdressId == ip.Id).FirstOrDefault();

            if (post != null)
            {
                post.ClickCounter++;
                postRepository.SaveChanges();
            }

            if(ip == null)
            {
                this.ipAdressRepository.Create(new IpAdress { Value = model.Ip });
                this.ipAdressRepository.SaveChanges();
                ip = this.ipAdressRepository.Filter(x => x.Value == model.Ip).FirstOrDefault();
            }

            if(uniqueClick != null)
            {
                uniqueClick.ClickCounter++;
            }
            else
            {
                this.uniqueClickRepository.Create( new UniqueClick { ClickCounter = 1 
                                                                    , PostId = post.Id
                                                                    , IpAdressId = ip.Id });
            }

            this.postRepository.SaveChanges();
            this.uniqueClickRepository.SaveChanges();
            this.ipAdressRepository.SaveChanges();
        }
    }
}
