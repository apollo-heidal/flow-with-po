using System.Linq;
using System.Collections.Generic;
using FlowWithPo.Models;
using FlowWithPo.Data;


namespace FlowWithPo.Repositories
{
    public class BlogRepository: IBlogRepository
    {
        private BlogPostContext _context;
        public BlogRepository(BlogPostContext blogPostContext)
        {
            _context = blogPostContext;
        }

        public IEnumerable<BlogPost> GetPosts()
        {
            return _context.BlogPosts.ToList();
        }

        public void AddPost(BlogPost blogPost)
        {
            _context.BlogPosts.Add(blogPost);
            _context.SaveChanges();
        }

        public void EditPost(BlogPost blogPost)
        {
            _context.BlogPosts.Update(blogPost);
            _context.SaveChanges();
        }

        public void DeletePost(int id)
        {
            BlogPost postToDelete = _context.BlogPosts.Single(bp => bp.BlogPostId == id);
            _context.BlogPosts.Remove(postToDelete);
            _context.SaveChanges();
        }

        public BlogPost GetPost(int id)
        {
            return _context.BlogPosts.SingleOrDefault(bp => bp.BlogPostId == id);
        }
    }
}