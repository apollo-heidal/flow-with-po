using System;
using System.Collections.Generic;
using FlowWithPo.Models;

namespace FlowWithPo.Repositories
{
    public interface IBlogRepository
    {
        IEnumerable<BlogPost> GetPosts();
        void AddPost(BlogPost blogPost);
        void EditPost(BlogPost blogPost);
        void DeletePost(int id);
        BlogPost GetPost(int id);
    }
}