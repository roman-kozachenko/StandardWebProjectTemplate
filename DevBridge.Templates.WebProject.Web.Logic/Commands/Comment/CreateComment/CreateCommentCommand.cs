using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevBridge.Templates.WebProject.Tools.Commands;
using DevBridge.Templates.WebProject.Web.Logic.Models.Comment;

namespace DevBridge.Templates.WebProject.Web.Logic.Commands.Comment.CreateComment
{
    public class CreateCommentCommand:CommandBase,ICommand<CreateCommentViewModel>
    {
        public void Execute(CreateCommentViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
