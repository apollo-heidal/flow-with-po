using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FlowWithPo.Models;
using FlowWithPo.Repositories;

namespace FlowWithPo.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository _blogRepository;
        private readonly ILogger<BlogController> _logger;

        public BlogController(IBlogRepository blogRepository, ILogger<BlogController> logger)
        {
            _blogRepository = blogRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_blogRepository.GetPosts());
        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                blogPost.TimePosted = DateTime.Now;
                _blogRepository.AddPost(blogPost);
                return RedirectToAction("Index");
            }
            return View(blogPost);
        }

        public IActionResult ViewPost(int id)
        {
            return View(_blogRepository.GetPost(id));
        }

        [HttpGet]
        public IActionResult EditPost(int id)
        {
            return View(_blogRepository.GetPost(id));
        }

        [HttpPost]
        public IActionResult EditPost(int id, BlogPost blogPost)
        {
            BlogPost oldPost = _blogRepository.GetPost(id);
            oldPost.Title = blogPost.Title;
            oldPost.Text = blogPost.Text;
            
            _blogRepository.EditPost(oldPost);
            
            return RedirectToAction("Index");
        }

        public IActionResult DeletePost(int id)
        {
            _blogRepository.DeletePost(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
