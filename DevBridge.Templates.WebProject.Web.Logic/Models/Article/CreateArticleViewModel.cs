using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DevBridge.Templates.WebProject.Web.Logic.Models.Article
{
    public class CreateArticleViewModel
    {
        public Guid UserId { get; set; }
        [Required]
        [Display(Name = "Article title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Article body")]
        public string Text { get; set; }
    }
}
