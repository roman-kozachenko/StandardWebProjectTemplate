using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevBridge.Templates.WebProject.Web.Logic.Models.Comment;
using DevBridge.Templates.WebProject.Web.Logic.Models.User;

namespace DevBridge.Templates.WebProject.Web.Logic.Models.Article
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public UserViewModel User { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}
