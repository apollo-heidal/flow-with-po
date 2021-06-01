using System.Linq;
using System.ComponentModel.DataAnnotations;
using FlowWithPo.Models;
using FlowWithPo.Repositories;

namespace FlowWithPo.Validators
{
    public class UniqueTitleValidation : ValidationAttribute
    {
        // private string _title;
        // public UniqueTitleValidation(string title)
        // {
        //     _title = title;
        // }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var blogService = (IBlogRepository)validationContext.GetService(typeof(IBlogRepository));
            if (blogService != null)
            {
                var allBlogPosts = blogService.GetPosts();
                if (allBlogPosts.Any<BlogPost>(t => t.Title == value.ToString()))
                {
                    return new ValidationResult("There is already a post with this title");
                }
                return ValidationResult.Success;
            }
            else { return ValidationResult.Success; }
        }
    }
}