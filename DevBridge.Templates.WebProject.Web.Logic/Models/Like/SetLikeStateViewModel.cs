using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBridge.Templates.WebProject.Web.Logic.Models.Like
{
    public class SetLikeStateViewModel
    {
        public Guid UserId { get; set; }
        public int CommentId { get; set; }
        public bool LikeState { get; set; }
    }
}
