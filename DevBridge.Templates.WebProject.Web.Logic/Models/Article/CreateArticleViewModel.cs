using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBridge.Templates.WebProject.Web.Logic.Models.Article
{
    public class CreateArticleViewModel
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
