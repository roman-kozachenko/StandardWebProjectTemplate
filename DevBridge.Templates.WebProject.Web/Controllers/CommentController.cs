using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DevBridge.Templates.WebProject.Tools.Mvc;
using DevBridge.Templates.WebProject.Web.Helpers;
using DevBridge.Templates.WebProject.Web.Logic.Commands.Comment.CreateComment;
using DevBridge.Templates.WebProject.Web.Logic.Commands.Comment.GetCommentsCommand;
using DevBridge.Templates.WebProject.Web.Logic.Models.Comment;

namespace DevBridge.Templates.WebProject.Web.Controllers
{
    public class CommentController : ExtendedControllerBase
    {
        public ActionResult GetComments(int articleId)
        {
            var result = GetCommand<GetCommentsCommand>().ExecuteCommand(articleId);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(CreateCommentViewModel model)
        {
            var user = Membership.GetUser();

            if (user != null)
            {
                model.UserId = (Guid) user.ProviderUserKey;
            }
            else
            {
                return new HttpStatusCodeResult((int) HttpStatusCode.Unauthorized);
            }

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
