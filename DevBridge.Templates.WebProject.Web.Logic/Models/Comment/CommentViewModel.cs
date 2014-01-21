using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevBridge.Templates.WebProject.Web.Logic.Models.Like;
using DevBridge.Templates.WebProject.Web.Logic.Models.User;

namespace DevBridge.Templates.WebProject.Web.Logic.Models.Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public UserViewModel User { get; set; }

        public int LikesCount { get; set; }
        public bool IsLiked { get; set; }

        public List<CommentViewModel> Comments { get; set; }
        public List<LikeViewModel> Likes { get; set; }
    }
}
