using System;
using DevBridge.Templates.WebProject.Tools.Commands;

namespace DevBridge.Templates.WebProject.Web.Logic.Commands.Article.DeleteArticle
{
    public class DeleteArticleCommand:CommandBase,ICommand<int>
    {
        public void Execute(int articleId)
        {
            throw new NotImplementedException();
        }
    }
}
