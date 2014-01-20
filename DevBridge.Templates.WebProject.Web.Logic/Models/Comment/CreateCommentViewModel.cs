using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBridge.Templates.WebProject.Web.Logic.Models.Comment
{
    public class CreateCommentViewModel
    {
        public Guid UserId { get; set; }
        public string Text { get; set; }
        
        public int? ArticleId { get; set; }
        public int? ParentCommentId { get; set; }
    }
}
