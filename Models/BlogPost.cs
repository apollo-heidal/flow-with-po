using System;
using System.ComponentModel.DataAnnotations;
using FlowWithPo.Validators;

namespace FlowWithPo.Models
{
    public class BlogPost
    {
        [Key]
        public int BlogPostId { get; set; }
        
        [StringLength(50)]
        [Required(ErrorMessage = "please title the post!")]
        [UniqueTitleValidation]
        public string Title { get; set; }

        [StringLength(5000)]
        [Required(ErrorMessage = "please add words!")]
        public string Text { get; set; }
        

        [DataType(DataType.DateTime)]
        public DateTime TimePosted { get; set; }
    }
}