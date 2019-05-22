using System;
using System.Collections.Generic;
using System.Text;
using TemplateApp.Data.Models;
using TemplateApp.Data.Models.RequestModels;

namespace TemplateApp.Services.Contract
{
    public interface IPostService
    {
        IEnumerable<Post> GetPosts();
        void HandlePostClick(PostClickRequestModel model);
        void CreatePost(Post post);
    }
}
