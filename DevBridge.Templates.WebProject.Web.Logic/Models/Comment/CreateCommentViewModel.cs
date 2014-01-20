using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBridge.Templates.WebProject.Web.Logic.Models.Comment
{
    public class CreateCommentViewModel
    {
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public DataEntities.Entities.Article Article { get; set; }
        public DataEntities.Entities.Comment ParentComment { get; set; }
    }
}
