using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevBridge.Templates.WebProject.Tools.Mvc;
using DevBridge.Templates.WebProject.Web.Helpers;
using DevBridge.Templates.WebProject.Web.Logic.Commands.Comment.CreateComment;
using DevBridge.Templates.WebProject.Web.Logic.Models.Comment;

namespace DevBridge.Templates.WebProject.Web.Controllers
{
    public class CommentController : ExtendedControllerBase
    {
        public ActionResult GetComments(int articleId)
        {
            return null;
        }

        [HttpPost]
        public ActionResult Create(CreateCommentViewModel model)
        {
            var result = GetCommand<CreateCommentCommand>().ExecuteCommand(model);

            return Json(result);
        }

        [HttpPost]
        public ActionResult Delete()
        {
            return null;
        }
    }
}
