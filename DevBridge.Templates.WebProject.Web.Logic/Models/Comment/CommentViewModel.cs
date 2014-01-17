﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevBridge.Templates.WebProject.Web.Logic.Models.Like;
using DevBridge.Templates.WebProject.Web.Logic.Models.User;

namespace DevBridge.Templates.WebProject.Web.Logic.Models.Comment
{
    public class CommentViewModel
    {
        public string Text { get; set; }
        public UserViewModel User { get; set; }
        public List<LikeViewModel> Likes { get; set; }
    }
}